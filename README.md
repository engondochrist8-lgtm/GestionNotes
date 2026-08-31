<<<<<<< HEAD
# Système de gestion des notes d'une classe

Projet d'examen — Programmation C# (.NET) — SUP'INFO Dakar

Application console permettant à un enseignant de gérer les étudiants
d'une classe et leurs notes.

## Fonctionnalités
1. Saisir les étudiants
2. Saisir / Modifier les notes
3. Afficher la liste complète
4. Afficher les étudiants admis
5. Afficher les étudiants à rattraper
6. Rechercher un étudiant
7. Afficher les statistiques de la classe
8. Trier les étudiants (par nom ou par note)
9. Supprimer un étudiant
10. Quitter

## Structure du projet
- `Etudiant.cs` — classe représentant un étudiant (Nom, Prénom, Matricule, Note, Mention).
- `GestionClasse.cs` — logique métier : liste des étudiants, recherche, tri, statistiques, export.
- `Program.cs` — menu console et gestion des saisies utilisateur.

## Bonus implémentés
- Export des étudiants admis dans un fichier texte (`etudiants_admis.txt`).
- Calcul de la médiane des notes en plus de la moyenne.

## Lancer le projet
```
dotnet run
```

Ou ouvrir `GestionNotes.csproj` dans Visual Studio (Ouvrir > Projet/Solution) et lancer avec F5 / Ctrl+F5.

## Prérequis
.NET 8.0 SDK (ou supérieur). Si Visual Studio propose une autre version de framework cible,
adapter la valeur `TargetFramework` dans `GestionNotes.csproj` (ex : `net6.0`).
=======
# GestionNotes
>>>>>>> origin/main
