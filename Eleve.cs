using System;
using System.Collections.Generic;

namespace TPMoyennes
{
    internal class Eleve
    {
        public string prenom { get; private set; }
        public string nom { get; private set; }
        public List<Note> notes { get; private set; }

        public Eleve(string prenom, string nom)
        {
            this.prenom = prenom;
            this.nom = nom;
            notes = new List<Note>();
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

            float moyMatiere = (float)Math.Truncate((cumulNote / compteurNotes) * 100) / 100;
            return moyMatiere;
        }

        //Moyenne générale de l'élève
        public float moyenneGeneral()
        {
            float cumulMoyenne = 0;
            int compteurMoyenne = 0;
            foreach (Note note in notes)
            {
                cumulMoyenne += moyenneMatiere(note.matiere);
                compteurMoyenne++;
            }

            if (compteurMoyenne == 0) return 0;

            float moyenneGenerale = (float)Math.Truncate((cumulMoyenne / compteurMoyenne) * 100) / 100;
            return moyenneGenerale;
        }
    }
}