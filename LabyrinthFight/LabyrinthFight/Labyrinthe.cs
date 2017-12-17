using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; 

namespace LabyrinthFight
{
    public class Labyrinthe
    {
        private static Labyrinthe labyrinthe;
        private CaseFactory caseFactory;
        private List<Case> listCase;
        static object instanceLock = new object(); 

        private Labyrinthe()
        {
            this.listCase = new List<Case>();
            this.caseFactory = new CaseFactory(); 
        }

        public static Labyrinthe GetLabyrinthe()
        {
            if (labyrinthe == null)
            {
                lock(instanceLock)
                {
                    if (labyrinthe == null)
                    {
                        labyrinthe = new Labyrinthe();
                    }
                }
            }
            return labyrinthe; 
        }

        public void GenerationLabyrinthe(string fichierTxt)
        {
            StreamReader monStreamReader = new StreamReader(@fichierTxt);
            string ligne = monStreamReader.ReadLine(); 

            while (ligne != null)
            {
                string[] temp = ligne.Split(';'); 

            }
        }


    }

    

}
