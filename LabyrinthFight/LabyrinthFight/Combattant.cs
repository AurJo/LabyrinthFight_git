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

        public string Nom { get => nom; set => nom = value; }
        public int Vie { get => vie; set => vie = value; }
        public int Capacite { get => capacite; set => capacite = value; }


        public void CalculeCapacite()
        {
            for(int i = 0; i < this.listAccessoire.Count; i++)
            {
                this.capacite += this.listAccessoire[i].Capacite;
            }
        }

        public void RecupereAccessoire(Case caseAccessoire)
        {
            this.listAccessoire.Add((caseAccessoire as Libre).Occupant as Accessoire);
            (caseAccessoire as Libre).Occupant = null;
            CalculeCapacite();
        }

        public bool Bouge(Case caseProchaine)
        {
            try
            {
                (this.caseActuel as Libre).Occupant = null;
                this.caseActuel = caseProchaine;
                (this.caseActuel as Libre).Occupant = this;
                this.visite.Push(this.caseActuel);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Combat(Combattant adversaireAttaque)
        {
            adversaireAttaque.Vie -= this.capacite;
            return false;
        }

        public bool ChoixAction(Case pos)
        {
            if (pos is Libre)
            {
                if ((pos as Libre).Occupant == null)
                {
                    if (nonPossible.Contains(pos) == false)
                    {
                        return Bouge(pos);
                    }
                }
                if ((pos as Libre).Occupant is Combattant)
                {
                    if (this.caractere is Offensif) // && ((pos as Libre).Occupant as Combattant).caractere is Offensif)
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
                    else
                    {
                        RecupereAccessoire(pos);
                        return Bouge(pos);
                    }
                }
            }
            return false;
        }

        public bool ChoixPossibilite(Labyrinthe labyrinthe)
        {
            List<Case> listePossibilite = labyrinthe.RetournePossibilites(caseActuel);

            Random rand = new Random();

            bool bouger = false;
            int tailleListePossibilite = listePossibilite.Count;

            while (tailleListePossibilite != 0 && bouger == false)
            {
                int indexPos = rand.Next(0, tailleListePossibilite + 1);
                bouger = ChoixAction(listePossibilite[indexPos]);
                listePossibilite.RemoveAt(indexPos);
            }
            return bouger;
        }


        public override string ToString()
        {
            return nom; 
        }


    }
}
