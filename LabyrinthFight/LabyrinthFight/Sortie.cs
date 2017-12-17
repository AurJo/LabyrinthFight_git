using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinthFight
{
    public class Sortie : Case
    {
        private Occupant occupant;

        public Sortie(int position)
        {
            this.position = position;
            this.occupant = null;
        }

        public Occupant Occupant { get => occupant; set => occupant = value; }

        public override string ToString()
        {
            Console.BackgroundColor = ConsoleColor.Yellow; 
            return "S"; 
        }
    }
}
