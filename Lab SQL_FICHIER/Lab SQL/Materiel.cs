using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_SQL
{
    internal class Materiel
    {
        private int code; private double prix;
        private string modele, meuble, categorie, couleur;

        public Materiel()
        {
            code = 0;
            prix = 0;
            modele = "";
            meuble = "";
            categorie = "";
            couleur = "";
        }

        public Materiel(int code, double prix, string modele, string meuble, string categorie, string couleur)
        {
            this.code = code;
            this.prix = prix;
            this.modele = modele;
            this.meuble = meuble;
            this.categorie = categorie;
            this.couleur = couleur;
        }

        public int Code { get => code; set => code = value; }
        public string strCode { get => "Code: " + code;}

        public double Prix { get => prix; set => prix = value; }
        public string strPrix { get => "Prix: " + prix.ToString("C"); }

        public string Modele { get => modele; set => modele = value; }
        public string strModele { get => "Modèle: " + modele; set => modele = value; }

        public string Meuble { get => meuble; set => meuble = value; }
        public string strMeuble { get => "Meuble: " + meuble; set => meuble = value; }

        public string Categorie { get => categorie; set => categorie = value; }
        public string strCategorie { get => "Catégorie: " + categorie; set => categorie = value; }

        public string Couleur { get => couleur; set => couleur = value; }
        public string strCouleur { get => "Couleur: " + couleur; set => couleur = value; }
        public string stringCSV()
        {
            return code + ";" + modele + ";" + meuble + ";" + categorie + ";" + couleur + ";" + prix;
        }
    }
}
