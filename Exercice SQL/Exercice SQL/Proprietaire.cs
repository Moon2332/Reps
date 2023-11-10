using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice_SQL
{
    internal class Proprietaire
    {
        private string id, nom, prenom;
        //FAIRE UN CONSTRUCTEUR PAR DÉFAUT ET CHANGER TOUS. FAIRE UNE LISTEVIEW À LA PLACE DE CE QUE J'AI FAIT. LE TOUS DANS UNE PAGE SAUF AJOUTER.
        public Proprietaire()
        {
            id = "";
            nom = "";
            prenom = "";
        }

        public Proprietaire(string id, string nom, string prenom)
        {
            this.id = id;
            this.nom = nom;
            this.prenom = prenom;
        }

        public string Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
    }
}
