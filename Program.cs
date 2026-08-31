using System;
using System.Collections.Generic;
using System.Linq;

namespace GestionNotes
{
    class Program
    {
        static GestionClasse gestion = new GestionClasse();

        static void Main(string[] args)
        {
            bool quitter = false;

            while (!quitter)
            {
                AfficherMenu();
                int choix = LireEntier("Votre choix : ", 1, 10);

                switch (choix)
                {
                    case 1: SaisirEtudiants(); break;
                    case 2: SaisirModifierNote(); break;
                    case 3: AfficherListeComplete(); break;
                    case 4: AfficherAdmis(); break;
                    case 5: AfficherRattrapage(); break;
                    case 6: RechercherEtudiant(); break;
                    case 10:
                        quitter = true;
                        Console.WriteLine("\nMerci d'avoir utilisé le système de gestion des notes. À bientôt !");
                        break;
                    default:
                        Console.WriteLine("Fonctionnalité en cours de construction...");
                        break;
                }

                if (!quitter)
                {
                    Console.WriteLine("\nAppuyez sur une touche pour continuer...");
                    Console.ReadKey();
                }
            }
        }

        static void AfficherMenu()
        {
            Console.Clear();
            Console.WriteLine("=== GESTION DE CLASSE ===");
            Console.WriteLine("1. Saisir les étudiants");
            Console.WriteLine("2. Saisir / Modifier les notes");
            Console.WriteLine("3. Afficher la liste complète");
            Console.WriteLine("4. Afficher les étudiants admis");
            Console.WriteLine("5. Afficher les étudiants à rattraper");
            Console.WriteLine("6. Rechercher un étudiant");
            Console.WriteLine("7. Afficher les statistiques de la classe");
            Console.WriteLine("8. Trier les étudiants (par nom ou par note)");
            Console.WriteLine("9. Supprimer un étudiant");
            Console.WriteLine("10. Quitter");
            Console.WriteLine();
        }

        static int LireEntier(string message, int min, int max)
        {
            int valeur;
            while (true)
            {
                Console.Write(message);
                string saisie = Console.ReadLine();
                if (int.TryParse(saisie, out valeur) && valeur >= min && valeur <= max)
                    return valeur;
                Console.WriteLine($"Entrée invalide. Veuillez entrer un nombre entre {min} et {max}.");
            }
        }

        static double LireNote()
        {
            double note;
            while (true)
            {
                Console.Write("Note (0 à 20) : ");
                string saisie = Console.ReadLine();
                if (double.TryParse(saisie, out note) && note >= 0 && note <= 20)
                    return note;
                Console.WriteLine("Note invalide. Elle doit être comprise entre 0 et 20.");
            }
        }

        static string LireChaineNonVide(string message)
        {
            string valeur;
            do
            {
                Console.Write(message);
                valeur = Console.ReadLine()?.Trim();
                if (string.IsNullOrEmpty(valeur))
                    Console.WriteLine("Ce champ ne peut pas être vide.");
            } while (string.IsNullOrEmpty(valeur));
            return valeur;
        }

        static void SaisirEtudiants()
        {
            Console.Clear();
            Console.WriteLine("=== SAISIR LES ÉTUDIANTS ===\n");
            int nombre = LireEntier("Combien d'étudiants voulez-vous ajouter ? ", 1, 1000);

            for (int i = 1; i <= nombre; i++)
            {
                Console.WriteLine($"\n--- Étudiant {i}/{nombre} ---");
                string nom = LireChaineNonVide("Nom : ");
                string prenom = LireChaineNonVide("Prénom : ");

                string matricule;
                while (true)
                {
                    matricule = LireChaineNonVide("Matricule : ");
                    if (!gestion.MatriculeExiste(matricule))
                        break;
                    Console.WriteLine("Ce matricule existe déjà. Veuillez en saisir un autre.");
                }

                gestion.AjouterEtudiant(new Etudiant(nom, prenom, matricule));
                Console.WriteLine("Étudiant ajouté avec succès.");
            }
        }

        static void SaisirModifierNote()
        {
            Console.Clear();
            Console.WriteLine("=== SAISIR / MODIFIER UNE NOTE ===\n");

            if (gestion.NombreEtudiants == 0)
            {
                Console.WriteLine("Aucun étudiant enregistré.");
                return;
            }

            string critere = LireChaineNonVide("Nom ou matricule de l'étudiant : ");
            Etudiant e = gestion.TrouverParNomOuMatricule(critere);

            if (e == null)
            {
                Console.WriteLine("Étudiant introuvable.");
                return;
            }

            Console.WriteLine($"Étudiant trouvé : {e.Prenom} {e.Nom} ({e.Matricule})");
            double note = LireNote();
            e.Note = note;
            Console.WriteLine("Note enregistrée avec succès.");
        }

        static void AfficherListeComplete()
        {
            Console.Clear();
            Console.WriteLine("=== LISTE COMPLÈTE DES ÉTUDIANTS ===\n");
            var liste = gestion.ObtenirTous();

            if (liste.Count == 0)
            {
                Console.WriteLine("Aucun étudiant enregistré.");
                return;
            }

            foreach (var e in liste)
                Console.WriteLine(e);

            Console.WriteLine($"\nTotal : {liste.Count} étudiant(s)");
        }

        static void AfficherAdmis()
        {
            Console.Clear();
            Console.WriteLine("=== ÉTUDIANTS ADMIS (Note ≥ 10) ===\n");
            var admis = gestion.ObtenirAdmis();

            if (admis.Count == 0)
            {
                Console.WriteLine("Aucun étudiant admis pour le moment.");
                return;
            }

            foreach (var e in admis)
                Console.WriteLine(e);

            Console.WriteLine($"\nTotal admis : {admis.Count}");

            Console.Write("\nVoulez-vous exporter cette liste dans un fichier texte ? (o/n) : ");
            string rep = Console.ReadLine()?.Trim().ToLower();
            if (rep == "o" || rep == "oui")
            {
                string chemin = "etudiants_admis.txt";
                gestion.ExporterAdmisVersFichier(chemin);
                Console.WriteLine($"Liste exportée dans le fichier \"{chemin}\".");
            }
        }

        static void AfficherRattrapage()
        {
            Console.Clear();
            Console.WriteLine("=== ÉTUDIANTS À RATTRAPER (Note < 10) ===\n");
            var rattrapage = gestion.ObtenirRattrapage();

            if (rattrapage.Count == 0)
            {
                Console.WriteLine("Aucun étudiant en situation de rattrapage.");
                return;
            }

            foreach (var e in rattrapage)
                Console.WriteLine(e);

            Console.WriteLine($"\nTotal : {rattrapage.Count}");
        }

        static void RechercherEtudiant()
        {
            Console.Clear();
            Console.WriteLine("=== RECHERCHER UN ÉTUDIANT ===\n");

            if (gestion.NombreEtudiants == 0)
            {
                Console.WriteLine("Aucun étudiant enregistré.");
                return;
            }

            string critere = LireChaineNonVide("Nom ou matricule à rechercher : ");
            Etudiant e = gestion.TrouverParNomOuMatricule(critere);

            if (e == null)
                Console.WriteLine("Aucun étudiant ne correspond à cette recherche.");
            else
            {
                Console.WriteLine("\nÉtudiant trouvé :");
                Console.WriteLine(e);
            }
        }
    }
}
