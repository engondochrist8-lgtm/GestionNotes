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
    }
}
