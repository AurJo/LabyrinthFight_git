using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinthFight
{
    public class MurHorizontal : Mur
    {
        public MurHorizontal(int position)
        {
            this.position = position;
        }

        public override string ToString()
        {
            Console.BackgroundColor = ConsoleColor.DarkGray; 
            return " "; 
        }
    }
}
