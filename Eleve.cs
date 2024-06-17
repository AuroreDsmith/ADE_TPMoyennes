using System;
using System.Collections.Generic;

namespace TPMoyennes
{
    internal class Eleve
    {
        public string prenom { get; private set; }
        public string nom { get; private set; }
        public List<Note> notes { get; private set; }
        public List<float> moyenneMoyennesNotes { get; private set; }
    

        public Eleve(string prenom, string nom)
        {
            this.prenom = prenom;
            this.nom = nom;
            this.notes = new List<Note>();
            this.moyenneMoyennesNotes = new List<float>();
        }

        public void ajouterNote(Note note)
        {
            if (notes.Count < 200)
            {
                notes.Add(note);
            }
            else 
            {
                Console.WriteLine("L'élève a déjà eu 200 notes au cours de l'année");
            }
        
        }

        //Moyenne de l'élève par matière
        public float moyenneMatiere(int matiere)
        {
            float cumulNote = 0;
            int compteurNotes = 0;

            foreach (Note note in notes)
            {
                if(note.matiere == matiere)
                {
                    cumulNote += note.note;
                    compteurNotes++;
                }
            }

            if (compteurNotes == 0) return 0;

            float moyenneMatiere = (float)Math.Truncate((cumulNote / compteurNotes) * 100) / 100;

            /* Gestion des index et de MAJ de moyenneMoyennesNotes et éviter ArgumentOutOfRangeException
            si taille tableau non suffisante */
            if (moyenneMoyennesNotes.Count > matiere)
            {
                moyenneMoyennesNotes[matiere] = moyenneMatiere;
            }
            else
            {
                while (moyenneMoyennesNotes.Count <= matiere)
                {
                    moyenneMoyennesNotes.Add(0);
                }
                moyenneMoyennesNotes[matiere] = moyenneMatiere;
            }

            return moyenneMatiere;
        }

        //Moyenne générale de l'élève
        public float moyenneGeneral()
        {
            if (moyenneMoyennesNotes.Count == 0) return 0;

            for (int matiere = 0; matiere < moyenneMoyennesNotes.Count; matiere++)
            {
                moyenneMatiere(matiere);
            }

            float moyenneGenerale = 0;
            int compteurMatiere = 0;

            foreach(float moyenne in moyenneMoyennesNotes)
            {
                if(moyenne > 0)
                {
                    moyenneGenerale += moyenne;
                    compteurMatiere++;
                }
            }

            if (compteurMatiere == 0) return 0;

            return (float)Math.Truncate((moyenneGenerale/ compteurMatiere) * 100) / 100;
        }
    }
}