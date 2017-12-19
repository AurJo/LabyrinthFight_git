using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinthFight
{
    public class Marteau : Accessoire
    {
        public Marteau()
        {
            this.capaciteBase = 2;
            this.capacite = 2;
            this.color = ConsoleColor.DarkCyan; 
        }
    }
}
