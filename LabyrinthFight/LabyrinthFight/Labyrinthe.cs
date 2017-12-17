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
        private int nbrColonne;
        private int nbrLigne;
        private int nbrCaseLibre;
        private List<int> listPositionLibre; 


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
            int nbrColonne=0;
            int nbrLigne=0;
            int nbrLibre=0; 

            while (ligne != null)
            {
                string[] temp = ligne.Split(';');
                nbrColonne = temp.Length; 

                for (int i = 0; i < nbrColonne; i++ )
                {
                    listCase.Add(this.caseFactory.CreatCase(temp[i], position + i)); 
                    if (listCase[i] is Libre)
                    {
                        nbrLibre += 1;
                        listPositionLibre.Add(position + i); 
                    }
                }
                position += nbrColonne;

                ligne = monStreamReader.ReadLine();
                nbrLigne += 1; 
            }
            monStreamReader.Close();

            this.nbrColonne = nbrColonne;
            this.nbrLigne = nbrLigne;
            this.nbrCaseLibre = nbrLibre; 
        }

        
    }



}
