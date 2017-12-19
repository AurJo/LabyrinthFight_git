using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinthFight
{
    public class Couteau : Accessoire
    {
        public Couteau()
        {
            this.capaciteBase = 3;
            this.capacite = 3;
            this.color = ConsoleColor.DarkGreen; 
        }
    }
}
