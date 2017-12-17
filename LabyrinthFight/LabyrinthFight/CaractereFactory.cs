using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinthFight
{
    public class CaractereFactory
    {

        public Caractere CreateCaractere()
        {
            Random rand = new Random();
            int aleatoire = rand.Next(0,2);
            if(aleatoire == 0)
                return new Offensif();
            else
                return new Defensif();
        }
    }
}
