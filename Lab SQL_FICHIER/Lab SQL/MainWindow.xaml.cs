using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
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
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        MySqlConnection con = new MySqlConnection("Server=cours.cegep3r.info;Database=2246072-tony-rayan-moundoubou-ndoping;Uid=2246072;Pwd=2246072;");

        public MainWindow()
        {
            this.InitializeComponent();
            SingletonFenetre.getInstance().Fenetre = this;
            mainFrame.Navigate(typeof(Lecture));
        }

        private void navView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            var item = (NavigationViewItem)args.SelectedItem;

            switch (item.Name)
            {
                case "Ajouter":
                    this.mainFrame.Navigate(typeof(Ajouter));
                    break;
                case "Retour":
                    this.mainFrame.Navigate(typeof(Affichage));
                    break;
                case "Lecture":
                    this.mainFrame.Navigate(typeof(Lecture));
                    break;
                case "Save":
                    this.mainFrame.Navigate(typeof(Save));
                    break;
            }

        }
    }
}
