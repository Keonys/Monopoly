using MonopolyVS.Modeles;
using System;
using System.Collections.Generic;
using System.Windows.Shapes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MonopolyVS.Controleurs
{
    public class Controleur
    {
        #region Listes et Objets

        /// <summary>
        /// Liste des joueurs
        /// </summary>
        List<Joueur> listeJoueurs = new List<Joueur>();

        //TODOLORENZO nbrJoueur à mettre en dynamique ci-dessous
        int nbrJoueurs = 2;

        Des Des = new Des();

        #endregion

        #region Méthodes

        /// <summary>
        /// Ajoute le nombre de joueur voulu à la listeJoueurs
        /// </summary>
        /// <param name="nbrJoueur"></param>
        public void AddJoueurs(int nbrJoueur)
        {
            //TODOLORENZO Remplacer tout ce qui concerne le nom, par la propriété de Lorenzo dans cette fonction
            //(remplacer le contenu du for par : listeJoueurs.Add(new Joueur(Numero, Nom, Position)));

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
        /// Rend invisible certaines partie de la fenêtre
        /// </summary>
        public void prepareInvisible(Label lblTour, Label lblNomJoueur, Label lblPion, Button btnDk, Button btnMage, Button btnLanceDes)
        {
            lblTour.Visibility = Visibility.Hidden;
            lblNomJoueur.Visibility = Visibility.Hidden;
            lblPion.Visibility = Visibility.Hidden;
            btnDk.Visibility = Visibility.Hidden;
            btnMage.Visibility = Visibility.Hidden;
            btnLanceDes.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Affichage de l'écran d'accueil (avant l'affichage du plateau)
        /// </summary>
        public void afficheFormulaire(MainWindow m)
        {
            FormulaireJoueur Menu = new FormulaireJoueur();

            m.Visibility = Visibility.Hidden;
            Menu.Show();

            //TODOLORENZO Alors normalement dans ta fenêtre y a un bouton "jouer" qui va emmener à la fenêtre principale (avec le plateau)
            //Du coup le but serais que : Au moment où le joueur clique sur "Jouer", la méthode "AddJoueur" est lancée
            //Pour le moment je fais ça à la main dans le MainWindow.xaml.cs
        }

        /// <summary>
        /// Evénement lors du clic sur btnTour
        /// </summary>
        public void clicbtnTour(TextBox textBox, Button btnTour, Label lblTour, Label lblNomJoueur, Label lblPion, 
            Button btnDk, Button btnMage)
        {
            AddJoueurs(nbrJoueurs);

            int i = 1;
            List<Joueur> listeJoueursTampon = new List<Joueur>();
            listeJoueursTampon = listeJoueurs;
            Dictionary<Joueur, int> mapJoueurs = new Dictionary<Joueur, int>();

            foreach (Joueur j in listeJoueursTampon)
            {
                mapJoueurs.Add(j, Des.Lancer());
                textBox.AppendText(j.Nom + " a fait un " + Convert.ToString(Des.Resultat) + "\n");
            }

            var sortedMap = from entry in mapJoueurs orderby entry.Value descending select entry;

            foreach (KeyValuePair<Joueur, int> entry in sortedMap)
            {
                entry.Key.Numero = i;
                i++;

                textBox.AppendText(entry.Key.Nom + " jouera en position " + entry.Key.Numero + "\n");
            }

            foreach(Joueur j in listeJoueurs)
            {
                if(j.Numero == 1)
                    j.changeTour(listeJoueurs, 0, lblNomJoueur);
            }

            btnTour.Visibility = Visibility.Hidden;
            lblTour.Visibility = Visibility.Visible;
            lblNomJoueur.Visibility = Visibility.Visible;
            lblPion.Visibility = Visibility.Visible;
            btnDk.Visibility = Visibility.Visible;
            btnMage.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Evénement lors du clic sur le btnLanceDes
        /// </summary>
        /// <param name="txtboxConsole"></param>
        public void clicBtnLanceDes(TextBox txtboxConsole, Rectangle pion1, Rectangle pion2, Label lblNomJoueur)
        {
            int resultat = 0;
            int position = 0;

            foreach (Joueur j in listeJoueurs)
            {
                if(j.sonTour == true)
                {
                    Des.Lancer();
                    resultat = Des.Resultat;

                    //Affichage à la suite du résultat du lancé et affiche si le lanceur fait un doublé
                    txtboxConsole.AppendText("\nLe premier dé affiche un " + Convert.ToString(Des.Premier) + "\n");
                    txtboxConsole.AppendText("Le deuxième dé affiche un " + Convert.ToString(Des.Deuxieme) + "\n");
                    if(!j.EstEnPrison)
                        txtboxConsole.AppendText(j.Nom + " avance de : " + resultat + " cases. \n");

                    if (Des.EstDouble() && j.EstEnPrison)
                    {
                        txtboxConsole.AppendText("Doublé, vous pouvez sortir de prison et rejouer !\n");
                        txtboxConsole.AppendText(j.Nom + " avance de : " + resultat + " cases. \n");
                        j.estDouble = true;
                        j.nbrDouble++;
                    }
                    else if(Des.EstDouble())
                    {
                        txtboxConsole.AppendText("Doublé !\n");
                        j.estDouble = true;
                        j.nbrDouble++;
                    }
                    else if(j.EstEnPrison)
                    {
                        txtboxConsole.AppendText("Vous devez faire un doublé pour sortir de prison. \n");
                        j.estDouble = false;
                        j.nbrDouble = 0;
                        j.nbrTourPrison++;
                    }
                    else
                    {
                        j.estDouble = false;
                        j.nbrDouble = 0;
                    }

                    //se rend à la dernière ligne de la console
                    txtboxConsole.ScrollToEnd();

                    j.Position = Move(position, j, resultat, txtboxConsole);
                    position = j.Position;
                    j.Placement(position, j, pion1, pion2);

                    if (j.estDouble)
                        break;
                    else
                    {
                        j.finTour(listeJoueurs, nbrJoueurs, lblNomJoueur);
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Change la position en fonction de plusieurs facteurs
        /// </summary>
        /// <param name="position"></param>
        public int Move(int position, Joueur j, int resultat, TextBox txtboxConsole)
        {
            position = j.Position;
            position += resultat;

            if(j.EstEnPrison && j.estDouble)
            {
                position = 10 + resultat;
                j.EstEnPrison = false;
            }
            else if(j.nbrTourPrison >= 3)
            {
                j.nbrTourPrison = 0;
                j.EstEnPrison = false;
                position = 10 + resultat;
            }
            else if(j.nbrDouble >= 3)
            {
                txtboxConsole.AppendText("C'est votre 3ème double ! Direction la prison, vous pourrez retenter un double au prochain tour," +
                    " pour sortir de prison. \n");
                position = 40;
                j.EstEnPrison = true;
                j.nbrDouble = 0;
                j.estDouble = false;
            }
            else if(position > 39 && j.EstEnPrison == false)
            {
                position -= 40;
            }

            return position;
        }

        /// <summary>
        /// Evénement lors du clic sur btnDk
        /// </summary>
        public void clicbtnDk(Rectangle pion1, Rectangle pion2, TextBox txtboxConsole, Button btnDk, Label lblPion, Button btnLanceDes,
            Label lblNomJoueur)
        {
            foreach(Joueur j in listeJoueurs)
            {
                if(j.sonTour == true)
                {
                    //TODOCORENTIN Fonctionne pour 2 joueurs uniquement
                    if(j.Numero == 1 && j.sonTour == true)
                    {
                        pion1.Fill = new ImageBrush(new BitmapImage(new Uri(@"..\..\Images\39px-ClassIcon_deathknightFOND.png", UriKind.Relative)));
                        txtboxConsole.AppendText(j.Nom + " a choisi le chevalier de la mort." + "\n");
                        txtboxConsole.AppendText("Le joueur 2 choisit son pion : " + "\n");
                        j.finTour(listeJoueurs, nbrJoueurs, lblNomJoueur);
                        btnDk.Visibility = Visibility.Hidden;
                        break;
                    }
                    else if(j.Numero == 2 && j.sonTour == true)
                    {
                        pion2.Fill = new ImageBrush(new BitmapImage(new Uri(@"..\..\Images\39px-ClassIcon_deathknightFOND.png", UriKind.Relative)));
                        txtboxConsole.AppendText(j.Nom + " a choisi le chevalier de la mort." + "\n");
                        btnLanceDes.Visibility = Visibility.Visible;
                        lblPion.Visibility = Visibility.Hidden;
                        j.finTour(listeJoueurs, nbrJoueurs, lblNomJoueur);
                        btnDk.Visibility = Visibility.Hidden;
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Evénement lors du clic sur btnMage
        /// </summary>
        public void clicbtnMage(Rectangle pion1, Rectangle pion2, TextBox txtboxConsole, Button btnMage, Label lblPion, Button btnLanceDes, 
            Label lblNomJoueur)
        {
            foreach (Joueur j in listeJoueurs)
            {
                if (j.sonTour == true)
                {
                    //TODOCORENTIN Fonctionne pour 2 joueurs uniquement
                    if (j.Numero == 1 && j.sonTour == true)
                    {
                        pion1.Fill = new ImageBrush(new BitmapImage(new Uri(@"..\..\Images\39px-ClassIcon_mageFOND.png", UriKind.Relative)));
                        txtboxConsole.AppendText(j.Nom + " a choisi le mage." + "\n");
                        txtboxConsole.AppendText("Le joueur 2 choisit son pion : " + "\n");
                        j.finTour(listeJoueurs, nbrJoueurs, lblNomJoueur);
                        btnMage.Visibility = Visibility.Hidden;
                        break;
                    }
                    else if (j.Numero == 2 && j.sonTour == true)
                    {
                        pion2.Fill = new ImageBrush(new BitmapImage(new Uri(@"..\..\Images\39px-ClassIcon_mageFOND.png", UriKind.Relative)));
                        txtboxConsole.AppendText(j.Nom + " a choisi le mage." + "\n");
                        btnLanceDes.Visibility = Visibility.Visible;
                        lblPion.Visibility = Visibility.Hidden;
                        j.finTour(listeJoueurs, nbrJoueurs, lblNomJoueur);
                        btnMage.Visibility = Visibility.Hidden;
                        break;
                    }
                }
            }
        }

        #endregion
    }
}
