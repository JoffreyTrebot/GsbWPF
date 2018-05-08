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
    /// Logique d'interaction pour DetailsPraticien.xaml
    /// </summary>
    public partial class DetailsPraticien : Window
    {
        private string _chaineConnexion;
        public DetailsPraticien(string chaineConnexion,  string num)
        {
            InitializeComponent();
            tbx_Num.Text = num;
            this._chaineConnexion = chaineConnexion;
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
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

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
