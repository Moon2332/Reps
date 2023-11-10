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
    public sealed partial class Lecture : Page
    {
        public Lecture()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

        }

        private async void btLire_Click(object sender, RoutedEventArgs e)
        {
            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            picker.FileTypeFilter.Add(".csv");

            var hWnd = WinRT.Interop.WindowNative.GetWindowHandle(SingletonFenetre.getInstance().Fenetre);
            WinRT.Interop.InitializeWithWindow.Initialize(picker, hWnd);

            Windows.Storage.StorageFile monFichier = await picker.PickSingleFileAsync();


            if (monFichier != null)
            {
                var lignes = await Windows.Storage.FileIO.ReadLinesAsync(monFichier);

                foreach (var ligne in lignes)
                {
                    var v = ligne.Split(";");
                    SingletonBD.getInstance().ajouter(int.Parse(v[0]), double.Parse(v[5]), v[1], v[2], v[3], v[4]);
                }

                this.Frame.Navigate(typeof(Affichage));
            }
            else
            {
                ContentDialog dialog = new ContentDialog();
                dialog.XamlRoot = grilleLecture.XamlRoot;

                dialog.Title = "Lecture du fichier .csv";
                dialog.CloseButtonText = "OK";
                dialog.Content = "Aucun fichier selectionné";

                var result = await dialog.ShowAsync();
            }
            
        }
    }
}
