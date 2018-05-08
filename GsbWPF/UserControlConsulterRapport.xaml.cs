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
    /// Logique d'interaction pour UserControlConsulterRapport.xaml
    /// </summary>
    public partial class UserControlConsulterRapport : UserControl
    {
        private string _chaineConnexion;
        private List<string> _list = new List<string>();
        public UserControlConsulterRapport(string chaineConnexion)
        {
            InitializeComponent();
            this._chaineConnexion = chaineConnexion;
            CURS cs6 = new CURS(_chaineConnexion);
            string requete6 = "SELECT MAX(RAP_NUM) as MAX FROM rapport_visite ;";
            cs6.ReqSelect(requete6);
            tbx_NRapport.Text = cs6.champ("MAX").ToString();
            cs6.fermer();

            CURS cs1 = new CURS(_chaineConnexion);
            string requete1 = "SELECT RAP_NUM FROM rapport_visite ORDER BY RAP_NUM;";
            cs1.ReqSelect(requete1);
            while (!cs1.Fin())
            {
                _list.Add(cs1.champ("RAP_NUM").ToString());
                cs1.suivant();
            }
            cs1.fermer();
        }

        private void btn_prec_Click(object sender, RoutedEventArgs e)
        {
            int i;
            for (i = _list.Count() - 1; i > -1; i--)
            {
                if (i == 0)
                {
                    i = _list.Count() - 1;
                    tbx_NRapport.Text = _list[i];
                    UserControl_Loaded(sender, e);
                    break;

                }
                else
                {
                    if (_list[i] == tbx_NRapport.Text)
                    {
                        i = i - 1;
                        tbx_NRapport.Text = _list[i];
                        UserControl_Loaded(sender, e);
                        break;

                    }
                }
            }
        }

        private void btn_suiv_Click(object sender, RoutedEventArgs e)
        {
            int i;
            for (i = 0; i < _list.Count(); i++)
            {
                if (i == _list.Count() - 1)
                {
                    i = 0;
                    tbx_NRapport.Text = _list[i];
                    UserControl_Loaded(sender, e);
                    break;

                }
                else
                {
                    if (_list[i] == tbx_NRapport.Text)
                    {
                        i = i + 1;
                        tbx_NRapport.Text = _list[i];
                        UserControl_Loaded(sender, e);
                        break;

                    }
                }
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            CURS cs2 = new CURS(_chaineConnexion);
            string requete2 = "SELECT * FROM rapport_visite INNER JOIN praticien ON rapport_visite.PRA_NUM = praticien.PRA_NUM ";
            requete2 += "LEFT JOIN motiver ON rapport_visite.RAP_NUM = motiver.RAP_NUM ";
            requete2 += "LEFT JOIN motif ON motif.MOTIF_CODE = motiver.MOTIF_CODE ";
            requete2 += "WHERE rapport_visite.RAP_NUM = " + tbx_NRapport.Text + ";";
            cs2.ReqSelect(requete2);

            tbx_praticien.Text = cs2.champ("PRA_NOM").ToString();
            tbx_date.Text = cs2.champ("RAP_DATE").ToString();
            tbx_motif.Text = cs2.champ("MOTIF_LIBELLE").ToString();

            TextRange textrange = new TextRange(
                rtbx_bilan.Document.ContentStart,
                rtbx_bilan.Document.ContentEnd
                );

            textrange.Text = cs2.champ("RAP_BILAN").ToString();
            cs2.fermer();
        }
    }
}
