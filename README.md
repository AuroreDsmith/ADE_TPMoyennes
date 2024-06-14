# C# / TP1 - Evaluation : Calcul des moyennes

## THEMES:
- Encapsulation
- Instructions élémentaires
- Listes

## ENONCE:
Pour une école, réalisez un programme qui permet de calculer :
- la moyenne d’un élève dans chaque matière,
- la moyenne générale d’un élève,
- la moyenne de la classe dans chaque matière,
- la moyenne générale de la classe,

selon les règles suivantes :
1. Chaque moyenne est tronquée au-delà du second chiffre après la virgule.
2. La moyenne générale d’un élève est obtenue par la moyenne des moyennes de l’élève par matière.
3. La moyenne de la classe dans une matière est la moyenne des moyennes de tous les élèves dans la matière.
4. La moyenne générale de la classe est la moyenne des moyennes de la classe par matière.
5. Une classe accueille 30 élèves au maximum.
6. 10 matières au maximum sont enseignées dans une classe.
7. Un élève reçoit au plus 200 notes, toutes matières confondues, au cours de l’année.

Utilisez sans les modifier les classes suivantes : `Program` (code principal) et `Note` fournies ci-après.

Créez votre propre compte GitHUB, puis publiez votre solution et indiquez dans votre livraison, l’adresse de votre dépôt (comme au-dessus).

Créez les classes `Classe` et `Eleve` manquantes. Utilisez des tableaux pour stocker les élèves et les matières enseignées dans la classe `Classe` et les notes dans la classe `Eleve`.

Votre travail sera apprécié selon les critères suivants :
1. Le bon fonctionnement de l’application.
2. La fiabilité du code : anticipez les erreurs possibles dans l’utilisation de vos classes.
3. La répartition des traitements et données : pertinence des propriétés et de leur type, absence de redondance.
4. L’encapsulation des données.
5. Le respect des règles énoncées.
6. La présentation et la lisibilité de votre code source.

### Exemple d’Exécution :
Sacha TOUILLE, Moyenne en Anglais : 11.66

Sacha TOUILLE, Moyenne Générale : 14.04

Classe de 6eme A, Moyenne en Anglais : 11.44

Classe de 6eme A, Moyenne Générale : 11.65


### Classes fournies par HNI Institut
```
class Note
{
    public int matiere { get; private set; }
    public float note { get; private set; }

    public Note(int m, float n)
    {
        matiere = m;
        note = n;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Création d'une classe
        Classe sixiemeA = new Classe("6eme A");
        
        // Ajout des élèves à la classe
        sixiemeA.ajouterEleve("Jean", "RAGE");
        sixiemeA.ajouterEleve("Paul", "HAAR");
        sixiemeA.ajouterEleve("Sibylle", "BOQUET");
        sixiemeA.ajouterEleve("Annie", "CROCHE");
        sixiemeA.ajouterEleve("Alain", "PROVISTE");
        sixiemeA.ajouterEleve("Justin", "TYDERNIER");
        sixiemeA.ajouterEleve("Sacha", "TOUILLE");
        sixiemeA.ajouterEleve("Cesar", "TICHO");
        sixiemeA.ajouterEleve("Guy", "DON");

        // Ajout de matières étudiées par la classe
        sixiemeA.ajouterMatiere("Francais");
        sixiemeA.ajouterMatiere("Anglais");
        sixiemeA.ajouterMatiere("Physique/Chimie");
        sixiemeA.ajouterMatiere("Histoire");

        Random random = new Random();

        // Ajout de 5 notes à chaque élève et dans chaque matière
        for (int ieleve = 0; ieleve < sixiemeA.eleves.Count; ieleve++)
        {
            for (int matiere = 0; matiere < sixiemeA.matieres.Count; matiere++)
            {
                for (int i = 0; i < 5; i++)
                {
                    sixiemeA.eleves[ieleve].ajouterNote(new Note(matiere, (float)((6.5 + random.NextDouble() * 34)) / 2.0f));
                    // Note minimale = 3
                }
            }
        }

        Eleve eleve = sixiemeA.eleves[6];

        // Afficher la moyenne d'un élève dans une matière
        Console.Write(eleve.prenom + " " + eleve.nom + ", Moyenne en " + sixiemeA.matieres[1] + " : " + eleve.Moyenne(1) + "\n");

        // Afficher la moyenne générale du même élève
        Console.Write(eleve.prenom + " " + eleve.nom + ", Moyenne Generale : " + eleve.Moyenne() + "\n");

        // Afficher la moyenne de la classe dans une matière
        Console.Write("Classe de " + sixiemeA.nomClasse + ", Moyenne en " + sixiemeA.matieres[1] + " : " + sixiemeA.Moyenne(1) + "\n");

        // Afficher la moyenne générale de la classe
        Console.Write("Classe de " + sixiemeA.nomClasse + ", Moyenne Generale : " + sixiemeA.Moyenne() + "\n");

        Console.Read();
    }
}
