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

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnLanceDes_Click(object sender, RoutedEventArgs e)
        {
            Des.Lancer();
            txtboxConsole.AppendText("\nLe premier dé affiche un " + Convert.ToString(Des.RecuperePremier()) + "\n");
            txtboxConsole.AppendText("Le deuxième dé affiche un " + Convert.ToString(Des.RecupereDeuxieme()) + "\n");
            if (Des.EstDouble() == true)
                txtboxConsole.AppendText("Doublé\n");
            txtboxConsole.ScrollToEnd();
        }

        private void btnDk_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnMage_Click(object sender, RoutedEventArgs e)
        {
            // do smt
        }
    }
}
