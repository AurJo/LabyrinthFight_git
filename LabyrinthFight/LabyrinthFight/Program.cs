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
            Game game = new Game();

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
            Game game = new Game();

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

            Thread thCombattant1 = new Thread(combattant1.ParcourirLabyrinthe);
            thCombattant1.Start();

            while(game.Labyrinthe.Sortie.Occupant == null)
            {
                Console.Clear();
                game.Labyrinthe.AfficherLabyrinthe();
                Thread.Sleep(100);
            }
        }

        static void Main(string[] args)
        {
            //Test1();
            //Test2();
            Test3();

            Console.ReadKey();
        }
    }
}
