using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice_SQL
{
    internal class Maison
    {
        private string id, categorie, ville, image, id_proprietaire;
        private double prix;
        //FAIRE UN CONSTRUCTEUR PAR DÉFAUT ET CHANGER TOUS. FAIRE UNE LISTEVIEW À LA PLACE DE CE QUE J'AI FAIT. LE TOUS DANS UNE PAGE SAUF AJOUTER.
        public Maison()
        {
            id = "";
            categorie = "";
            ville = "";
            image = "";
            prix = 0;
            id_proprietaire = "";
        }

        public Maison(string id, string categorie, string ville, string image, double prix, string id_proprietaire)
        {
            this.id = id;
            this.categorie = categorie;
            this.ville = ville;
            this.image = image;
            this.prix = prix;
            this.id_proprietaire = id_proprietaire;
        }

        public string Id { get => "ID: " + id; set => id = value; }
        public string Categorie { get => "Catégorie: " +  categorie; set => categorie = value; }
        public string Ville { get => "Ville: " + ville; set => ville = value; }
        public double Prix { get => prix; set => prix = value; }
        public string PrixString { get => "Prix: " + prix.ToString("C");  }
        public string Image { get => image; set => image = value; }
        public string Id_proprietaire { get => id_proprietaire; set => id_proprietaire = value; }
    }
}
