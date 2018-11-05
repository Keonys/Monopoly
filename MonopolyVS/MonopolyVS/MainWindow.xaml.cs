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
            txtboxConsole.AppendText("Le joueur 1 choisit son pion : " + "\n");
        }

        private void btnLanceDes_Click(object sender, RoutedEventArgs e)
        {
            Des.Lancer();
            txtboxConsole.AppendText("\nLe premier dé affiche un " + Convert.ToString(Des.Premier) + "\n");
            txtboxConsole.AppendText("Le deuxième dé affiche un " + Convert.ToString(Des.Deuxieme) + "\n");
            if (Des.EstDouble() == true)
                txtboxConsole.AppendText("Doublé\n");
            txtboxConsole.ScrollToEnd();
        }

        private void btnDk_Click(object sender, RoutedEventArgs e)
        {
            if (pion1.Fill == null)
            {
                pion1.Fill = new ImageBrush(new BitmapImage(new Uri(@"E:\ProjetMonopoly\Monopoly\MonopolyVS\MonopolyVS\Images\39px-ClassIcon_deathknightFOND.png", UriKind.Relative)));
                txtboxConsole.AppendText("Vous avez choisi le chevalier de la mort." + "\n");
                txtboxConsole.AppendText("Le joueur 2 choisit son pion : " + "\n");
            }
            else if (pion2.Fill == null)
            {
                pion2.Fill = new ImageBrush(new BitmapImage(new Uri(@"E:\ProjetMonopoly\Monopoly\MonopolyVS\MonopolyVS\Images\39px-ClassIcon_deathknightFOND.png", UriKind.Relative)));
                txtboxConsole.AppendText("Vous avez choisi le chevalier de la mort." + "\n");
                btnLanceDes.Visibility = Visibility.Visible;
            }
                

        }

        private void btnMage_Click(object sender, RoutedEventArgs e)
        {
            if (pion1.Fill == null)
            {
                pion1.Fill = new ImageBrush(new BitmapImage(new Uri(@"E:\ProjetMonopoly\Monopoly\MonopolyVS\MonopolyVS\Images\39px-ClassIcon_mageFOND.png", UriKind.Relative)));
                txtboxConsole.AppendText("Vous avez choisi le mage." + "\n");
                txtboxConsole.AppendText("Le joueur 2 choisit son pion : " + "\n");
            }
                

            else if (pion2.Fill == null)
            {
                pion2.Fill = new ImageBrush(new BitmapImage(new Uri(@"E:\ProjetMonopoly\Monopoly\MonopolyVS\MonopolyVS\Images\39px-ClassIcon_mageFOND.png", UriKind.Relative)));
                txtboxConsole.AppendText("Vous avez choisi le mage." + "\n");
                btnLanceDes.Visibility = Visibility.Visible;
            }
                
        }
    }
}