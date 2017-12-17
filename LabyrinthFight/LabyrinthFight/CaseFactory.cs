using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinthFight
{
    public class CaseFactory
    {
        public Case CreatCase(string typeCase, int position)
        {
            if (typeCase == "1")
            {
                return new MurHorizontal(position); 
            }
            if (typeCase == "2")
            {
                return new MurVertical(position); 
            }
            if (typeCase == "3")
            {
                return new Sortie(position); 
            }
            if (typeCase == "0")
            {
                return new Libre(position);
            }
            return null; 
        }
    }
}
