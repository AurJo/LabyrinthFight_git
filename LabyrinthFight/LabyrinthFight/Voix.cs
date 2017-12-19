using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LabyrinthFight
{
    public class Voix
    {
        private List<ICombattant> listeCombattant;
        private Game game;
        private int delaiSuppression;

        public Voix()
        {
            this.listeCombattant = new List<ICombattant>();
        }

        public void InitialisationVoix(int delaiSuppression)
        {
            this.delaiSuppression = delaiSuppression;
        }

        public void AttachGame(Game game)
        {
            this.game = game;
        }

        public void Attach(ICombattant combattant)
        {
            if (!this.listeCombattant.Contains(combattant))
            {
                this.listeCombattant.Add(combattant);
            }
        }

        public void Detach(ICombattant combattant)
        {
            if (this.listeCombattant.Contains(combattant))
            {
                this.listeCombattant.Remove(combattant);
            }
        }

        public void Notify()
        {
            foreach(ICombattant c in listeCombattant)
            {
                c.Update();
            }
        }

        public void SuppressionAccessoire()
        {
            while(Game.GameInstance.NombreArrive != Game.GameInstance.ListCombattant.Count)
            {
                Thread.Sleep(delaiSuppression)
            }
        }
    }
}
