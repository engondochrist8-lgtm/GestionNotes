using System;
using System.Collections.Generic;
using System.Linq;

namespace GestionNotes
{
    // Contient la logique métier : la liste des étudiants et les opérations associées.
    public class GestionClasse
    {
        private List<Etudiant> etudiants = new List<Etudiant>();

        public int NombreEtudiants => etudiants.Count;

        public void AjouterEtudiant(Etudiant e)
        {
            etudiants.Add(e);
        }

        public bool MatriculeExiste(string matricule)
        {
            return etudiants.Any(e => e.Matricule.Equals(matricule, StringComparison.OrdinalIgnoreCase));
        }

        public List<Etudiant> ObtenirTous() => etudiants;

        // Recherche par nom ou par matricule (insensible à la casse)
        public Etudiant TrouverParNomOuMatricule(string critere)
        {
            return etudiants.FirstOrDefault(e =>
                e.Matricule.Equals(critere, StringComparison.OrdinalIgnoreCase) ||
                e.Nom.Equals(critere, StringComparison.OrdinalIgnoreCase));
        }

        public List<Etudiant> ObtenirAdmis() =>
            etudiants.Where(e => e.EstAdmis).ToList();

        public List<Etudiant> ObtenirRattrapage() =>
            etudiants.Where(e => e.Note.HasValue && e.Note.Value < 10).ToList();

        public List<Etudiant> TrierParNom() =>
            etudiants.OrderBy(e => e.Nom).ToList();

        public List<Etudiant> TrierParNoteDecroissante() =>
            etudiants.OrderByDescending(e => e.Note ?? -1).ToList();

        public bool SupprimerEtudiant(Etudiant e)
        {
            return etudiants.Remove(e);
        }

        // Calcule moyenne, meilleure/plus faible note, taux de réussite et médiane
        public (double moyenne, Etudiant meilleur, Etudiant plusFaible, double tauxReussite, double mediane) CalculerStatistiques()
        {
            var notes = etudiants.Where(e => e.Note.HasValue).ToList();
            if (notes.Count == 0)
                return (0, null, null, 0, 0);

            double moyenne = notes.Average(e => e.Note.Value);
            Etudiant meilleur = notes.OrderByDescending(e => e.Note.Value).First();
            Etudiant plusFaible = notes.OrderBy(e => e.Note.Value).First();
            int admis = notes.Count(e => e.EstAdmis);
            double taux = (double)admis / notes.Count * 100;

            var notesTriees = notes.Select(e => e.Note.Value).OrderBy(n => n).ToList();
            double mediane;
            int milieu = notesTriees.Count / 2;
            if (notesTriees.Count % 2 == 0)
                mediane = (notesTriees[milieu - 1] + notesTriees[milieu]) / 2.0;
            else
                mediane = notesTriees[milieu];

            return (moyenne, meilleur, plusFaible, taux, mediane);
        }
    }
}
