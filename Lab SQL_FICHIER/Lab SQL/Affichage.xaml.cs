using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using MySql.Data.MySqlClient;
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
    public sealed partial class Affichage : Page
    {
        MySqlConnection con = new MySqlConnection("Server=cours.cegep3r.info;Database=2246072-tony-rayan-moundoubou-ndoping;Uid=2246072;Pwd=2246072;");
        int iPosition = -1;
        public Affichage()
        {
            this.InitializeComponent();
            lvliste.ItemsSource = SingletonBD.getInstance().getlisteMateriel();
        }

        private void lvliste_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            iPosition = lvliste.SelectedIndex;

            this.Frame.Navigate(typeof(Mod_Sup), iPosition);
        }


    }
}
