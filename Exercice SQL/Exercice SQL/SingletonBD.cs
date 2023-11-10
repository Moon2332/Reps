using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice_SQL
{
    internal class SingletonBD
    {
        static SingletonBD instance = null;

        MySqlConnection con;

        ObservableCollection<Maison> listeMaison;

        public SingletonBD()
        {
            con = new MySqlConnection("Server=cours.cegep3r.info;Database=a2023_420326_gr01_2246072-tony-rayan-moundoubou-ndoping;Uid=2246072;Pwd=2246072;");
            listeMaison = new ObservableCollection<Maison>();
        }

        public static SingletonBD getInstance()
        {
            if (instance == null)
                instance = new SingletonBD();

            return instance;
        }

        public void ajouter(string id, string categorie, string ville, string image, double prix, string id_proprietaire)
        {
            try
            {
                MySqlCommand commande = new MySqlCommand("p_insert_maison");
                commande.Connection = con;
                commande.CommandType = System.Data.CommandType.StoredProcedure;

                commande.Parameters.AddWithValue("@id", id);
                commande.Parameters.AddWithValue("@categorie", categorie);
                commande.Parameters.AddWithValue("@prix", prix);
                commande.Parameters.AddWithValue("@ville", ville);
                commande.Parameters.AddWithValue("@image", image);
                commande.Parameters.AddWithValue("@id_proprietaire", id_proprietaire);

                con.Open();
                commande.Prepare();
                commande.ExecuteNonQuery();

                con.Close();
            }
            catch (MySqlException ex)
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }
        }

        public void clear()
        {
            listeMaison.Clear();
        }

        public ObservableCollection<Maison> getListeRecherche(string s)
        {
            listeMaison.Clear();

            try
            {
                MySqlCommand commande = new MySqlCommand("p_recherche_maison");
                commande.Connection = con;
                commande.CommandType = System.Data.CommandType.StoredProcedure;

                commande.Parameters.AddWithValue("@val", s);

                con.Open();

                MySqlDataReader r = commande.ExecuteReader();

                while (r.Read())
                {
                    double prix = (double)r["prix"];
                    string id = (string)r["id"];
                    string ville = (string)r["ville"];
                    string categorie = (string)r["categorie"];
                    string image = (string)r["image"];
                    string id_proprietaire = (string)r["id_proprietaire"];

                    Maison maison = new Maison
                    {
                        Id = id,
                        Ville = ville,
                        Categorie = categorie,
                        Prix = prix,
                        Image = image,
                        Id_proprietaire = id_proprietaire
                    };

                    listeMaison.Add(maison);
                }

                r.Close();
                con.Close();
            }
            catch (MySqlException ex)
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }
            return listeMaison;
        }

        public ObservableCollection<Maison> getListeMaison()
        {
            listeMaison.Clear();

            try
            {
                MySqlCommand commande = new MySqlCommand("p_get_maison");
                commande.Connection = con;
                commande.CommandType = System.Data.CommandType.StoredProcedure;

                con.Open();

                MySqlDataReader r = commande.ExecuteReader();

                while (r.Read())
                {
                    double prix = (double)r["prix"];
                    string id = (string)r["id"];
                    string ville = (string)r["ville"];
                    string categorie = (string)r["categorie"];
                    string image = (string)r["image"];
                    string id_proprietaire = (string)r["id_proprietaire"];

                    Maison maison = new Maison
                    {
                        Id = id,
                        Ville = ville,
                        Categorie = categorie,
                        Prix = prix,
                        Image = image,
                        Id_proprietaire = id_proprietaire
                    };

                    listeMaison.Add(maison);
                }

                r.Close();
                con.Close();
            }
            catch (MySqlException ex)
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();

            }
            return listeMaison;
        }

        public ObservableCollection<string> getlisteMaisonProp(string s)
        {
            ObservableCollection<string> liste = new ObservableCollection<string>();

            try
            {
                MySqlCommand commande = new MySqlCommand("p_get_maison_prop");
                commande.Connection = con;
                commande.CommandType = System.Data.CommandType.StoredProcedure;

                commande.Parameters.AddWithValue("@val", s);

                con.Open();

                MySqlDataReader r = commande.ExecuteReader();

                while (r.Read())
                {
                    string nom = (string)r["nom"];

                    liste.Add(nom);
                }

                r.Close();
                con.Close();
            }
            catch (MySqlException ex)
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();

            }
            return liste;
        }
    }
}
