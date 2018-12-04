#region NAMESPACE
using MonopolyVS.Modeles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
#endregion

namespace MonopolyVS
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Des Des = new Des();
        Joueur J1 = new Joueur();
        Joueur J2 = new Joueur();

        public MainWindow()
        {
            InitializeComponent();
            btnLanceDes.Visibility = Visibility.Hidden;
            J1.sonTour = true;
            J2.sonTour = false;
            txtboxConsole.AppendText("Le joueur 1 choisit son pion : " + "\n");
        }

        private void btnLanceDes_Click(object sender, RoutedEventArgs e)
        {
            int resultat = 0;
            int position = 0;

            Des.Lancer();   //lancement des dés

            //Affichage à la suite du résultat du lancé et affiche si le lanceur fait un doublé
            txtboxConsole.AppendText("\nLe premier dé affiche un " + Convert.ToString(Des.Premier) + "\n");
            txtboxConsole.AppendText("Le deuxième dé affiche un " + Convert.ToString(Des.Deuxieme) + "\n");

            if(J1.sonTour)
            {
                txtboxConsole.AppendText("Le joueur 1 avance de : " + Convert.ToString(Des.Resultat) + " cases. \n");
            }
            else if(J2.sonTour)
            {
                txtboxConsole.AppendText("Le joueur 2 avance de : " + Convert.ToString(Des.Resultat) + " cases. \n");
            }

            resultat = Des.Resultat;

            if (Des.EstDouble())
                txtboxConsole.AppendText("Doublé !\n");

            txtboxConsole.ScrollToEnd();    //se rend à la dernière ligne de la console

            position = Deplacement(resultat);
            Placement(position);
        }

        public int Deplacement(int resultat)
        {
            if(J1.nbrDouble > 0)
            {
                J2.nbrDouble = 0;

                if (J1.nbrDouble == 3)
                {
                    //Le pion va en prison
                    return J1.Position = 10;
                }
                else
                {
                    J1.Position = J1.Position + resultat;

                    if (J1.Position >= 40)
                    {
                        J1.Position = J1.Position - 40;
                    }

                    return J1.Position;
                }
            }
            else if(J2.nbrDouble > 0)
            {
                J1.nbrDouble = 0;

                if (J2.nbrDouble == 3)
                {
                    //Le pion va en prison
                    return J2.Position = 10;
                }
                else
                {
                    J2.Position = J2.Position + resultat;

                    if (J2.Position >= 40)
                    {
                        J2.Position = J2.Position - 40;
                    }

                    return J2.Position;
                }
            }
            else
            {
                if (J1.sonTour)
                {
                    J1.sonTour = false;
                    J2.sonTour = true;
                    J2.nbrDouble = 0;

                    J1.Position = J1.Position + resultat;

                    if(J1.Position >= 40)
                    {
                        J1.Position = J1.Position - 40;
                    }

                    return J1.Position;
                }
                else
                {
                    J2.sonTour = false;
                    J1.sonTour = true;
                    J1.nbrDouble = 0;

                    J2.Position = J2.Position + resultat;

                    if (J2.Position >= 40)
                    {
                        J2.Position = J2.Position - 40;
                    }

                    return J2.Position;
                }
            }
        }

        public void setValueCanvas(double top1, double left1, double top2, double left2)
        {
            if (J2.sonTour)
            {
                pion1.SetValue(Canvas.TopProperty, top1);
                pion1.SetValue(Canvas.LeftProperty, left1);
            }
            else
            {
                pion2.SetValue(Canvas.TopProperty, top2);
                pion2.SetValue(Canvas.LeftProperty, left2);
            }
        }

        public void Placement(int position)
        {
            switch(position)
            {
                case (0):
                    setValueCanvas(0.0, 0.0, 0.0, 0.0);
                    break;
                case (1):
                    setValueCanvas(0.0, -95.0, 0.0, -100.0);
                    break;
                case (2):
                    setValueCanvas(0.0, -165.0, 0.0, -175.0);
                    break;
                case (3):
                    setValueCanvas(0.0, -239.0, 0.0, -244.0);
                    break;
                case (4):
                    setValueCanvas(0.0, -314.0, 0.0, -319.0);
                    break;
                case (5):
                    setValueCanvas(0.0, -387.0, 0.0, -392.0);
                    break;
                case (6):
                    setValueCanvas(0.0, -461.0, 0.0, -466.0);
                    break;
                case (7):
                    setValueCanvas(0.0, -532.0, 0.0, -537.0);
                    break;
                case (8):
                    setValueCanvas(0.0, -606.0, 0.0, -611.0);
                    break;
                case (9):
                    setValueCanvas(0.0, -680.0, 0.0, -685.0);
                    break;
                case (10):
                    //Case Prison (VISITEUR !)
                    setValueCanvas(0.0, -795.0, 26.0, -770.0);
                    break;
                case (11):
                    setValueCanvas(-83.0, -777.0, -74.0, -782.0);
                    break;
                case (12):
                    setValueCanvas(-143.0, -777.0, -134.0, -782.0);
                    break;
                case (13):
                    setValueCanvas(-203.0, -777.0, -194.0, -782.0);
                    break;
                case (14):
                    setValueCanvas(-263.0, -777.0, -254.0, -782.0);
                    break;
                case (15):
                    setValueCanvas(-323.0, -777.0, -314.0, -782.0);
                    break;
                case (16):
                    setValueCanvas(-383.0, -777.0, -374.0, -782.0);
                    break;
                case (17):
                    setValueCanvas(-443.0, -777.0, -434.0, -782.0);
                    break;
                case (18):
                    setValueCanvas(-503.0, -777.0, -494.0, -782.0);
                    break;
                case (19):
                    setValueCanvas(-563.0, -777.0, -554.0, -782.0);
                    break;
                case (20):
                    setValueCanvas(-655.0, -777.0, -645.0, -782.0);
                    break;
                case (21):
                    setValueCanvas(-655.0, -680.0, -645.0, -685.0);
                    break;
                case (22):
                    setValueCanvas(-655.0, -606.0, -645.0, -611.0);
                    break;
                case (23):
                    setValueCanvas(-655.0, -532.0, -645.0, -537.0);
                    break;
                case (24):
                    setValueCanvas(-655.0, -461.0, -645.0, -466.0);
                    break;
                case (25):
                    setValueCanvas(-655.0, -387.0, -645.0, -392.0);
                    break;
                case (26):
                    setValueCanvas(-655.0, -314.0, -645.0, -319.0);
                    break;
                case (27):
                    setValueCanvas(-655.0, -239.0, -645.0, -244.0);
                    break;
                case (28):
                    setValueCanvas(-655.0, -165.0, -645.0, -175.0);
                    break;
                case (29):
                    setValueCanvas(-655.0, -95.0, -645.0, -100.0);
                    break;
                case (30):
                    setValueCanvas(-655.0, 0.0, -645.0, 0.0);
                    break;
                case (31):
                    setValueCanvas(-563.0, 10.0, -554.0, 4.0);
                    break;
                case (32):
                    setValueCanvas(-503.0, 10.0, -494.0, 4.0);
                    break;
                case (33):
                    setValueCanvas(-443.0, 10.0, -434.0, 4.0);
                    break;
                case (34):
                    setValueCanvas(-383.0, 10.0, -374.0, 4.0);
                    break;
                case (35):
                    setValueCanvas(-323.0, 10.0, -314.0, 4.0);
                    break;
                case (36):
                    setValueCanvas(-263.0, 10.0, -254.0, 4.0);
                    break;
                case (37):
                    setValueCanvas(-203.0, 10.0, -194.0, 4.0);
                    break;
                case (38):
                    setValueCanvas(-143.0, 10.0, -134.0, 4.0);
                    break;
                case (39):
                    setValueCanvas(-83.0, 10.0, -74.0, 4.0);
                    break;
            }
        }

        private void btnDk_Click(object sender, RoutedEventArgs e)
        {
            if (pion1.Fill == null)
            {
                pion1.Fill = new ImageBrush(new BitmapImage(new Uri(@"E:\ProjetMonopoly\Monopoly\MonopolyVS\MonopolyVS\Images\39px-ClassIcon_deathknightFOND.png", UriKind.Relative)));
                txtboxConsole.AppendText("Vous avez choisi le chevalier de la mort." + "\n");
                txtboxConsole.AppendText("Le joueur 2 choisit son pion : " + "\n");
                btnDk.Visibility = Visibility.Hidden;
            }
            else if (pion2.Fill == null)
            {
                pion2.Fill = new ImageBrush(new BitmapImage(new Uri(@"E:\ProjetMonopoly\Monopoly\MonopolyVS\MonopolyVS\Images\39px-ClassIcon_deathknightFOND.png", UriKind.Relative)));
                txtboxConsole.AppendText("Vous avez choisi le chevalier de la mort." + "\n");
                btnLanceDes.Visibility = Visibility.Visible;
                btnDk.Visibility = Visibility.Hidden;
                btnMage.Visibility = Visibility.Hidden;
                lblPion.Visibility = Visibility.Hidden;
            }
                

        }

        private void btnMage_Click(object sender, RoutedEventArgs e)
        {
            if (pion1.Fill == null)
            {
                pion1.Fill = new ImageBrush(new BitmapImage(new Uri(@"E:\ProjetMonopoly\Monopoly\MonopolyVS\MonopolyVS\Images\39px-ClassIcon_mageFOND.png", UriKind.Relative)));
                txtboxConsole.AppendText("Vous avez choisi le mage." + "\n");
                txtboxConsole.AppendText("Le joueur 2 choisit son pion : " + "\n");
                btnMage.Visibility = Visibility.Hidden;
            }
                
            else if (pion2.Fill == null)
            {
                pion2.Fill = new ImageBrush(new BitmapImage(new Uri(@"E:\ProjetMonopoly\Monopoly\MonopolyVS\MonopolyVS\Images\39px-ClassIcon_mageFOND.png", UriKind.Relative)));
                txtboxConsole.AppendText("Vous avez choisi le mage." + "\n");
                btnLanceDes.Visibility = Visibility.Visible;
                btnDk.Visibility = Visibility.Hidden;
                btnMage.Visibility = Visibility.Hidden;
                lblPion.Visibility = Visibility.Hidden;
            }  
        }
    }
}