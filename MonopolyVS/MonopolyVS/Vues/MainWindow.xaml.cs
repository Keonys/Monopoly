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
        Controleur c = new Controleur();

        public MainWindow()
        {
            InitializeComponent();
            //TODOLORENZO la fonction prepareVisible() sera à mettre dans la fonction de ton bouton "jouer"
            prepareInvisible();
            //afficheFormulaire();
        }

        #region Events

        /// <summary>
        /// Rend invisible certaines partie de la fenêtre
        /// </summary>
        private void prepareInvisible()
        {
            c.prepareInvisible(lblTour, lblNomJoueur, lblPion, btnDk, btnMage, btnLanceDes);
        }

        /// <summary>
        /// Affichage de l'écran d'accueil (avant l'affichage du plateau)
        /// </summary>
        private void afficheFormulaire()
        {
            c.afficheFormulaire(this);
        }

        private void btnLanceDes_Click(object sender, RoutedEventArgs e)
        {
            c.clicBtnLanceDes(txtboxConsole, pion1, pion2, lblNomJoueur);
        }

        private void btnDk_Click(object sender, RoutedEventArgs e)
        {
            c.clicbtnDk(pion1, pion2, txtboxConsole, btnDk, lblPion, btnLanceDes, lblNomJoueur);
        }
 
        private void btnMage_Click(object sender, RoutedEventArgs e)
        {
            c.clicbtnMage(pion1, pion2, txtboxConsole, btnMage, lblPion, btnLanceDes, lblNomJoueur);
        }

        private void BtnTour_Click(object sender, RoutedEventArgs e)
        {
            c.clicbtnTour(txtboxConsole, btnTour, lblTour, lblNomJoueur, lblPion, btnDk, btnMage);
        }

        #endregion Events
    }
}