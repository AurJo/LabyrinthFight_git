using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinthFight
{
    public class Epee : Accessoire
    {
        public Epee()
        {
            this.capaciteBase = 5;
            this.capacite = 5;
            this.color = ConsoleColor.DarkMagenta; 
        }
    }
}
