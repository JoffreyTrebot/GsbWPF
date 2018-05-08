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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GsbWPF
{
    /// <summary>
    /// Logique d'interaction pour UserControlNouveauRapport.xaml
    /// </summary>
    public partial class UserControlNouveauRapport : UserControl
    {
        private string _matricule;
        public string _chaineConnexion;
        public UserControlNouveauRapport(string chaineConnexion, string matricule)
        {
            InitializeComponent();
            this._chaineConnexion = chaineConnexion;
            this._matricule = matricule;
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            TextRange textrange = new TextRange(
                rtbx_bilan.Document.ContentStart,
                rtbx_bilan.Document.ContentEnd
                );
            if (tbx_NRapport.Text != "" && textrange.Text != "")
            {
                string dt = Convert.ToString(dtp_date);
                dt = dt.Replace('/', '-');
                string checkbox_value = dt;
                char[] splitters = new char[] { '-' };
                string[] laCase = checkbox_value.Split(splitters);
                string value = laCase[2];
                char[] split = new char[] { ' ' };
                string[] laCas = value.Split(split);
                dt = laCas[0] + "-" + laCase[1] + "-" + laCase[0] + " " + laCas[1];

                
                MessageBoxResult retour = MessageBox.Show("Vous venez de valider un rapport de visite !. Avez-vous donner des échantillons ?", "Alerte", MessageBoxButton.YesNo);
                if (retour == MessageBoxResult.Yes)
                {
                    CURS cs3 = new CURS(_chaineConnexion);
                    string requete3 = "INSERT INTO rapport_visite VALUES ( '" + _matricule + "' , " + tbx_NRapport.Text + " , " + tbx_test.Text + ", '" + dt + "' , '" + textrange.Text + "');";
                    cs3.ReqAdmin(requete3);
                    cs3.fermer();
                    CURS cs5 = new CURS(_chaineConnexion);
                    string requete5 = "SELECT MOTIF_CODE FROM motif WHERE MOTIF_LIBELLE = '" + cbx_motif.Text + "' ;";
                    cs5.ReqSelect(requete5);
                    string code_motif;
                    code_motif = cs5.champ("MOTIF_CODE").ToString();
                    CURS cs4 = new CURS(_chaineConnexion);
                    string requete4 = "INSERT INTO motiver VALUES ( " + code_motif + " , " + tbx_NRapport.Text + " , '" + _matricule + "' );";
                    cs4.ReqAdmin(requete4);
                    cs4.fermer();

                    Echantillons echan = new Echantillons(_chaineConnexion, Int32.Parse(tbx_NRapport.Text));
                    echan.Show();

                    Reload();

                }
                else
                {
                    CURS cs3 = new CURS(_chaineConnexion);
                    string requete3 = "INSERT INTO rapport_visite VALUES ( '" + _matricule + "' , " + tbx_NRapport.Text + " , " + tbx_test.Text + " , '" + dt + "' , '" + textrange.Text + "');";
                    cs3.ReqAdmin(requete3);
                    cs3.fermer();
                    CURS cs5 = new CURS(_chaineConnexion);
                    string requete5 = "SELECT MOTIF_CODE FROM motif WHERE MOTIF_LIBELLE = '" + cbx_motif.Text + "' ;";
                    cs5.ReqSelect(requete5);
                    string code_motif;
                    code_motif = cs5.champ("MOTIF_CODE").ToString();
                    CURS cs4 = new CURS(_chaineConnexion);
                    string requete4 = "INSERT INTO motiver VALUES ( " + code_motif + " , " + tbx_NRapport.Text + " , '" + _matricule + "' );";
                    cs4.ReqAdmin(requete4);
                    cs4.fermer();


                    MessageBox.Show("Rapport enregistrer !");
                    Reload();
                }
            }
            else
            {
                MessageBox.Show("Vous n'avez pas remplis tout les champs ! ");
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (tbx_test.Text != "")
            {
                DetailsPraticien d = new DetailsPraticien(this._chaineConnexion,tbx_test.Text);
                d.Show();
            }
            else
            {
                MessageBox.Show("Vous n'avez sélectionner de praticien !");
            }
        }

        public void Reload()
        {
            tbx_NRapport.Clear();
            dtp_date.SelectedDate = null;
            comboBox1.SelectedIndex = 0;
            cbx_motif.SelectedIndex = 0;
            rtbx_bilan.Document.Blocks.Clear();

            CURS cs1 = new CURS(_chaineConnexion);
            string numRapp;
            string requete1 = "SELECT MAX(RAP_NUM)+1 as MAX FROM rapport_visite; ";
            cs1.ReqSelect(requete1);

            while (!cs1.Fin())
            {
                numRapp = cs1.champ("MAX").ToString();
                tbx_NRapport.Text = numRapp;
                cs1.suivant();
            }
            cs1.fermer();

        }


        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            CURS cs = new CURS(_chaineConnexion);
            string requete = "SELECT PRA_NOM, PRA_PRENOM, PRA_NUM FROM praticien; ";
            cs.ReqSelect(requete);

            while (!cs.Fin())
            {
                comboBox1.Items.Add(cs.champ("PRA_NOM").ToString());
                //comboBox1.Items.Add(cs.champ("PRA_NOM").ToString() + " " + cs.champ("PRA_PRENOM").ToString());
                cs.suivant();
            }
            cs.fermer();

            CURS cs1 = new CURS(_chaineConnexion);
            string numRapp;

            string requete1 = "SELECT MAX(RAP_NUM)+1 as MAX FROM rapport_visite; ";
            cs1.ReqSelect(requete1);

            while (!cs1.Fin())
            {
                numRapp = cs1.champ("MAX").ToString();
                tbx_NRapport.Text = numRapp;
                cs1.suivant();
            }
            cs1.fermer();

            CURS cs2 = new CURS(_chaineConnexion);
            string requete2 = "SELECT MOTIF_LIBELLE FROM motif; ";
            cs2.ReqSelect(requete2);

            while (!cs2.Fin())
            {
                cbx_motif.Items.Add(cs2.champ("MOTIF_LIBELLE").ToString());
                cs2.suivant();
            }
            cs2.fermer();

            comboBox1.SelectedIndex = 0;
            cbx_motif.SelectedIndex = 0;


        }


        private void comboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() != "")
            {
                CURS cs2 = new CURS(_chaineConnexion);
                string requete2 = "SELECT PRA_NUM FROM praticien WHERE PRA_NOM= '" + comboBox1.SelectedItem.ToString() + "';";
                cs2.ReqSelect(requete2);
                while (!cs2.Fin())
                {
                    tbx_test.Text = cs2.champ("PRA_NUM").ToString();
                    cs2.suivant();
                }
                cs2.fermer();
            }
        }

        private void cbx_motif_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
