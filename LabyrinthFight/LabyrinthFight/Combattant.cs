using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
            for (int i = 0; i < this.listAccessoire.Count; i++)
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
                if (caseProchaine is Libre)
                {
                    this.visite.Push(this.caseActuel);
                    (this.caseActuel as Libre).Occupant = null;
                    this.caseActuel = caseProchaine;
                    (this.caseActuel as Libre).Occupant = this;
                }
                if (caseProchaine is Sortie)
                {
                    this.visite.Push(this.caseActuel);
                    (this.caseActuel as Libre).Occupant = null;
                    this.caseActuel = caseProchaine;
                    (this.caseActuel as Sortie).Occupant = this;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool RetourArriere(Case pos)
        {
            try
            {
                visite.Pop();
                (this.caseActuel as Libre).Occupant = null;
                this.caseActuel = pos;
                (this.caseActuel as Libre).Occupant = this;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Combat(Combattant adversaireAttaque)
        {
            try
            {
                adversaireAttaque.Vie -= this.capacite;
                listAccessoire.Last().Capacite--;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool StrategieDeplacement()
        {
            Random rand = new Random();
            if (rand.Next(0, 2) == 1)
                return true;
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
                        if(visite.Count > 0 && pos != visite.First())
                            return Bouge(pos);
                        if (visite.Count == 0)
                            return Bouge(pos);
                    }
                }
                if ((pos as Libre).Occupant is Combattant)
                {
                    if (this.caractere is Offensif) // && ((pos as Libre).Occupant as Combattant).caractere is Offensif)
                    {
                        return Combat((pos as Libre).Occupant as Combattant);
                    }
                }
                if ((pos as Libre).Occupant is Accessoire)
                {
                    if (nonPossible.Contains(pos))
                    {
                        // Strategie de déplacement sur une case sans possibilités
                        if (StrategieDeplacement())
                        {
                            return Bouge(pos);
                        }
                    }
                    if (visite.Count > 0 && pos == visite.First())
                    {
                        // Strategie de déplacement sur une case sans possibilités
                        if (StrategieDeplacement())
                        {
                            return RetourArriere(pos);
                        }
                    }
                    else
                    {
                        RecupereAccessoire(pos);
                        return Bouge(pos);
                    }
                }
            }
            if (pos is Sortie)
            {
                return Bouge(pos);
            }
            return false;
        }

        public bool ChoixPossibilite()
        {
            List<Case> listePossibilite = Labyrinthe.LabyrintheInstance.RetournePossibilites(this.caseActuel);

            Random rand = new Random();

            bool bouger = false;
            int tailleListePossibilite = listePossibilite.Count;

            while (tailleListePossibilite != 0 && bouger == false)
            {
                int indexPos = rand.Next(0, tailleListePossibilite);
                bouger = ChoixAction(listePossibilite[indexPos]);
                listePossibilite.RemoveAt(indexPos);
                tailleListePossibilite = listePossibilite.Count;
            }
            if (bouger == false)
            {
                nonPossible.Add(caseActuel);
                bouger = RetourArriere(visite.First());
            }
            return bouger;
        }

        public void ParcourirLabyrinthe()
        {
            while (this.vie > 0 && (this.caseActuel is Sortie) == false)
            {
                ChoixPossibilite();
                Console.Clear();
                Labyrinthe.LabyrintheInstance.AfficherLabyrinthe();
                Console.ReadKey();
            }
            if (this.vie <= 0)
            {
                (this.caseActuel as Libre).Occupant = null;
            }
        }


        public override string ToString()
        {
            return nom;
        }


    }
}
