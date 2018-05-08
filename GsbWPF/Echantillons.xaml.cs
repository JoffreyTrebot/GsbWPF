using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Text.RegularExpressions;

namespace GsbWPF
{
    /// <summary>
    /// Logique d'interaction pour Echantillons.xaml
    /// </summary>
    public partial class Echantillons : Window
    {

        private string _chaineConnexion;
        private int _rapNum;
        public Echantillons(string chaineConnexion, int rapportNum)
        {
            InitializeComponent();
            this._chaineConnexion = chaineConnexion;
            this._rapNum = rapportNum;

            CURS cs2 = new CURS(chaineConnexion);
            string requete2 = "SELECT MED_NOMCOMMERCIAL FROM medicament;";
            cs2.ReqSelect(requete2);
            while (!cs2.Fin())
            {
                cbx_nom.Items.Add(cs2.champ("MED_NOMCOMMERCIAL").ToString());
                cs2.suivant();
            }
            cs2.fermer();
        }

        private void btn_supprimer_Click(object sender, RoutedEventArgs e)
        {
            int i;
            for (i = 0; i < ltb_resultat.Items.Count; i++)
            {
                if (ltb_resultat.Items[i] == ltb_resultat.SelectedItem)
                {
                    ltb_resultat.Items.Remove(ltb_resultat.SelectedItem);
                    ltb_qte.Items.Remove(ltb_qte.Items[i]);
                    break;
                }
            }
        }

        private void btn_fermer_Click(object sender, RoutedEventArgs e)
        {
            int i, codeEchan, qte;
            for (i = 0; i < ltb_resultat.Items.Count; i++)
            {
                CURS cs = new CURS(_chaineConnexion);
                string requete = "SELECT ECHAN_CODE FROM echantillon WHERE ECHAN_NOM = '" + ltb_resultat.Items[i] + "'; ";
                cs.ReqSelect(requete);
                codeEchan = Int32.Parse(cs.champ("ECHAN_CODE").ToString());
                cs.fermer();

                qte = Int32.Parse(ltb_qte.Items[i].ToString());

                CURS cs3 = new CURS(_chaineConnexion);
                string requete3 = "INSERT INTO distribuer VALUES ( " + -_rapNum+ " , " + codeEchan + " , " + qte + ");";
                cs3.ReqAdmin(requete3);
                cs3.fermer();
            }

            this.Close();
        }

        private void btn_ajout_Click(object sender, RoutedEventArgs e)
        {
            ltb_resultat.Items.Add(cbx_nom.Text);
            ltb_qte.Items.Add(tbx_nb.Text);
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void tbx_nb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
