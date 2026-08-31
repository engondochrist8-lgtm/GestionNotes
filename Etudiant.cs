using System;

namespace GestionNotes
{
    // Représente un étudiant de la classe.
    public class Etudiant
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Matricule { get; set; }

        // null tant que la note n'a pas été saisie
        public double? Note { get; set; }

        public Etudiant(string nom, string prenom, string matricule)
        {
            Nom = nom;
            Prenom = prenom;
            Matricule = matricule;
            Note = null;
        }
    }
}
