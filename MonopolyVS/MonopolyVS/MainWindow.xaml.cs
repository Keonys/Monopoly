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
        Modeles.Des Des = new Modeles.Des();

        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void ButtonLanceDes_Click(object sender, RoutedEventArgs e)
        {
            Des.Lancer();
            TextBoxConsole.AppendText("\nLe premier dé affiche un " + Convert.ToString(Des.Premier) + "\n");
            TextBoxConsole.AppendText("Le deuxième dé affiche un " + Convert.ToString(Des.Deuxieme) + "\n");
            if (Des.EstDouble() == true)
                TextBoxConsole.AppendText("Doublé\n");
            TextBoxConsole.ScrollToEnd();
        }
    }
}
