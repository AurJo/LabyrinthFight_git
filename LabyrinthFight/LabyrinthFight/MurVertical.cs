﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinthFight
{
    public class MurVertical : Mur
    {
        public MurVertical(int position)
        {
            this.position = position;
        }

        public override string ToString()
        {
            return "_"; 
        }
    }
}
