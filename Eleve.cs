using TPMoyennes;
using (Note);

namespace TPMoyennes
{
    internal class Eleve
    {
        public string prenom { get; private set; }
        public string nom { get; private set; }

        public Eleve(string prenom, string nom)
        {
            this.prenom = prenom;
            this.nom = nom;
        }
    }
}