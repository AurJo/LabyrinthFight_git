using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinthFight
{
    public class Mitraillette : Accessoire
    {
        public Mitraillette()
        {
            this.capaciteBase = 8;
            this.capacite = 8;
            this.color = ConsoleColor.Green; 
        }
    }
}
