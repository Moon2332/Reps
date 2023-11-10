using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using MySql.Data.MySqlClient;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Exercice_SQL
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Ajouter : Page
    {
        MySqlConnection con = new MySqlConnection("Server=cours.cegep3r.info;Database=a2023_420326_gr01_2246072-tony-rayan-moundoubou-ndoping;Uid=2246072;Pwd=2246072;");

        public Ajouter()
        {
            this.InitializeComponent();
        }

        private void btnAjouter_Click(object sender, RoutedEventArgs e)
        {
            string categorie = "";
            double prix = 0;
            string ville = "";
            string id = "";
            string image = "";
            string id_proprietaire = "";
            bool valide = true;

            try
            {
                if (tbxID.Text == "")
                {
                    tblIDErr.Text = "Veuillez entrer un ID SVP";
                    valide = false;
                }
                else
                {
                    if (tbxID.Text.Length > 10)
                    {
                        tblIDErr.Text = "L'ID ne peut pas dépasser 10 caractères";
                        valide = false;
                    }
                    else
                    {
                        tblIDErr.Text = "";
                        id = tbxID.Text;
                    }
                }
                
                if (tbxImg.Text == "")
                {
                    tblImgErr.Text = "Veuillez entrer un URL SVP";
                    valide = false;
                }
                else
                {
                    tblImgErr.Text = "";
                    image = tbxImg.Text;
                }
                if (tbxPrix.Text == "")
                {
                    tblPrixErr.Text = "Veuillez entrer un prix SVP";
                    valide = false;
                }
                else
                {

                    if (tbxPrix.Text.Length > 9)
                    {
                        tblPrixErr.Text = "Le prix ne peut pas dépasser 999999.99$";
                        valide = false;
                    }
                    else
                    {
                        if (double.TryParse(tbxPrix.Text, out prix) == true)
                        {
                            prix = int.Parse(tbxPrix.Text);
                            tblPrixErr.Text = "";
                        }
                        else
                        {
                            tblPrixErr.Text = "Entrez une valeur numérique";
                            valide = false;
                        }
                    }
                }
                if (CbbxCat.SelectedIndex < 0)
                {
                    tblCatErr.Text = "Veuillez choisir une catégorie SVP";
                    valide = false;
                }
                else
                {
                    tblCatErr.Text = "";
                    categorie = CbbxCat.SelectedItem.ToString();
                }
                if(tbxVille.Text == "")
                {
                    tblVilleErr.Text = "Veuillez entrer une ville SVP";
                    valide = false;
                }
                else
                {
                    if (tbxVille.Text.Length > 50)
                    {
                        tblVilleErr.Text = "La ville ne peut pas dépasser 50 caractères";
                        valide = false;
                    }
                    else
                    {
                        tblVilleErr.Text = "";
                        ville = tbxVille.Text;
                    }
                }
                if(tbxIdProprietaire.Text == "")
                {
                    tblIdProprietaireErr.Text = "Veuillez entrer l'ID du propriétaire";
                    valide = false;
                }
                else
                {
                    if(tbxIdProprietaire.Text.Length > 10)
                    {
                        tblIdProprietaireErr.Text = "L'ID du propriétaire ne peut pas dépasser 10 caractères";
                    }
                }

                if (valide == true)
                {
                    SingletonBD.getInstance().ajouter(id, categorie, ville, image, prix, id_proprietaire);

                    this.Frame.Navigate(typeof(Affichage));
                }
            }
            catch (Exception ex)
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }
        }
    }
}
