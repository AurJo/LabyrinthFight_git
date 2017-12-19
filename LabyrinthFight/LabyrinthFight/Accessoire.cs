using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinthFight
{
    public abstract class Accessoire : Occupant
    {
        protected int capaciteBase;
        protected int capacite;
        protected ConsoleColor color;

        public ConsoleColor Color { get => color; set => color = value; }
        public int Capacite { get => capacite; set => capacite = value; }
        public int CapaciteBase { get => capaciteBase; set => capaciteBase = value; }

        public void DiminuerCapacite()
        {
            if (this.capacite > 0)
                this.capacite--;

        }
    }
}
