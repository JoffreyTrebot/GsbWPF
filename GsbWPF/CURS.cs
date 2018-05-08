using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;
using MySql.Data.Types;

namespace GsbWPF
{

    public class CURS
    {
        Boolean fin;
        MySqlConnection maconnexion;
        MySqlCommand macommand;
        MySqlDataReader monreader;
        public CURS(string connec)
        {
            maconnexion = new MySqlConnection(connec);
            maconnexion.Open();
            monreader = null;

        }
        public MySqlConnection getMaconnexion()
        {

            return maconnexion;
        }
        public void ReqSelect(string req)
        {
            macommand = new MySqlCommand(req, maconnexion);
            monreader = macommand.ExecuteReader();
            fin = false;
            suivant();
        }
        public void fermer()
        {
            if (monreader != null)
                monreader.Close();
            maconnexion.Close();
        }
        public void suivant()
        {
            Boolean flag;

            if (!fin)
            {
                flag = monreader.Read();
                if (flag == true)
                    fin = false;
                else
                    fin = true;

            }



        }
        public void ReqAdmin(string req)
        {

            macommand = new MySqlCommand(req, maconnexion);
            macommand.ExecuteNonQuery();

        }
        public object champ(string nomChamp)
        {
            // if (!fin)
            return monreader[nomChamp];
            //  else
            // return null;
        }
        public Boolean Fin()
        {
            return fin;
        }
        public string Compter(string req)
        {

            macommand = new MySqlCommand(req, maconnexion);
            return macommand.ExecuteScalar().ToString();



        }
    }
}
