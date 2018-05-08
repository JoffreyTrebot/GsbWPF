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
    /// Logique d'interaction pour UserControlPraticiens.xaml
    /// </summary>
    public partial class UserControlPraticiens : UserControl
    {
        private string _chaineConnexion;
        public UserControlPraticiens(string chaineConenxion)
        {
            InitializeComponent();
            this._chaineConnexion = chaineConenxion;
            tbx_Num.Text = "1";
        }

        private void btn_prec_Click(object sender, RoutedEventArgs e)
        {
            CURS cs3 = new CURS(_chaineConnexion);
            string requete3 = "SELECT MIN(PRA_NUM) as MIN FROM praticien ;";
            cs3.ReqSelect(requete3);

            if (tbx_Num.Text == cs3.champ("MIN").ToString())
            {
                CURS cs4 = new CURS(_chaineConnexion);
                string requete4 = "SELECT MAX(PRA_NUM) as MAX FROM praticien ;";
                cs4.ReqSelect(requete4);
                tbx_Num.Text = cs4.champ("MAX").ToString();
                cs4.fermer();
                UserControl_Loaded(sender, e);
            }
            else
            {
                int num = Convert.ToInt32(tbx_Num.Text);
                num--;
                tbx_Num.Text = num.ToString();
                UserControl_Loaded(sender, e);
            }
            cs3.fermer();
        }

        private void btn_suiv_Click(object sender, RoutedEventArgs e)
        {
            CURS cs2 = new CURS(_chaineConnexion);
            string requete2 = "SELECT MAX(PRA_NUM) as MAX FROM praticien ;";
            cs2.ReqSelect(requete2);

            if (tbx_Num.Text == cs2.champ("MAX").ToString())
            {
                tbx_Num.Text = "1";
                UserControl_Loaded(sender, e);
            }
            else
            {
                int num = Convert.ToInt32(tbx_Num.Text);
                num++;
                tbx_Num.Text = num.ToString();
                UserControl_Loaded(sender, e);
            }
            cs2.fermer();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            CURS cs = new CURS(_chaineConnexion);
            string requete = "SELECT * FROM praticien WHERE PRA_NUM =" + tbx_Num.Text + ";";
            cs.ReqSelect(requete);

            tbx_Prenom.Text = cs.champ("PRA_PRENOM").ToString();
            tbx_Nom.Text = cs.champ("PRA_NOM").ToString();
            tbx_Adresse.Text = cs.champ("PRA_ADRESSE").ToString();
            tbx_CP.Text = cs.champ("PRA_CP").ToString();
            tbx_Noto.Text = cs.champ("PRA_COEFNOTORIETE").ToString();
            tbx_Ville.Text = cs.champ("PRA_VILLE").ToString();
            string code = cs.champ("TYP_CODE").ToString();
            cs.fermer();

            CURS cs1 = new CURS(_chaineConnexion);
            string requete1 = "SELECT TYP_LIEU FROM type_praticien WHERE TYP_CODE ='" + code + "';";
            cs1.ReqSelect(requete1);

            tbx_lieu.Text = cs1.champ("TYP_LIEU").ToString();
            cs1.fermer();
        }
    }
}
