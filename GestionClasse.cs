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
    }
}
