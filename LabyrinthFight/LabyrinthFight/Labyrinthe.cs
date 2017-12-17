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
        private static Labyrinthe labyrintheInstance;
        private CaseFactory caseFactory;
        private List<Case> listCase;
        static object instanceLock = new object();


        private Labyrinthe()
        {
            this.listCase = new List<Case>();
            this.caseFactory = new CaseFactory();
        }


        public static Labyrinthe LabyrintheInstance
        {
            get
            {
                if (labyrintheInstance == null)
                {
                    lock (instanceLock)
                    {
                        if (labyrintheInstance == null)
                        {
                            labyrintheInstance = new Labyrinthe();
                        }
                    }
                }
                return labyrintheInstance;
            }
        }
        
        public void GenerationLabyrinthe(string fichierTxt)
        {
            StreamReader monStreamReader = new StreamReader(@fichierTxt);
            string ligne = monStreamReader.ReadLine();
            int position = 1; 

            while (ligne != null)
            {
                string[] temp = ligne.Split(';');

            }
        }


    }



}
