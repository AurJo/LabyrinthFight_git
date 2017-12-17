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

        public override string ToString()
        {
            if (this.occupant != null)
            {
                if (occupant is Combattant)
                {
                    return (occupant as Combattant).Nom;  
                }
                if (occupant is Accessoire)
                {
                    Console.BackgroundColor = (occupant as Accessoire).Color;
                }
                return " ";
            }
            else
            {
                return " "; 
            }
        }
    }

}
