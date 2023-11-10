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
    internal class SingletonProp
    {
        static SingletonProp instance = null;

        MySqlConnection con;

        ObservableCollection<Proprietaire> listeProp;

        public SingletonProp()
        {
            con = new MySqlConnection("Server=cours.cegep3r.info;Database=a2023_420326_gr01_2246072-tony-rayan-moundoubou-ndoping;Uid=2246072;Pwd=2246072;");
            listeProp = new ObservableCollection<Proprietaire>();
        }

        public static SingletonProp getInstance()
        {
            if (instance == null)
                instance = new SingletonProp();

            return instance;
        }

        public void ajouter(string id, string nom, string prenom, string image, double prix)
        {
            try
            {
                MySqlCommand commande = new MySqlCommand("p_insert_prop");
                commande.Connection = con; 
                commande.CommandType = System.Data.CommandType.StoredProcedure;

                commande.Parameters.AddWithValue("@id", id);
                commande.Parameters.AddWithValue("@nom", nom);
                commande.Parameters.AddWithValue("@prenom", prenom);

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
            listeProp.Clear();
        }

        public ObservableCollection<Proprietaire> getListeRecherche(string s)
        {
            listeProp.Clear();

            try
            {
                MySqlCommand commande = new MySqlCommand("p_recherche_prop");
                commande.Connection = con;
                commande.CommandType = System.Data.CommandType.StoredProcedure;
                commande.Parameters.AddWithValue("val", s);

                con.Open();

                MySqlDataReader r = commande.ExecuteReader();

                while (r.Read())
                {
                    string id = (string)r["id"];
                    string nom = (string)r["nom"];
                    string prenom = (string)r["prenom"];

                    Proprietaire prop = new Proprietaire
                    {
                        Id = id,
                        Nom = nom,
                        Prenom = prenom
                    };

                    listeProp.Add(prop);
                }

                r.Close();
                con.Close();
            }
            catch (MySqlException ex)
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }
            return listeProp;
        }

        public ObservableCollection<Proprietaire> getlisteProp()
        {
            listeProp.Clear();

            try
            {
                MySqlCommand commande = new MySqlCommand("p_get_prop");
                commande.Connection = con;
                commande.CommandType = System.Data.CommandType.StoredProcedure;

                con.Open();

                MySqlDataReader r = commande.ExecuteReader();

                while (r.Read())
                {
                    string id = (string)r["id"];
                    string nom = (string)r["nom"];
                    string prenom = (string)r["prenom"];

                    Proprietaire prop = new Proprietaire
                    {
                        Id = id,
                        Nom = nom,
                        Prenom = prenom
                    };

                    listeProp.Add(prop);
                }

                r.Close();
                con.Close();
            }
            catch (MySqlException ex)
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();

            }
            return listeProp;
        }

        public ObservableCollection<string> getlisteMaisonProp(string s)
        {
            ObservableCollection<string> liste = new ObservableCollection<string>();

            try
            {
                MySqlCommand commande = new MySqlCommand("p_get_prop_all");
                commande.Connection = con;
                commande.CommandType = System.Data.CommandType.StoredProcedure;

                commande.Parameters.AddWithValue("@val", s);

                con.Open();

                MySqlDataReader r = commande.ExecuteReader();

                while (r.Read())
                {
                    string id_m = (string)r["maison"];

                    liste.Add(id_m);
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

        public ObservableCollection<string> getlisteMaisonProp(string s)
        {
            ObservableCollection<string> liste = new ObservableCollection<string>();

            try
            {
                MySqlCommand commande = new MySqlCommand("p_get_prop_all");
                commande.Connection = con;
                commande.CommandType = System.Data.CommandType.StoredProcedure;

                commande.Parameters.AddWithValue("@val", s);

                con.Open();

                MySqlDataReader r = commande.ExecuteReader();

                while (r.Read())
                {
                    string id_m = (string)r["maison"];

                    liste.Add(id_m);
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
