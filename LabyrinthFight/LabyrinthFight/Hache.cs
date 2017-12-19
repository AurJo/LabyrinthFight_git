using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinthFight
{
    public class Hache : Accessoire
    {
        public Hache()
        {
            this.capaciteBase = 4;
            this.capacite = 4;
            this.color = ConsoleColor.DarkYellow; 
        }
    }
}
