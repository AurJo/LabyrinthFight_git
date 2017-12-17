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
        

        public void AjouterCombattant(string nom, int vie, int capacite, int typeCaractere)
        {
            this.listCombattant.Add(this.combattantFactory.CreateCombattant(nom, vie, capacite, typeCaractere));
        }
        
        public void GenerationCombattant()
        {
            int pourcentageCombattant = Convert.ToInt32(Console.ReadLine());
            int nombreCombattant = this.labyrinthe.NbrCaseLibre / pourcentageCombattant + 1 ;
            int vie = Convert.ToInt32(Console.ReadLine());
            int capacite = Convert.ToInt32(Console.ReadLine());

            Random rand = new Random();

            for (int i = 0; i < nombreCombattant; i++)
            {
                int typeCaractere = rand.Next(0, 2);
                AjouterCombattant(Convert.ToString(Convert.ToChar(i + 65)), vie, capacite, typeCaractere);
            }
        }

        public void AjouterAccessoire(int capacite)
        {
            this.listAccessoire.Add(this.accessoireFactory.CreateAccessoire(capacite));
        }

        public void GenerationAccessoire()
        {
            int pourcentageAccessoire = Convert.ToInt32(Console.ReadLine());
            int nombreAccessoire = this.labyrinthe.NbrCaseLibre / pourcentageAccessoire + 1;

            Random rand = new Random();

            for (int i = 0; i < nombreAccessoire; i++)
            {
                int capacite = rand.Next(1, 11);
                AjouterAccessoire(capacite);
            }
        }
    }
}
