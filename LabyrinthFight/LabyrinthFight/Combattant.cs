using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinthFight
{
    public class Combattant : Occupant
    {
        string nom;
        private List<Accessoire> listAccessoire;
        private CaractereFactory caractereFactory;
        private Caractere caractere;
        private int vie;
        private int capacite;
        private Queue<Case> queueVisite;
        private Queue<Case> nonPossible;

        public Combattant(string nom,int vie, int capacite,int typeCaractere)
        {
            this.nom = nom;
            this.vie = vie;
            this.capacite = capacite;
            this.caractereFactory = new CaractereFactory();
            this.caractere = this.caractereFactory.CreateCaractere(typeCaractere);
            this.queueVisite = new Queue<Case>();
            this.nonPossible = new Queue<Case>();
            this.listAccessoire = new List<Accessoire>();
        }
    }
}
