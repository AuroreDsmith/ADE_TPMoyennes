using System;
using System.Collections.Generic;

namespace TPMoyennes
{
    internal class Classe
    { 
        public string nomClasse { get; private set; }
        public List<Eleve> eleves { get; private set; }
        public List<string> matieres { get; private set; }

        public Classe(string nomClasse)
        {
            this.nomClasse = nomClasse;
            this.eleves = new List<Eleve>();
            this.matieres = new List<string>();
        }

        public void ajouterEleve(string prenom, string nom)
        {
            if(eleves.Count < 30)
            {
                eleves.Add(new Eleve(prenom, nom));
            }
            else
            {
                Console.WriteLine("Il y a déjà 30 élèves dans cette classe");
            }
        }

        public void ajouterMatiere(string matiere)
        {
            if (matieres.Count < 10)
            {
                matieres.Add(matiere);
            }
            else
            {
                Console.WriteLine("Il y a déjà 10 matières pour cette classe");
            }
        }

        //Moyenne de la classe par matière
        public float moyenneMatiere(int matiere)
        {
            float moyenneParMatiere = 0;

            foreach (Eleve eleve in eleves)
            {
                moyenneParMatiere += eleve.moyenneMatiere(matiere);
            }

            float moyenneClasseParMatiere = (float)Math.Truncate((moyenneParMatiere / eleves.Count) * 100) / 100;
            return moyenneClasseParMatiere;
        }

        //Moyenne générale de la classe
        public float moyenneGeneral()
        {
            float moyenneGeneraleClasse = 0;
            for (int m = 0; m < matieres.Count; m++)
            {
                moyenneGeneraleClasse += moyenneMatiere(m);
            }

            return (float)Math.Truncate((moyenneGeneraleClasse/ matieres.Count) * 100) / 100;
        }

    }
}