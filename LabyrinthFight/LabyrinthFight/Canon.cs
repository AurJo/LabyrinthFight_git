using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinthFight
{
    public class Canon : Accessoire
    {
        public Canon()
        {
            this.capaciteBase = 9;
            this.capacite = 9;
            this.color = ConsoleColor.Yellow; 
        }
    }
}
