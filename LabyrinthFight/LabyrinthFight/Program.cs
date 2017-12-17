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

            Labyrinthe.LabyrintheInstance.GenerationLabyrinthe("laby.txt");

            Labyrinthe.LabyrintheInstance.AfficherLabyrinthe();
            Console.ReadKey();

            Combattant combattant1 = new Combattant("A", 100, 10, 0);

            Combattant combattant2 = new Combattant("B", 100, 10, 1);

            Accessoire accessoire1 = new Pistolet();

            Accessoire accessoire2 = new Couteau();

            (Labyrinthe.LabyrintheInstance.ListCase[17] as Libre).Occupant = combattant1;
            (Labyrinthe.LabyrintheInstance.ListCase[49] as Libre).Occupant = combattant2;
            (Labyrinthe.LabyrintheInstance.ListCase[20] as Libre).Occupant = accessoire1;
            (Labyrinthe.LabyrintheInstance.ListCase[51] as Libre).Occupant = accessoire2;

            Labyrinthe.LabyrintheInstance.AfficherLabyrinthe();
        }

        static void Test3()
        {
            Game game = new Game();

            Labyrinthe.LabyrintheInstance.GenerationLabyrinthe("laby.txt");

            Labyrinthe.LabyrintheInstance.AfficherLabyrinthe();
            Console.ReadKey();

            Combattant combattant1 = new Combattant("A", 100, 10, 0);

            (Labyrinthe.LabyrintheInstance.ListCase[17] as Libre).Occupant = combattant1;

            Labyrinthe.LabyrintheInstance.AfficherLabyrinthe();
            Console.Clear();

            while(Labyrinthe.LabyrintheInstance.Sortie.Occupant == null)
            {
                combattant1.ParcourirLabyrinthe();
                Console.Clear();
                Labyrinthe.LabyrintheInstance.AfficherLabyrinthe();
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
