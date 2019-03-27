using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace MonopolyVS.Modeles
{
    public class Carte
    {
        public int Id;
        public string Type;
        public int Valeur;
        public string Contenu;
        List<Carte> listeChanceTampon = new List<Carte>();
        List<Carte> listeCaisseTampon = new List<Carte>();


        public Carte()
        {

        }

        public Carte(int id, string type, int valeur, string contenu)
        {
            Id = id;
            Type = type;
            Valeur = valeur;
            Contenu = contenu;
        }

        /// <summary>
        /// Pioche une carte chance et effectue un effet
        /// </summary>
        /// <param name="p"></param>
        /// <param name="j"></param>
        /// <param name="listeCases"></param>
        public void piocheChance(Image imgSortie, Joueur j, List<Carte> listeChance, TextBox txtboxConsole, Rectangle pion1, Rectangle pion2, 
            List<Propriete> listePropriete, List<Case> listeCases, List<Carte> listeCaisse)
        {
            listeChanceTampon = listeChance;
            Random alea = new Random();
            int i = 0;
            if(listeChanceTampon != null)
                i = alea.Next(0, listeChanceTampon.Count);
            else
            {
                listeChanceTampon = listeChance;
                i = alea.Next(0, listeChanceTampon.Count);
            }

            Carte c = listeChanceTampon[i];
            txtboxConsole.AppendText("Carte Chance : \n");
            txtboxConsole.AppendText(c.Contenu + " \n");
            if (c.Type == "Ajout")
                j.Argent += c.Valeur;
            else if (c.Type == "Perte")
                j.Argent -= c.Valeur;
            else if (c.Type == "Sortie")
                j.Sortie++;
            else if(c.Type == "Prison")
            {
                j.Position = 40;
                j.Placement(40, j, pion1, pion2, listePropriete, txtboxConsole, listeCases, listeChance, imgSortie, listeCaisse);
                j.EstEnPrison = true;
                txtboxConsole.AppendText(j.Nom + " rentre sur le champ de bataille ! \n");
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
        public void piocheCaisse(Image imgSortie, Joueur j, List<Carte> listeChance, TextBox txtboxConsole, Rectangle pion1, Rectangle pion2,
            List<Propriete> listePropriete, List<Case> listeCases, List<Carte> listeCaisse)
        {
            listeCaisseTampon = listeCaisse;
            Random alea = new Random();
            int i = 0;
            if (listeCaisseTampon != null)
                i = alea.Next(0, listeCaisseTampon.Count);
            else
            {
                listeCaisseTampon = listeCaisse;
                i = alea.Next(0, listeCaisseTampon.Count);
            }

            Carte c = listeCaisseTampon[i];
            txtboxConsole.AppendText("Carte Chance : \n");
            txtboxConsole.AppendText(c.Contenu + " \n");
            if (c.Type == "Ajout")
                j.Argent += c.Valeur;
            else if (c.Type == "Perte")
                j.Argent -= c.Valeur;
            else if (c.Type == "Sortie")
                j.Sortie++;
            else if (c.Type == "Prison")
            {
                j.Position = 40;
                j.Placement(40, j, pion1, pion2, listePropriete, txtboxConsole, listeCases, listeChance, imgSortie, listeCaisse);
                j.EstEnPrison = true;
                txtboxConsole.AppendText(j.Nom + " rentre sur le champ de bataille ! \n");
            }
        }
    }
}
