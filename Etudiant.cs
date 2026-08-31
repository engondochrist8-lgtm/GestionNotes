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

        // Mention selon la grille officielle
        public string Mention
        {
            get
            {
                if (!Note.HasValue) return "Non notée";
                double n = Note.Value;
                if (n >= 16) return "Très bien";
                if (n >= 14) return "Bien";
                if (n >= 12) return "Assez bien";
                if (n >= 10) return "Passable";
                return "Insuffisant";
            }
        }

        public bool EstAdmis => Note.HasValue && Note.Value >= 10;

        public override string ToString()
        {
            string note = Note.HasValue ? Note.Value.ToString("0.00") : "N/A";
            return $"{Matricule,-10} {Nom,-15} {Prenom,-15} Note: {note,-6} Mention: {Mention}";
        }
    }
}
