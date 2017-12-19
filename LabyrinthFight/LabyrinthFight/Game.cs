using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LabyrinthFight
{
    public class Game
    {
        private static Game gameInstance;
        private static object gameInstanceLock = new object();
        private Labyrinthe labyrinthe;
        private List<Combattant> listCombattant;
        private List<Accessoire> listAccessoire;
        private AccessoireFactory accessoireFactory;
        private CombattantFactory combattantFactory;
        private int speedCombattant;
        private int capaciteCombattant;
        private int nombreArrive;
        private int vieBase;

        public Labyrinthe Labyrinthe { get => labyrinthe; set => labyrinthe = value; }
        public List<Combattant> ListCombattant { get => listCombattant; set => listCombattant = value; }
        public List<Accessoire> ListAccessoire { get => listAccessoire; set => listAccessoire = value; }
        public int SpeedCombattant { get => speedCombattant; set => speedCombattant = value; }
        public int CapaciteCombattant { get => capaciteCombattant; set => capaciteCombattant = value; }
        public int NombreArrive { get => nombreArrive; set => nombreArrive = value; }
        public int VieBase { get => vieBase; set => vieBase = value; }

        private Game()
        {
            this.labyrinthe = Labyrinthe.LabyrintheInstance;
            this.listAccessoire = new List<Accessoire>();
            this.listCombattant = new List<Combattant>();
            this.accessoireFactory = new AccessoireFactory();
            this.combattantFactory = new CombattantFactory();
            this.nombreArrive = 0;
        }

        public static Game GameInstance
        {
            get
            {
                lock (gameInstanceLock)
                {
                    if (gameInstance == null)
                    {
                        lock (gameInstanceLock)
                        {
                            if (gameInstance == null)
                            {
                                gameInstance = new Game();
                            }
                        }
                    }
                    return gameInstance;
                }
            }
        }

        public void InitialisationGame(int speedCombattant, int vieBase, int capaciteCombattant)
        {
            this.speedCombattant = speedCombattant;
            this.vieBase = vieBase;
            this.capaciteCombattant = capaciteCombattant;
        }

        public void AjouterCombattant(string nom, int vie, int capacite, int typeCaractere)
        {
            this.listCombattant.Add(this.combattantFactory.CreateCombattant(nom, vie, capacite, typeCaractere));
        }

        public void GenerationCombattant(double pourcentageCombattant)
        {
            int nombreCombattant = Convert.ToInt32(this.labyrinthe.NbrCaseLibre * pourcentageCombattant + 1);

            Random rand = new Random();

            for (int i = 0; i < nombreCombattant; i++)
            {
                AjouterCombattant(Convert.ToString(Convert.ToChar(i + 65)), this.vieBase, this.capaciteCombattant, 1);
            }
        }

        public void AjouterAccessoire(int capacite)
        {
            this.listAccessoire.Add(this.accessoireFactory.CreateAccessoire(capacite));
        }

        public void GenerationAccessoire(double pourcentageAccessoire)
        {
            int nombreAccessoire = Convert.ToInt32(this.labyrinthe.NbrCaseLibre * pourcentageAccessoire + 1);

            Random rand = new Random();

            for (int i = 0; i < nombreAccessoire; i++)
            {
                int capacite = rand.Next(1, 11);
                AjouterAccessoire(capacite);
            }
        }

        public void PlacementCombattant()
        {
            Random rand = new Random();

            for (int i = 0; i < listCombattant.Count; i++)
            {
                int indexPlacement = rand.Next(labyrinthe.NbrCaseLibre);
                while ((labyrinthe.ListCase[labyrinthe.ListPositionLibre[indexPlacement].Position - 1] as Libre).Occupant != null)
                {
                    indexPlacement = rand.Next(labyrinthe.NbrCaseLibre);
                }
                if (listCombattant[i].Vie > 0)
                {
                    (labyrinthe.ListCase[labyrinthe.ListPositionLibre[indexPlacement].Position - 1] as Libre).Occupant = listCombattant[i];
                    listCombattant[i].CaseActuel = labyrinthe.ListCase[labyrinthe.ListPositionLibre[indexPlacement].Position - 1];
                }
            }
        }

        public void PlacementAccessoire()
        {
            Random rand = new Random();

            for (int i = 0; i < listAccessoire.Count; i++)
            {
                int indexPlacement = rand.Next(labyrinthe.NbrCaseLibre);
                while ((labyrinthe.ListCase[labyrinthe.ListPositionLibre[indexPlacement].Position - 1] as Libre).Occupant != null)
                {
                    indexPlacement = rand.Next(labyrinthe.NbrCaseLibre);
                }
                (labyrinthe.ListCase[labyrinthe.ListPositionLibre[indexPlacement].Position - 1] as Libre).Occupant = listAccessoire[i];
            }
        }

        public void LancementCombattant()
        {
            for (int i = 0; i < listCombattant.Count; i++)
            {
                Thread thCombattant = new Thread(listCombattant[i].ParcourirLabyrinthe);
                thCombattant.Start();
            }
        }



        public void AfficherGame()
        {
            lock (gameInstanceLock)
            {
                Console.Clear();
                this.labyrinthe.AfficherLabyrinthe();

                Console.BackgroundColor = ConsoleColor.Black;
                for (int i = 0; i < this.listCombattant.Count; i++)
                {
                    if (this.listCombattant[i].Vie <= 0)
                    {
                        Console.SetCursorPosition(labyrinthe.NbrColonne * 2, i);
                        Console.Write("{0} mort : Vie : {1}, Capacite : {2}, Caractere : {3}", this.listCombattant[i], this.listCombattant[i].Vie, this.listCombattant[i].Capacite, this.listCombattant[i].Caractere);
                    }
                    if(this.listCombattant[i].CaseActuel is Sortie)
                    {
                        Console.SetCursorPosition(labyrinthe.NbrColonne * 2, i);
                        Console.Write("{0} arrivé : Vie : {1}, Capacite : {2}, Caractere : {3}, Position d'arrivée : {4}", this.listCombattant[i], this.listCombattant[i].Vie, this.listCombattant[i].Capacite, this.listCombattant[i].Caractere, this.listCombattant[i].PositionArrive);

                    }
                    else
                    {
                        Console.SetCursorPosition(labyrinthe.NbrColonne * 2, i);
                        Console.Write("{0} : Vie : {1}, Capacite : {2}, Caractere : {3}", this.listCombattant[i], this.listCombattant[i].Vie, this.listCombattant[i].Capacite, this.listCombattant[i].Caractere);
                    }
                }

                for (int i = 0; i < this.listAccessoire.Count; i++)
                {
                    Console.SetCursorPosition(labyrinthe.NbrColonne * 2, i + 10);
                    Console.Write("{0} ( {1} ) : Capacite : {2}", this.listAccessoire[i], this.listAccessoire[i].CapaciteBase, this.listAccessoire[i].Capacite);
                }
            }
        }
    }
}
