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
        private Stack<Case> visite;
        private List<Case> nonPossible;
        private Case caseActuel;

        public Combattant(string nom, int vie, int capacite, int typeCaractere)
        {
            this.nom = nom;
            this.vie = vie;
            this.capacite = capacite;
            this.caractereFactory = new CaractereFactory();
            this.caractere = this.caractereFactory.CreateCaractere(typeCaractere);
            this.visite = new Stack<Case>();
            this.nonPossible = new List<Case>();
            this.listAccessoire = new List<Accessoire>();
        }

        public Case CaseActuel { get => caseActuel; set => caseActuel = value; }
        public Caractere Caractere { get => caractere; set => caractere = value; }

        public void Mouvement(Labyrinthe labyrinthe)
        {
            List<Case> possibilites = labyrinthe.RetournePossibilites(caseActuel);

            foreach (Case pos in possibilites)
            {
                if (pos is Libre)
                {
                    if ((pos as Libre).Occupant == null)
                    {
                        if (nonPossible.Contains(pos) == false)
                        {
                            (this.caseActuel as Libre).Occupant = null;
                            this.caseActuel = pos;
                            (this.caseActuel as Libre).Occupant = this;
                            this.visite.Push(this.caseActuel);
                        }
                    }
                    if ((pos as Libre).Occupant is Combattant)
                    {
                        if (this.caractere is Offensif && ((pos as Libre).Occupant as Combattant).caractere is Offensif)
                        {
                            // combat
                            // bouge
                        }
                    }
                    if ((pos as Libre).Occupant is Accessoire)
                    {
                        if (nonPossible.Contains(pos))
                        {
                            // Strategie de déplacement sur une case sans possibilités
                            // Si oui : add dans la liste visité
                        }
                        if (pos == visite.ElementAt(visite.Count - 1))
                        {
                            // Strategie de déplacement sur une case sans possibilités
                            // Si oui : enlève la dernière case visité
                        }
                    }
                }
            }
        }


    }
}
