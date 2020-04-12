# Gestion Stock Huile Pétrolier

## Description de l'application
Cette application permet la gestion de stock huile pétrolier, réalisé par C# Winforms du framework .NET, elle offre les opérations suivantes:
  - L'affichage des stocks huile
  - La saisie de nouveaux stocks
  - La suppression de stock selon (VF, VC)
  - Le trie décroissant par rapport au stock
  - Le sauvegarde des stocks sur un fichier par serialisation d'objets
  - La restauration des stock depuis un fichier par déserialisation d'objets
  - L'affichage des stocks répturés
  - La réduction à 40% du prix des stocks <= 5
  - L'affichage des stocks ayant VF MAX
  - L'affichage des stocks ayant VC MAX
  - L'affichage des stocks ayant VF et VC MAX
  - La valeur total des stocks d'un fournisseurs

## Manuel d'utilisation
Pour tester et executer l'application il suffit de duppliquer ce projet Github en utilisant la commande:
```
git clone https://github.com/fahdarhalai/GestionStockHuilePetrolier.git
```
La structure du projet ressemble à celle-ci:
```bash
.
├── ...
├── GestionStockHuilePetrolier
│   ├── HuileWinForm
        ├── Properties
            └── ...
        ├── Acceuil.cs
        ├── Gestionnaire.cs
        ├── Huile.cs
        ├── HuileWinForm.csproj
        ├── Program.cs
        └── ...
│   └── ...
└── ...
```
Vous devez d'abord se positionner dans le répertoire HuileWinForm via la commande:
```
cd GestionStockHuilePetrolier/HuileWinForm
```
Maintenant, il suffit de compiler le projet par la commande ```msbuild``` comme suit:
```
msbuild HuileWinForm.csproj
```
Vous allez remarqué l'apparition des répertoire "bin" et "obj", il suffit de prendre l'executable (StockHuile.exe) qui existe dans ```./bin/Debug/```, afin de tester les differentes fonctionnalités fournies par l'application.

## Screenshots
#### Fenêtre d'acceuil:
![Acceuil](https://user-images.githubusercontent.com/41004675/77268022-dad43c80-6ca4-11ea-9d38-9c4bfc649936.PNG)
#### Fenêtre A Propos:
![Apropos](https://user-images.githubusercontent.com/41004675/77268036-e6bffe80-6ca4-11ea-97f3-372c0471c832.PNG)
#### Ajout de stock huile:
![Saisie](https://user-images.githubusercontent.com/41004675/77268047-ede70c80-6ca4-11ea-8cc6-1e4e489ee1ba.PNG)
#### Suppression par valeur de VC/VF:
![Supprimer](https://user-images.githubusercontent.com/41004675/77268055-f50e1a80-6ca4-11ea-8128-f41f87377eff.PNG)


