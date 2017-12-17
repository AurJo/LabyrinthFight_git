using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinthFight
{
    public class CombattantFactory
    {
        public Combattant CreateCombattant(string nom,int vie, int capacite)
        {
            Combattant combattant = new Combattant(nom,vie, capacite);

            return combattant;
        }
    }
}
