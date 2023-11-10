using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Imaging;
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
    public sealed partial class Mod_Sup : Page
    {
        public Mod_Sup()
        {
            this.InitializeComponent();
        }

        int iPosition = -1;
        Materiel a;

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is not null)
            {
                iPosition = (int)e.Parameter;
                if (iPosition >= 0)
                {
                    a = SingletonBD.getInstance().getlisteMateriel()[iPosition];

                    tbxCode.Text = a.Code.ToString();
                    tbxModele.Text = a.Modele.ToString();
                    tbxMeuble.Text = a.Meuble.ToString();
                    tbxCat.Text = a.Categorie.ToString();
                    tbxCouleur.Text = a.Couleur.ToString();
                    tbxPrix.Text = a.Prix.ToString();
                }
            }
        }

        private async void btnModifier_Click(object sender, RoutedEventArgs e)
        {

            int iCode = 0; double dPrix = 0;
            bool valide = true;

            iCode = int.Parse(tbxCode.Text);
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
                ContentDialog dialog = new ContentDialog();
                dialog.XamlRoot = mod_sup_grille.XamlRoot;

                dialog.Title = "Modifier une donnée";
                dialog.PrimaryButtonText = "Oui";
                dialog.CloseButtonText = "Annuler";

                dialog.DefaultButton = ContentDialogButton.Close;

                dialog.Content = "Voulez-vous vraiment modifier cette donnée ?";

                ContentDialogResult result = await dialog.ShowAsync();

                if (result == ContentDialogResult.Primary)
                {
                    SingletonBD.getInstance().modifier(iCode, dPrix, tbxModele.Text, tbxMeuble.Text, tbxCat.Text, tbxCouleur.Text);

                    dialog.Title = "Modifier une donnée";
                    dialog.PrimaryButtonText = null;
                    dialog.CloseButtonText = "OK";
                    dialog.Content = "La donnée a été modifiée dans la base de donnée.";

                    var ans = await dialog.ShowAsync();
                }
                else 
                {
                    dialog.Title = "Modifier une donnée";
                    dialog.PrimaryButtonText = null;
                    dialog.CloseButtonText = "OK";
                    dialog.Content = "La donnée n'a été modifiée dans la base de donnée.";

                    var ans = await dialog.ShowAsync();
                }

                this.Frame.Navigate(typeof(Affichage));
            }
        }

        private async void btnSupprimer_Click(object sender, RoutedEventArgs e)
        {
            ContentDialog dialog = new ContentDialog();
            dialog.XamlRoot = mod_sup_grille.XamlRoot;

            dialog.Title = "Supprimer une donnée";
            dialog.PrimaryButtonText = "Oui";
            dialog.CloseButtonText = "Annuler";

            dialog.DefaultButton = ContentDialogButton.Close;

            dialog.Content = "Voulez-vous vraiment supprimer cette donnée ?";

            ContentDialogResult result = await dialog.ShowAsync();

            if (result == ContentDialogResult.Primary)
            {
                int iCode = SingletonBD.getInstance().getCode(iPosition);
                SingletonBD.getInstance().supprimer(iCode);

                dialog.Title = "Modifier une donnée";
                dialog.PrimaryButtonText = null;
                dialog.CloseButtonText = "OK";
                dialog.Content = "La donnée a été supprimée dans la base de donnée.";

                var ans = await dialog.ShowAsync();
            }
            else
            {
                dialog.Title = "Modifier une donnée";
                dialog.PrimaryButtonText = null;
                dialog.CloseButtonText = "OK";
                dialog.Content = "La donnée n'a été supprimée dans la base de donnée.";

                var ans = await dialog.ShowAsync();
            }

            this.Frame.Navigate(typeof(Affichage));
        }
    }
}
