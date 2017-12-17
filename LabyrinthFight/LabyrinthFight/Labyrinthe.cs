using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LabyrinthFight
{
    public sealed class Labyrinthe
    {
        private static Labyrinthe labyrintheInstance;
        private CaseFactory caseFactory;
        private List<Case> listCase;
        static object instanceLock = new object();
        private int nbrColonne;
        private int nbrLigne;
        private int nbrCaseLibre;


        private Labyrinthe()
        {
            this.listCase = new List<Case>();
            this.caseFactory = new CaseFactory();
        }


        public static Labyrinthe LabyrintheInstance
        {
            get
            {
                if (labyrintheInstance == null)
                {
                    lock (instanceLock)
                    {
                        if (labyrintheInstance == null)
                        {
                            labyrintheInstance = new Labyrinthe();
                        }
                    }
                }
                return labyrintheInstance;
            }
        }

        public int NbrCaseLibre { get => nbrCaseLibre; set => nbrCaseLibre = value; }

        public void GenerationLabyrinthe(string fichierTxt)
        {
            StreamReader monStreamReader = new StreamReader(@fichierTxt);
            string ligne = monStreamReader.ReadLine();
            int position = 1;
            int nbrColonne = 0;
            int nbrLigne = 0;
            int nbrLibre = 0;

            while (ligne != null)
            {
                string[] temp = ligne.Split(';');
                nbrColonne = temp.Length;

                for (int i = 0; i < nbrColonne; i++)
                {
                    listCase.Add(this.caseFactory.CreatCase(temp[i], position + i));
                    if (listCase[i] is Libre)
                    {
                        nbrLibre += 1;
                    }
                }
                position += nbrColonne;

                ligne = monStreamReader.ReadLine();
                nbrLigne += 1;
            }
            monStreamReader.Close();

            this.nbrColonne = nbrColonne;
            this.nbrLigne = nbrLigne;
            this.nbrCaseLibre = nbrLibre;
        }

        public List<Case> RetournePossibilites(Case caseActuel)
        {
            List<Case> possibilites = new List<Case>();
            possibilites.Add(Nord(caseActuel));
            possibilites.Add(Sud(caseActuel));
            possibilites.Add(Ouest(caseActuel));
            possibilites.Add(Est(caseActuel));
            return possibilites;
        }

        public Case Nord(Case caseActuel)
        {
            int positionNord = caseActuel.Position - this.nbrColonne;
            if (positionNord >= 1)
            {
                return this.listCase.ElementAt(positionNord - 1);
            }
            return null;
        }

        public Case Sud(Case caseActuel)
        {
            int positionSud = caseActuel.Position + this.nbrColonne;
            if (positionSud <= this.nbrColonne * this.nbrLigne)
            {
                return this.listCase.ElementAt(positionSud - 1);
            }
            return null;
        }

        public Case Ouest(Case caseActuel)
        {
            int positionOuest = caseActuel.Position - 1;
            if (positionOuest >= 1 && positionOuest % this.nbrColonne != 0)
            {
                return this.listCase.ElementAt(positionOuest - 1);
            }
            return null;
        }

        public Case Est(Case caseActuel)
        {
            int positionEst = caseActuel.Position - 1;
            if (positionEst <= this.nbrColonne * this.nbrLigne && positionEst % this.nbrColonne != 1)
            {
                return this.listCase.ElementAt(positionEst - 1);
            }
            return null;
        }
    }
}
