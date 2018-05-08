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
    /// Logique d'interaction pour UserControlVisiteurs.xaml
    /// </summary>
    public partial class UserControlVisiteurs : UserControl
    {
        private List<string> _list = new List<string>();
        private string _chaineConnexion;
        public UserControlVisiteurs(string chaineConnexion)
        {
            InitializeComponent();
            this._chaineConnexion = chaineConnexion;
            tbx_num.Text = "a131";
            CURS cs1 = new CURS(chaineConnexion);
            string requete1 = "SELECT collaborateur.COL_MATRICULE FROM collaborateur INNER JOIN visiteur ON visiteur.COL_MATRICULE = collaborateur.COL_MATRICULE ORDER BY visiteur.COL_MATRICULE;";
            cs1.ReqSelect(requete1);
            while (!cs1.Fin())
            {
                _list.Add(cs1.champ("COL_MATRICULE").ToString());
                cs1.suivant();
            }
            cs1.fermer();
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
            string requete2 = "SELECT * FROM collaborateur INNER JOIN visiteur ON visiteur.COL_MATRICULE = collaborateur.COL_MATRICULE ";
            requete2 += "INNER JOIN labo ON collaborateur.LAB_CODE = labo.LAB_CODE ";
            requete2 += "LEFT JOIN secteur ON collaborateur.SEC_CODE = secteur.SEC_CODE ";
            requete2 += "WHERE collaborateur.COL_MATRICULE ='" + tbx_num.Text + "' ;";
            cs2.ReqSelect(requete2);

            tbx_Nom.Text = cs2.champ("COL_NOM").ToString();
            tbx_Prenom.Text = cs2.champ("COL_PRENOM").ToString();
            tbx_Adresse.Text = cs2.champ("COL_ADRESSE").ToString();
            tbx_CP.Text = cs2.champ("COL_CP").ToString();
            tbx_secteur.Text = cs2.champ("SEC_LIBELLE").ToString();
            tbx_Ville.Text = cs2.champ("COL_VILLE").ToString();
            tbx_labo.Text = cs2.champ("LAB_CHEFVENTE").ToString();
            tbx_num.Text = cs2.champ("COL_MATRICULE").ToString();
            cs2.fermer();
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
    }
}
