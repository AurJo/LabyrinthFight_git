using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinthFight
{
    public class Pistolet : Accessoire
    {
        public Pistolet()
        {
            this.capaciteBase = 7;
            this.capacite = 7;
            this.color = ConsoleColor.Cyan; 
        }
    }
}
