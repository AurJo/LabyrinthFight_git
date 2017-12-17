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
        private Case caseActuel;

        public Combattant(string nom, int vie, int capacite, int typeCaractere)
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

        public Case CaseActuel { get => caseActuel; set => caseActuel = value; }



        public void Mouvement(Labyrinthe labyrinthe)
        {
            List<Case> possibilites = labyrinthe.RetournePossibilites(caseActuel);

            foreach (Case pos in possibilites)
            {
                if (pos is Libre)
                {
                    if ((pos as Libre).Occupant is Accessoire)
                    {
                        if (nonPossible.Contains(pos))
                        {

                        }
                        if (pos == queueVisite.ElementAt(queueVisite.Count - 1))
                        {

                        }
                    }
                }
            }
        }


    }
}
