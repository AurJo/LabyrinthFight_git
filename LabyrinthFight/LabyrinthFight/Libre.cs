﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinthFight
{
    public class Libre : Case 
    {
        private Occupant occupant;

        public Libre(int position)
        {
            this.position = position;
        }

        public Occupant Occupant { get => occupant; set => occupant = value; }
    }
}
