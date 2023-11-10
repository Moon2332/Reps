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

namespace Lab_SQL
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Ajouter : Page
    {
        public Ajouter()
        {
            this.InitializeComponent();
        }

        private async void btnAjouter_Click(object sender, RoutedEventArgs e)
        {
            int iCode = 0; double dPrix = 0;
            bool valide = true;

            /*
            if (tbxCode.Text == "")
            {
                tblCodeErr.Text = "Veuillez entrer un Code SVP";
                valide = false;
            }
            else
            {
                if (int.TryParse(tbxCode.Text, out iCode) == true)
                {
                    if (iCode < 100)
                    {
                        tblCodeErr.Text = "Entrez un code ayant 3 chiffres et plus";
                        valide = false;
                    }
                    else
                    {
                        tblCodeErr.Text = "";
                    }
                }
                else
                {
                    tblCodeErr.Text = "Entrez une valeur numérique";
                    valide = false;
                }
            }
            if (tbxModele.Text == "")
            {
                tblModeleErr.Text = "Veuillez entrer un modèle SVP";
                valide = false;
            }
            else
            {
                tblModeleErr.Text = "";
            }
            if (tbxMeuble.Text == "")
            {
                tblMeubleErr.Text = "Veuillez entrer un meuble SVP";
                valide = false;
            }
            else
            {
                tblMeubleErr.Text = "";
            }
            if (tbxCat.Text == "")
            {
                tblCatErr.Text = "Veuillez entrer une catégorie SVP";
                valide = false;
            }
            else
            {
                tblCatErr.Text = "";
            }
            if (tbxCouleur.Text == "")
            {
                tblCouleurErr.Text = "Veuillez entrer une couleur SVP";
                valide = false;
            }
            else
            {
                tblCouleurErr.Text = "";
            }
            if (tbxPrix.Text == "")
            {
                tblPrixErr.Text = "Veuillez entrer un Prix SVP";
                valide = false;
            }
            else
            {
                if (double.TryParse(tbxPrix.Text, out dPrix) == true)
                {
                   tblPrixErr.Text = ""; 
                }
                else
                {
                    tblPrixErr.Text = "Entrez une valeur numérique";
                    valide = false;
                }
            }
            */

            if (SingletonValidation.getInstance().isStringValide(tbxCode.Text) == false)
            {
                tblCodeErr.Text = "Veuillez entrer un Code SVP";
                valide = false;
            }
            else
            {
                if (SingletonValidation.getInstance().isCodeValide(tbxCode.Text) == false)
                {
                    if (SingletonValidation.getInstance().isCodeLengthValide(int.Parse(tbxCode.Text)) == false)
                    {
                        tblCodeErr.Text = "Entrez un code ayant 3 chiffres et plus";
                        valide = false;
                    }
                    else
                    {
                        tblCodeErr.Text = "";
                        iCode = int.Parse(tbxCode.Text);
                    }
                }
                else
                {
                    tblCodeErr.Text = "Entrez une valeur numérique";
                    valide = false;
                }
            }
            if (SingletonValidation.getInstance().isStringValide(tbxModele.Text) == false)
            {
                tblModeleErr.Text = "Veuillez entrer un modèle SVP";
                valide = false;
            }
            else
            {
                tblModeleErr.Text = "";
            }
            if (SingletonValidation.getInstance().isStringValide(tbxMeuble.Text) == false)
            {
                tblMeubleErr.Text = "Veuillez entrer un meuble SVP";
                valide = false;
            }
            else
            {
                tblMeubleErr.Text = "";
            }
            if (SingletonValidation.getInstance().isStringValide(tbxCat.Text) == false)
            {
                tblCatErr.Text = "Veuillez entrer une catégorie SVP";
                valide = false;
            }
            else
            {
                tblCatErr.Text = "";
            }
            if (SingletonValidation.getInstance().isStringValide(tbxCouleur.Text) == false)
            {
                tblCouleurErr.Text = "Veuillez entrer une couleur SVP";
                valide = false;
            }
            else
            {
                tblCouleurErr.Text = "";
            }
            if (SingletonValidation.getInstance().isStringValide(tbxPrix.Text) == false)
            {
                tblPrixErr.Text = "Veuillez entrer un Prix SVP";
                valide = false;
            }
            else
            {
                if (SingletonValidation.getInstance().isPrixValide(tbxPrix.Text) == false)
                {
                    tblPrixErr.Text = "";
                    dPrix = double.Parse(tbxPrix.Text);
                }
                else
                {
                    tblPrixErr.Text = "Entrez une valeur numérique";
                    valide = false;
                }
            }
            
            if (valide)
            {
                try
                {

                    SingletonBD.getInstance().ajouter(iCode, dPrix, tbxModele.Text, tbxMeuble.Text, tbxCat.Text, tbxCouleur.Text);

                    ContentDialog dialog = new ContentDialog();
                    dialog.XamlRoot = grilleAj.XamlRoot;

                    dialog.Title = "Ajouter une donnée";
                    dialog.CloseButtonText = "OK";
                    dialog.Content = "La donnée a été ajoutée dans la base de donnée.";

                    var result = await dialog.ShowAsync();

                    this.Frame.Navigate(typeof(Affichage));
                }
                catch (Exception ex)
                {
                    tblCodeErr.Text = ex.Message;
                }

                
            }
        }
    }
}
