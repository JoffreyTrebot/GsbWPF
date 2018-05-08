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
    /// Logique d'interaction pour UserControlMedicaments.xaml
    /// </summary>
    public partial class UserControlMedicaments : UserControl
    {
        private List<string> _list = new List<string>();
        private string _chaineConnexion;
        public UserControlMedicaments(string chaineConnexion)
        {
            InitializeComponent();
            this._chaineConnexion = chaineConnexion;
            tbx_num.Text = "3MYC7";
            CURS cs1 = new CURS(chaineConnexion);
            string requete1 = "SELECT MED_DEPOTLEGAL FROM medicament;";
            cs1.ReqSelect(requete1);
            while (!cs1.Fin())
            {
                _list.Add(cs1.champ("MED_DEPOTLEGAL").ToString());
                cs1.suivant();
            }
            cs1.fermer();
        }

        private void btn_suiv_Click(object sender, RoutedEventArgs e)
        {
            int i;
            for (i = 0; i < _list.Count(); i++)
            {
                if (i == _list.Count() - 1)
                {
                    i = 0;
                    tbx_num.Text = _list[i];
                    UserControl_Loaded(sender, e);
                    break;

                }
                else
                {
                    if (_list[i] == tbx_num.Text)
                    {
                        i = i + 1;
                        tbx_num.Text = _list[i];
                        UserControl_Loaded(sender, e);
                        break;

                    }
                }
            }
        }

        private void btn_prec_Click(object sender, RoutedEventArgs e)
        {
            int i;
            for (i = _list.Count() - 1; i > 0; i--)
            {
                if (i == 1)
                {
                    i = _list.Count() - 1;
                    tbx_num.Text = _list[i];
                    UserControl_Loaded(sender, e);
                    break;

                }
                else
                {
                    if (_list[i] == tbx_num.Text)
                    {
                        i = i - 1;
                        tbx_num.Text = _list[i];
                        UserControl_Loaded(sender, e);
                        break;

                    }
                }
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            CURS cs2 = new CURS(_chaineConnexion);
            string requete2 = "SELECT * FROM medicament ";
            requete2 += "INNER JOIN famille ON medicament.FAM_CODE = famille.FAM_CODE ";
            requete2 += "WHERE medicament.MED_DEPOTLEGAL ='" + tbx_num.Text + "' ;";
            cs2.ReqSelect(requete2);

            tbx_Nom.Text = cs2.champ("MED_NOMCOMMERCIAL").ToString();
            tbx_fam.Text = cs2.champ("FAM_CODE").ToString();
            tbx_compo.Text = cs2.champ("MED_COMPOSITION").ToString();
            tbx_effet.Text = cs2.champ("MED_EFFETS").ToString();
            tbx_indic.Text = cs2.champ("MED_CONTREINDIC").ToString();
            tbx_prix.Text = cs2.champ("MED_PRIXECHANTILLON").ToString();
            tbx_num.Text = cs2.champ("MED_DEPOTLEGAL").ToString();
            cs2.fermer();
        }
    }
}
