using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinthFight
{
    public class Bombe : Accessoire
    {
        public Bombe()
        {
            this.capaciteBase = 10;
            this.capacite = 10;
            this.color = ConsoleColor.Magenta; 
        }
    }
}
