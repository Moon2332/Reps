using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice_SQL
{
    internal class Maison
    {
        private string id, categorie, ville, image;
        private double prix;
        //FAIRE UN CONSTRUCTEUR PAR DÉFAUT ET CHANGER TOUS. FAIRE UNE LISTEVIEW À LA PLACE DE CE QUE J'AI FAIT. LE TOUS DANS UNE PAGE SAUF AJOUTER.
        public Maison()
        {
            id = "";
            categorie = "";
            ville = "";
            image = "";
            prix = 0;
        }

        public Maison(string id, string categorie, string ville, string image, double prix)
        {
            this.id = id;
            this.categorie = categorie;
            this.ville = ville;
            this.image = image;
            this.prix = prix;
        }

        public string Id { get => "ID: " + id; set => id = value; }
        public string Categorie { get => "Catégorie: " +  categorie; set => categorie = value; }
        public string Ville { get => "Ville: " + ville; set => ville = value; }
        public double Prix { get => prix; set => prix = value; }
        public string PrixString { get => "Prix: " + prix.ToString("C");  }
        public string Image { get => image; set => image = value; }
    }
}
