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

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Exercice_SQL
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AjouterProprio : Page
    {
        public AjouterProprio()
        {
            this.InitializeComponent();
        }

        private void btnAjouter_Click(object sender, RoutedEventArgs e)
        {
            string id = "";
            string prenom = "";
            string nom = "";
            bool valide = true;

            if(tbxID.Text == "")
            {
                tblIDErr.Text = "Veuillez entrer un ID";
                valide = false;
            }
            else if(tbxID.Text.Length > 10){
                tblIDErr.Text = "L'ID ne peut pas dépasser 10 caractères";
                valide = false;
            }
            else
            {
                tblIDErr.Text = "";
                id = tbxID.Text;
            }

            if(tbxPrenom.Text == "")
            {
                tblPrenomErr.Text = "Veuillez entrer un prénom";
                valide = false;
            }
            else if(tbxPrenom.Text.Length > 20) 
            {
                tblPrenomErr.Text = "Le prénom ne peut pas dépasser 20 caractères";
                valide = false;
            }
            else
            {
                tblPrenomErr.Text = "";
                prenom = tbxPrenom.Text;
            }

            if(tbxNom.Text == "")
            {
                tblNomErr.Text = "Veuillez entrer un nom";
                valide = false;
            }
            else if(tbxNom.Text.Length > 20)
            {
                tblNomErr.Text = "Le nom ne peut pas dépasser 20 caractères";
                valide = false;
            }
            else
            {
                tblNomErr.Text = "";
                nom = tbxNom.Text;
            }

            if (valide)
            {

            }
        }
    }
}
