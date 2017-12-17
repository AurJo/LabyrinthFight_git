using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        static void Main(string[] args)
        {
            //Test1();
            Test2();
            Console.ReadKey();
        }
    }
}
