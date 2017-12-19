using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinthFight
{
    public class Libre : Case
    {
        private Occupant occupant;
        private static object afficheLock = new object();

        public Libre(int position)
        {
            this.position = position;
        }

        public Occupant Occupant { get => occupant; set => occupant = value; }

        public override string ToString()
        {
            lock (afficheLock)
            {
                if (this.occupant != null)
                {
                    if (occupant is Combattant)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        return (occupant as Combattant).Nom;
                    }
                    if (occupant is Accessoire)
                    {
                        Console.ForegroundColor = (occupant as Accessoire).Color;
                        return "o";
                    }
                }

                return " ";
            }
        }
    }

}
