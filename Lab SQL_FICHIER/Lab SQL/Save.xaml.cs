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
    public sealed partial class Save : Page
    {
        public Save()
        {
            this.InitializeComponent();
        }

        private async void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var picker = new Windows.Storage.Pickers.FileSavePicker();

            var hWnd = WinRT.Interop.WindowNative.GetWindowHandle(SingletonFenetre.getInstance().Fenetre);
            WinRT.Interop.InitializeWithWindow.Initialize(picker, hWnd);

            picker.SuggestedFileName = "Liste de matériaux";
            picker.FileTypeChoices.Add("Fichier texte", new List<string>() { ".csv" });

            Windows.Storage.StorageFile monFichier = await picker.PickSaveFileAsync();

            List<Materiel> liste = new List<Materiel>();

            foreach (Materiel a in SingletonBD.getInstance().getlisteMateriel())
            {
                liste.Add(a);
            }

            if (monFichier != null)
            {
                await Windows.Storage.FileIO.WriteLinesAsync(monFichier, liste.ConvertAll(x => x.stringCSV()), Windows.Storage.Streams.UnicodeEncoding.Utf8);

                ContentDialog dialog = new ContentDialog();
                dialog.XamlRoot = grilleSave.XamlRoot;

                dialog.Title = "Sauvegarde";
                dialog.CloseButtonText = "OK";
                dialog.Content = "Les données ont été sauvegardées";

                var result = await dialog.ShowAsync();
            }
            else
            {
                ContentDialog dialog = new ContentDialog();
                dialog.XamlRoot = grilleSave.XamlRoot;

                dialog.Title = "Sauvegarde";
                dialog.CloseButtonText = "OK";
                dialog.Content = "Les données n'ont pas été sauvegardées";

                var result = await dialog.ShowAsync();
            }
                
        }
    }
}
