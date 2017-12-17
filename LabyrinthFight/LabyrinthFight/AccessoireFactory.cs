using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinthFight
{
    public class AccessoireFactory
    {
        public Accessoire CreateAccessoire(int capacite)
        {
            switch (capacite)
            {
                case 1:
                    return new Baton();
                case 2:
                    return new Marteau();
                case 3:
                    return new Hache();
                case 4:
                    return new Couteau();
                case 5:
                    return new Epee();
                case 6:
                    return new Arc();
                case 7:
                    return new Pistolet();
                case 8:
                    return new Mitraillette();
                case 9:
                    return new Canon();
                case 10:
                    return new Bombe();
            }
            return null;
        }
    }
}
