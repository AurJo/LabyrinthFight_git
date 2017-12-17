using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinthFight
{
    public class CaractereFactory
    {

        public Caractere CreateCaractere(int typeCaractere)
        {
            if(typeCaractere == 0)
                return new Offensif();
            if (typeCaractere == 1)
                return new Defensif();
            return null;
        }
    }
}
