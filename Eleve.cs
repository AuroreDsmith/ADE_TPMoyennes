
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
            notes = new List<Note>();
            moyenneMoyennesNotes = new List<float>();
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

            float moyenneMatiere = Math.Truncate((cumulNote / compteurNotes) * 100) / 100;
            moyenneMoyennesNotes.Insert(matiere, moyenneMatiere);
            return moyenneMatiere;
        }

        public float moyenneGeneral()
        {
            float moyenneGenerale = 0;
            foreach(float moyenne in moyenneMoyennesNotes)
            {
            moyenneGenerale += moyenne;
            }

            return Math.Truncate(moyenneGenerale * 100) / 100;
        }
    }
}