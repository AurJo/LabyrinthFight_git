using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LabyrinthFight
{
    class Program
    {

        static void Test1()
        {
            Labyrinthe labyrinthe = Labyrinthe.LabyrintheInstance;

            labyrinthe.GenerationLabyrinthe("laby.txt");

            labyrinthe.AfficherLabyrinthe();


        }

        static void Test2()
        {
            Game game = Game.GameInstance;

            game.Labyrinthe.GenerationLabyrinthe("laby.txt");

            game.Labyrinthe.AfficherLabyrinthe();
            Console.ReadKey();

            Combattant combattant1 = new Combattant("A", 100, 10, 0);

            Combattant combattant2 = new Combattant("B", 100, 10, 1);

            Accessoire accessoire1 = new Pistolet();

            Accessoire accessoire2 = new Couteau();

            (game.Labyrinthe.ListCase[17] as Libre).Occupant = combattant1;
            (game.Labyrinthe.ListCase[49] as Libre).Occupant = combattant2;
            (game.Labyrinthe.ListCase[20] as Libre).Occupant = accessoire1;
            (game.Labyrinthe.ListCase[51] as Libre).Occupant = accessoire2;

            game.Labyrinthe.AfficherLabyrinthe();
        }

        static void Test3()
        {
            Game game = Game.GameInstance;

            game.Labyrinthe.GenerationLabyrinthe("laby.txt");

            game.Labyrinthe.AfficherLabyrinthe();
            Console.ReadKey();
            Console.Clear();

            Combattant combattant1 = new Combattant("A", 100, 10, 0);

            (game.Labyrinthe.ListCase[21] as Libre).Occupant = combattant1;
            combattant1.CaseActuel = game.Labyrinthe.ListCase[21];

            game.Labyrinthe.AfficherLabyrinthe();
            Console.ReadKey();
            Console.Clear();

            //combattant1.ParcourirLabyrinthe();

            Thread thCombattant1 = new Thread(combattant1.ParcourirLabyrinthe);
            thCombattant1.Start();

            while (game.Labyrinthe.Sortie.Occupant == null)
            {
                Console.Clear();
                game.Labyrinthe.AfficherLabyrinthe();
                Thread.Sleep(100);
            }
            Console.Clear();
            game.Labyrinthe.AfficherLabyrinthe();
        }

        static void Test4()
        {
            Game game = Game.GameInstance;
            Game.GameInstance.SpeedCombattant = 200;
            Game.GameInstance.CapaciteCombattant = 10;

            game.Labyrinthe.GenerationLabyrinthe("laby2.txt");

            game.AfficherGame();
            Console.ReadKey();

            game.AjouterCombattant("A", 100, 10, 1);
            game.AjouterCombattant("B", 100, 10, 1);

            for (int i = 0; i < game.ListCombattant.Count; i++)
            {
                (game.Labyrinthe.ListCase[game.Labyrinthe.ListPositionLibre[30*i].Position - 1] as Libre).Occupant = game.ListCombattant[i];
                game.ListCombattant[i].CaseActuel = game.Labyrinthe.ListCase[game.Labyrinthe.ListPositionLibre[30*i].Position - 1];
            }

            game.AjouterAccessoire(1);
            game.AjouterAccessoire(6);

            for (int i = 0; i < game.ListAccessoire.Count; i++)
            {
                (game.Labyrinthe.ListCase[game.Labyrinthe.ListPositionLibre[30 * (i + 2)].Position - 1] as Libre).Occupant = game.ListAccessoire[i];
            }

            game.AfficherGame();
            Console.ReadKey();

            for (int i = 0; i < game.ListCombattant.Count; i++)
            {
                Thread thCombattant = new Thread(game.ListCombattant[i].ParcourirLabyrinthe);
                thCombattant.Start();
            }
            game.AfficherGame();
        }

        static void Test5()
        {
            Game game = Game.GameInstance;
            game.InitialisationGame(500, 100, 10,30000);

            game.Labyrinthe.GenerationLabyrinthe("laby.txt");

            game.AfficherGame();
            Console.ReadKey();

            game.GenerationCombattant(0.02);
            game.GenerationAccessoire(0.07);
            game.AjoutCombattantVoix();

            game.PlacementCombattant();
            game.PlacementAccessoire();

            game.AfficherGame();
            Console.ReadKey();
            Thread thVoix = new Thread(game.Voix.SuppressionAccessoire);

            game.LancementCombattant();
            thVoix.Start();
            
            
            game.AfficherGame();
        }


        static void ProgrammePrincipal()
        {
            Game game = Game.GameInstance;

            Console.WriteLine("Vitesse des combattants : ");
            int speed = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Vie des combattants : ");
            int vie = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Capacité des combattants : ");
            int capacite = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Délai de la voix : ");
            int delaiVoix = Convert.ToInt32(Console.ReadLine());

            game.InitialisationGame(speed, vie, capacite, delaiVoix);

            Console.WriteLine("Choisir le labyrinthe : 1 ou 2");
            int typeLaby = Convert.ToInt32(Console.ReadLine());

            string txtLaby;

            if (typeLaby == 1)
                txtLaby = "laby.txt";
            else
                txtLaby = "laby2.txt";

            game.Labyrinthe.GenerationLabyrinthe(txtLaby);

            game.AfficherGame();
            Console.ReadKey();
            Console.WriteLine("Nombre de case libre : " + game.Labyrinthe.NbrCaseLibre); 
            Console.WriteLine("Pourcentage de combattant sur case libre : ");
            double pourcentageCombattant = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Pourcentage d'accessoire sur case libre : ");
            double pourcentageAccessoire = Convert.ToInt32(Console.ReadLine());

            game.GenerationCombattant(pourcentageCombattant/100);
            game.GenerationAccessoire(pourcentageAccessoire/100);
            game.AjoutCombattantVoix();

            game.PlacementCombattant();
            game.PlacementAccessoire();

            game.AfficherGame();
            Console.ReadKey();

            Thread thVoix = new Thread(game.Voix.SuppressionAccessoire);

            game.LancementCombattant();
            thVoix.Start();


            game.AfficherGame();
        }

        static void Main(string[] args)
        {
            //Test1();
            //Test2();
            //Test3();
            //Test4();
            //Test5();
            ProgrammePrincipal();
            Console.ReadKey();
        }
    }
}
