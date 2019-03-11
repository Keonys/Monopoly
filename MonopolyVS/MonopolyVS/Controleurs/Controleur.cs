using MonopolyVS.Modeles;
using System;
using System.Collections.Generic;
using System.Windows.Shapes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MonopolyVS.Controleurs
{
    public class Controleur
    {
        #region Listes et Objets

        /// <summary>
        /// Liste des joueurs
        /// </summary>
        List<Joueur> listeJoueurs = new List<Joueur>();

        Des Des = new Des();

        #endregion

        //TODOCORENTIN Boucler dans la listeJoueur

        #region Méthodes

        /// <summary>
        /// Ajoute le nombre de joueur voulu à la listeJoueurs
        /// </summary>
        /// <param name="nbrJoueur"></param>
        public void AddJoueurs(int nbrJoueur)
        {
            //TODOLORENZO Remplacer tout ce qui concerne le nom, par la propriété de Lorenzo dans cette fonction
            //(remplacer le contenu du for par : listeJoueur.Add(new Joueur(Numero, Nom, Position)));
            //TODOLORENZO nbrJoueur dynamique
            nbrJoueur = 2;

            for (int i = 0; i < nbrJoueur; i++)
            {
                if (i == 0)
                {
                    listeJoueurs.Add(new Joueur(1, "Corentin", 0));
                }
                else
                {
                    listeJoueurs.Add(new Joueur(2, "Lorenzo", 0));
                }
            }
        }

        /// <summary>
        /// Evénement lors du clic sur le btnLanceDes
        /// </summary>
        /// <param name="txtboxConsole"></param>
        public void clicBtnLanceDes(TextBox txtboxConsole, Rectangle pion1, Rectangle pion2)
        {
            int resultat = 0;
            //int position = 0;

            Des.Lancer();

            //Affichage à la suite du résultat du lancé et affiche si le lanceur fait un doublé
            txtboxConsole.AppendText("\nLe premier dé affiche un " + Convert.ToString(Des.Premier) + "\n");
            txtboxConsole.AppendText("Le deuxième dé affiche un " + Convert.ToString(Des.Deuxieme) + "\n");

            //TODOLORENZO Placez le nom du joueur
            txtboxConsole.AppendText("Le joueur NOM avance de : " + Convert.ToString(Des.Resultat) + " cases. \n");

            resultat = Des.Resultat;

            if (Des.EstDouble())
                txtboxConsole.AppendText("Doublé !\n");

            txtboxConsole.ScrollToEnd();    //se rend à la dernière ligne de la console

            //position = Deplacement(resultat);
            //Placement(position);
        }

        /// <summary>
        /// Evénement lors du clic sur btnDk
        /// </summary>
        public void clicbtnDk()
        {
            //if (pion1.Fill == null)
            //{
            //    pion1.Fill = new ImageBrush(new BitmapImage(new Uri(@"..\..\Images\39px-ClassIcon_deathknightFOND.png", UriKind.Relative)));
            //    txtboxConsole.AppendText("Vous avez choisi le chevalier de la mort." + "\n");
            //    txtboxConsole.AppendText("Le joueur 2 choisit son pion : " + "\n");
            //    btnDk.Visibility = Visibility.Hidden;
            //}
            //else if (pion2.Fill == null)
            //{
            //    pion2.Fill = new ImageBrush(new BitmapImage(new Uri(@"..\..\Images\39px-ClassIcon_deathknightFOND.png", UriKind.Relative)));
            //    txtboxConsole.AppendText("Vous avez choisi le chevalier de la mort." + "\n");
            //    btnLanceDes.Visibility = Visibility.Visible;
            //    btnDk.Visibility = Visibility.Hidden;
            //    btnMage.Visibility = Visibility.Hidden;
            //    lblPion.Visibility = Visibility.Hidden;
            //}
        }

        /// <summary>
        /// Evénement lors du clic sur btnMage
        /// </summary>
        public void clicbtnMage()
        {
            //if (pion1.Fill == null)
            //{
            //    pion1.Fill = new ImageBrush(new BitmapImage(new Uri(@"..\..\Images\39px-ClassIcon_mageFOND.png", UriKind.Relative)));
            //    txtboxConsole.AppendText("Vous avez choisi le mage." + "\n");
            //    txtboxConsole.AppendText("Le joueur 2 choisit son pion : " + "\n");
            //    btnMage.Visibility = Visibility.Hidden;
            //}

            //else if (pion2.Fill == null)
            //{
            //    pion2.Fill = new ImageBrush(new BitmapImage(new Uri(@"..\..\Images\39px-ClassIcon_mageFOND.png", UriKind.Relative)));
            //    txtboxConsole.AppendText("Vous avez choisi le mage." + "\n");
            //    btnLanceDes.Visibility = Visibility.Visible;
            //    btnDk.Visibility = Visibility.Hidden;
            //    btnMage.Visibility = Visibility.Hidden;
            //    lblPion.Visibility = Visibility.Hidden;
            //}
        }

        #endregion
    }
}
