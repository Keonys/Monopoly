using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;
using MonopolyVS.Controleurs;

namespace MonopolyVS.Modeles
{
    public class Carte
    {
        #region MEMBRES
        public int Id;
        public string Type;
        public int Valeur;
        public string Contenu;
        public Controleur Control;
        List<Carte> listeChanceTamponCarte = new List<Carte>();
        List<Carte> listeCaisseTamponCarte = new List<Carte>();
        
        #endregion

        #region CONSTRUCTEURS

        public Carte()
        {

        }

        public Carte(Controleur c)
        {
            Control = c;
        }

        public Carte(int id, string type, int valeur, string contenu, Controleur c)
        {
            Id = id;
            Type = type;
            Valeur = valeur;
            Contenu = contenu;
            Control = c;
        }

        #endregion


        #region METHODES

        /// <summary>
        /// Pioche une carte chance et effectue un effet
        /// </summary>
        /// <param name="imgSortie"></param>
        /// <param name="j"></param>
        /// <param name="listeChance"></param>
        /// <param name="txtboxConsole"></param>
        /// <param name="pion1"></param>
        /// <param name="pion2"></param>
        /// <param name="listePropriete"></param>
        /// <param name="listeCases"></param>
        /// <param name="listeCaisse"></param>
        public void piocheChance(Image imgSortie, Joueur j, List<Carte> listeChance, Rectangle pion1, Rectangle pion2, 
            List<Propriete> listePropriete, List<Case> listeCases, List<Carte> listeCaisse)
        {
            Random alea = new Random();
            int i = 0;
            listeChanceTamponCarte = Control.listeChanceTampon;

            if (listeChanceTamponCarte.Count != 0)
                i = alea.Next(0, listeChanceTamponCarte.Count);
            else
            {
                if (Control.listeChanceTampon.Count == 0)
                    Control.remplirListeChanceTampon();
                listeChanceTamponCarte = Control.listeChanceTampon;

                i = alea.Next(0, listeChanceTamponCarte.Count);
            }

            if(listeChanceTamponCarte.Count != 0)
            {
                Carte c = listeChanceTamponCarte[i];
                Control.C.Carte(true, c.Contenu);

                if (c.Type == "Ajout")
                    j.Argent += c.Valeur;
                else if (c.Type == "Perte")
                    j.Argent -= c.Valeur;
                else if (c.Type == "Sortie")
                    j.Sortie++;
                else if (c.Type == "Prison")
                {
                    j.Position = 40;
                    j.Placement(40, j, pion1, pion2, listePropriete, listeCases, listeChance, imgSortie, listeCaisse);
                    j.EstEnPrison = true;
                    Control.C.ChampBataille(j.Nom);
                }

                listeChanceTamponCarte.Remove(listeChanceTamponCarte[i]);
            }
        }

        /// <summary>
        /// Piochage d'une caisse de communauté
        /// </summary>
        /// <param name="imgSortie"></param>
        /// <param name="j"></param>
        /// <param name="listeChance"></param>
        /// <param name="txtboxConsole"></param>
        /// <param name="pion1"></param>
        /// <param name="pion2"></param>
        /// <param name="listePropriete"></param>
        /// <param name="listeCases"></param>
        /// <param name="listeCaisse"></param>
        public void piocheCaisse(Image imgSortie, Joueur j, List<Carte> listeChance, Rectangle pion1, Rectangle pion2,
            List<Propriete> listePropriete, List<Case> listeCases, List<Carte> listeCaisse)
        {
            Random alea = new Random();
            int i = 0;
            listeCaisseTamponCarte = Control.listeCaisseTampon;

            if (listeCaisseTamponCarte.Count != 0)
                i = alea.Next(0, listeCaisseTamponCarte.Count);
            else
            {
                if(Control.listeCaisseTampon.Count == 0)
                    Control.remplirListeCaisseTampon();
                listeCaisseTamponCarte = Control.listeCaisseTampon;

                i = alea.Next(0, listeCaisseTamponCarte.Count);
            }

            if(listeCaisseTamponCarte.Count != 0)
            {
                Carte c = listeCaisseTamponCarte[i];
                Control.C.Carte(false, c.Contenu);

                if (c.Type == "Ajout")
                    j.Argent += c.Valeur;
                else if (c.Type == "Perte")
                    j.Argent -= c.Valeur;
                else if (c.Type == "Sortie")
                    j.Sortie++;
                else if (c.Type == "Prison")
                {
                    j.Position = 40;
                    j.Placement(40, j, pion1, pion2, listePropriete, listeCases, listeChance, imgSortie, listeCaisse);
                    j.EstEnPrison = true;
                    Control.C.ChampBataille(j.Nom);
                }

                listeCaisseTamponCarte.Remove(listeCaisseTamponCarte[i]);
            }
        }
        #endregion
    }
}
