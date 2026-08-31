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
    }
}
