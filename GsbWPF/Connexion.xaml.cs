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

namespace GsbWPF
{
    /// <summary>
    /// Logique d'interaction pour Connexion.xaml
    /// </summary>
    public partial class Connexion : Window
    {
        private string _chaineConnexion;
        private string _matricule;
        public Connexion()
        {
            InitializeComponent();
            _chaineConnexion = "<< CONNEXION A LA BASE DE DONNEES >>";
        }

        private void btn_Valider_Click(object sender, RoutedEventArgs e)
        {
            if (tbx_login.Text == "" || tbx_mdp.Text == "")
            {
                MessageBox.Show("Vos informations de connexion ne sont pas correctes");
            }
            else
            {
                CURS cs = new CURS(_chaineConnexion);
                string requete = "SELECT collaborateur.COL_MATRICULE , COL_DATEEMBAUCHE FROM collaborateur INNER JOIN visiteur ON collaborateur.COL_MATRICULE = visiteur.COL_MATRICULE WHERE COL_NOM = ";
                requete += "'";
                requete += tbx_login.Text;
                requete += "'";
                requete += ";";
                cs.ReqSelect(requete);

                _matricule = cs.champ("COL_MATRICULE").ToString();
                string mdp = cs.champ("COL_DATEEMBAUCHE").ToString();
                mdp = mdp.Replace('/', '-');
                mdp = mdp.Substring(0, 10);

                while (!cs.Fin())
                {

                    if (mdp == tbx_mdp.Text)
                    {
                        MainWindow m = new MainWindow(_chaineConnexion, _matricule);
                        this.Hide();
                        m.Show();
                    }
                    else
                    {
                        MessageBox.Show("Vos informations de connexion ne sont pas correctes");
                    }
                    cs.suivant();
                }
                cs.fermer();
            }
        }

        private void btn_close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
