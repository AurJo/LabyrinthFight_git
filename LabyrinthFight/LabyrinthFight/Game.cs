using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinthFight
{
    public class Game
    {
        private Labyrinthe labyrinthe;
        private List<Combattant> listCombattant;
        private List<Accessoire> listAccessoire;
        private AccessoireFactory accessoireFactory;
        private CombattantFactory combattantFactory;

        public Game()
        {
            this.labyrinthe = Labyrinthe.LabyrintheInstance;
            this.listAccessoire = new List<Accessoire>();
            this.listCombattant = new List<Combattant>();
            this.accessoireFactory = new AccessoireFactory();
            this.combattantFactory = new CombattantFactory();

        }


        public void GenerationCombattant()
        {
            
        }
    }
}
