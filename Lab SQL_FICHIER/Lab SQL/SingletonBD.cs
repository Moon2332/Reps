using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_SQL
{
    internal class SingletonBD
    {
        ObservableCollection<Materiel> listeMateriel = new ObservableCollection<Materiel>();
        static SingletonBD instance = null;
        MySqlConnection con;

        public SingletonBD()
        {
            con = new MySqlConnection("Server=cours.cegep3r.info;Database=2246072-tony-rayan-moundoubou-ndoping;Uid=2246072;Pwd=2246072;");
            listeMateriel = new ObservableCollection<Materiel>();
        }

        public static SingletonBD getInstance()
        {
            if (instance == null)
                instance = new SingletonBD();

            return instance;
        }

        public ObservableCollection<Materiel> getlisteMateriel()
        {
            listeMateriel.Clear();

            try
            {
                MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;
                commande.CommandText = "SELECT * FROM materiel";

                con.Open();

                MySqlDataReader r = commande.ExecuteReader();

                while (r.Read())
                {
                    int code = (int)r["code"];
                    string modele = (string)r["modele"];
                    string meuble = (string)r["meuble"];
                    string cat = (string)r["categorie"];
                    string couleur = (string)r["couleur"];
                    double prix = (double)r["prix"];

                    Materiel mat = new Materiel
                    {
                        Code = code,
                        Modele = modele,
                        Meuble = meuble,
                        Categorie = cat,
                        Couleur = couleur,
                        Prix = prix
                    };

                    listeMateriel.Add(mat);
                }

                r.Close();
                con.Close();
            }
            catch (MySqlException ex)
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }
            
            return listeMateriel;
        }

        public int getCode(int position)
        {
            int a = listeMateriel[position].Code;

            return a;
        }

        public void verifier(int code)
        {
            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = "SELECT code FROM materiel";

            con.Open();

            MySqlDataReader r = commande.ExecuteReader();

            while (r.Read())
            {
                int i = (int)r["code"];

                if (code == i)
                {
                    r.Close();
                    con.Close();
                    throw new Exception("ERREUR!!! Code existe déjà dans la base de données.\nVeuillez entrer un nouveau code");
                }
            }
            r.Close ();
            con.Close();
        }

        public void ajouter(int code, double prix, string modele, string meuble, string categorie, string couleur)
        {
            try
            {
                SingletonBD.getInstance().verifier(code);

                MySqlCommand commande = new MySqlCommand();
                commande.Connection = con; 
                commande.CommandText = "INSERT INTO materiel VALUES (@code, @modele, @meuble, @categorie, @couleur, @prix)";

                commande.Parameters.AddWithValue("@code", code);
                commande.Parameters.AddWithValue("@modele", modele);
                commande.Parameters.AddWithValue("@meuble", meuble);
                commande.Parameters.AddWithValue("@categorie", categorie);
                commande.Parameters.AddWithValue("@couleur", couleur);
                commande.Parameters.AddWithValue("@prix", prix);

                con.Open();

                commande.Prepare();
                commande.ExecuteNonQuery();

                con.Close();

                SingletonBD.getInstance().getlisteMateriel();
            }
            catch (MySqlException ex)
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }
        }

        public void modifier(int code, double prix, string modele, string meuble, string categorie, string couleur)
        {
            try
            {
                MySqlCommand commande = new MySqlCommand();
                commande.Connection = con; 
                commande.CommandText = "UPDATE materiel SET modele = @modele, meuble = @meuble, categorie = @categorie, couleur = @couleur, prix = @prix WHERE code = @code";

                commande.Parameters.AddWithValue("@code", code);
                commande.Parameters.AddWithValue("@modele", modele);
                commande.Parameters.AddWithValue("@meuble", meuble);
                commande.Parameters.AddWithValue("@categorie", categorie);
                commande.Parameters.AddWithValue("@couleur", couleur);
                commande.Parameters.AddWithValue("@prix", prix);

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

        public void supprimer(int code)
        {
            try
            {
                MySqlCommand commande = new MySqlCommand();
                commande.Connection = con; commande.CommandText = "DELETE FROM materiel WHERE code = @code";

                commande.Parameters.AddWithValue("@code", code);

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
    }
}
