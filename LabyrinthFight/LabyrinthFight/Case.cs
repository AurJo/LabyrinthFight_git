using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinthFight
{
    public abstract class Case
    {
        protected int position;

        public int Position { get => position; set => position = value; }
    }
}
