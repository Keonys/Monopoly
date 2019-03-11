#region NAMESPACE
using MonopolyVS.Modeles;
using MonopolyVS.Controleurs;
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
        public MainWindow()
        {
            InitializeComponent();
            this.Visibility = Visibility.Hidden;
            FormulaireJoueur Menu = new FormulaireJoueur();
            Menu.Show();
        }

        #region Events

        private void btnLanceDes_Click(object sender, RoutedEventArgs e)
        {
            Controleur c = new Controleur();
            c.clicBtnLanceDes(txtboxConsole, pion1, pion2);
        }

        private void btnDk_Click(object sender, RoutedEventArgs e)
        {
            Controleur c = new Controleur();
            c.clicbtnDk();
        }
 
        private void btnMage_Click(object sender, RoutedEventArgs e)
        {
            Controleur c = new Controleur();
            c.clicbtnMage();
        }

        #endregion Events
    }
}