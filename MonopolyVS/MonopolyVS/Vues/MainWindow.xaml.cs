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
        /// <summary>
        /// Permet les appels de la vue vers le controleur
        /// </summary>
        Controleur c = new Controleur();

        /// <summary>
        /// Liste des cases
        /// </summary>
        List<Case> listeCases = new List<Case>();

        public MainWindow()
        {
            InitializeComponent();
            initAppli();
            afficheFormulaire();
        }

        #region Events

        /// <summary>
        /// Rend invisible certaines partie de la fenêtre
        /// </summary>
        private void prepareInvisible()
        {
            c.initAppli(lblTour, lblNomJoueur, lblPion, btnLanceDes, lblArgent, lblArgentJoueur, btnListe1, btnListe2
                , btnListe3, btnListe4, lblWin, pionWin, btnFinPartie);
        }

        /// <summary>
        /// Affichage de l'écran d'accueil (avant l'affichage du plateau)
        /// </summary>
        private void afficheFormulaire()
        {
            c.afficheFormulaire(this, pion1, pion2, pion3, pion4);
        }

        private void btnLanceDes_Click(object sender, RoutedEventArgs e)
        {
            c.clicBtnLanceDes(txtboxConsole, pion1, pion2, lblNomJoueur, lblArgentJoueur, listeCases, imgSortie, btnListe1, btnListe2, btnListe3, btnListe4,
                btnLanceDes, lblArgent, lblPion, btnTour, lblTour, btnFinPartie, pionWin, lblWin);
        }

        private void BtnTour_Click(object sender, RoutedEventArgs e)
        {
            c.clicbtnTour(txtboxConsole, btnTour, lblTour, lblNomJoueur, lblPion, lblArgentJoueur,
                btnListe1, btnListe2, btnListe3, btnListe4, imgSortie, pion1, pion2, pion3, pion4, btnLanceDes, lblArgent, btnFinPartie, pionWin, lblWin);
        }

        private void BtnListe1_Click(object sender, RoutedEventArgs e)
        {
            c.clicListe1(listboxBien);
        }

        private void BtnListe2_Click(object sender, RoutedEventArgs e)
        {
            c.clicListe2(listboxBien);
        }

        private void BtnListe3_Click(object sender, RoutedEventArgs e)
        {
            c.clicListe3(listboxBien);
        }

        private void BtnListe4_Click(object sender, RoutedEventArgs e)
        {
            c.clicListe4(listboxBien);
        }

        private void ListboxBien_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (c.CheckPropriete(listboxBien.SelectedItem) == true)
                c.debuterVente(listboxBien.SelectedItem);
        }

        private void btnFinPartie_Click(object sender, RoutedEventArgs e)
        {
            c.clicFinPartie();
        }

        #endregion Events

        /// <summary>
        /// Initalise l'appli
        /// </summary>
        private void initAppli()
        {
            c.initAppli(lblTour, lblNomJoueur, lblPion, btnLanceDes, lblArgent, lblArgentJoueur, btnListe1, btnListe2,
                btnListe3, btnListe4, lblWin, pionWin, btnFinPartie);

            #region INITIALISATION DES CASES
            listeCases.Add(new Case(1, Maison1_1, Maison1_2, Maison1_3, Maison1_4, Hotel1, RectAppartBrun1));
            listeCases.Add(new Case(3, Maison3_1, Maison3_2, Maison3_3, Maison3_4, Hotel3, RectAppartBrun2));
            listeCases.Add(new Case(5, RectAppartDonjon1));
            listeCases.Add(new Case(6, Maison6_1, Maison6_2, Maison6_3, Maison6_4, Hotel6, RectAppartBleu1));
            listeCases.Add(new Case(8, Maison8_1, Maison8_2, Maison8_3, Maison8_4, Hotel8, RectAppartBleu2));
            listeCases.Add(new Case(9, Maison9_1, Maison9_2, Maison9_3, Maison9_4, Hotel9, RectAppartBleu3));
            listeCases.Add(new Case(11, Maison11_1, Maison11_2, Maison11_3, Maison11_4, Hotel11, RectAppartRose1));
            listeCases.Add(new Case(13, Maison13_1, Maison13_2, Maison13_3, Maison13_4, Hotel13, RectAppartRose2));
            listeCases.Add(new Case(14, Maison14_1, Maison14_2, Maison14_3, Maison14_4, Hotel14, RectAppartRose3));
            listeCases.Add(new Case(15, RectAppartDonjon2));
            listeCases.Add(new Case(16, Maison16_1, Maison16_2, Maison16_3, Maison16_4, Hotel16, RectAppartOrange1));
            listeCases.Add(new Case(18, Maison18_1, Maison18_2, Maison18_3, Maison18_4, Hotel18, RectAppartOrange2));
            listeCases.Add(new Case(19, Maison19_1, Maison19_2, Maison19_3, Maison19_4, Hotel19, RectAppartOrange3));
            listeCases.Add(new Case(21, Maison21_1, Maison21_2, Maison21_3, Maison21_4, Hotel21, RectAppartRouge1));
            listeCases.Add(new Case(23, Maison23_1, Maison23_2, Maison23_3, Maison23_4, Hotel23, RectAppartRouge2));
            listeCases.Add(new Case(24, Maison24_1, Maison24_2, Maison24_3, Maison24_4, Hotel24, RectAppartRouge3));
            listeCases.Add(new Case(25, RectAppartDonjon3));
            listeCases.Add(new Case(26, Maison26_1, Maison26_2, Maison26_3, Maison26_4, Hotel26, RectAppartJaune1));
            listeCases.Add(new Case(27, Maison27_1, Maison27_2, Maison27_3, Maison27_4, Hotel27, RectAppartJaune2));
            listeCases.Add(new Case(29, Maison29_1, Maison29_2, Maison29_3, Maison29_4, Hotel29, RectAppartJaune3));
            listeCases.Add(new Case(31, Maison31_1, Maison31_2, Maison31_3, Maison31_4, Hotel31, RectAppartVert1));
            listeCases.Add(new Case(32, Maison32_1, Maison32_2, Maison32_3, Maison32_4, Hotel32, RectAppartVert2));
            listeCases.Add(new Case(34, Maison34_1, Maison34_2, Maison34_3, Maison34_4, Hotel34, RectAppartVert3));
            listeCases.Add(new Case(35, RectAppartDonjon4));
            listeCases.Add(new Case(37, Maison37_1, Maison37_2, Maison37_3, Maison37_4, Hotel37, RectAppartViolet1));
            listeCases.Add(new Case(39, Maison39_1, Maison39_2, Maison39_3, Maison39_4, Hotel39, RectAppartViolet2));

            foreach(Case c in listeCases)
            {
                if (c.Maison1 != null)
                {
                    c.Maison1.Visibility = Visibility.Hidden;
                    c.Maison2.Visibility = Visibility.Hidden;
                    c.Maison3.Visibility = Visibility.Hidden;
                    c.Maison4.Visibility = Visibility.Hidden;
                    c.NomHotel.Visibility = Visibility.Hidden;
                }
            }
            #endregion

            imgSortie.Visibility = Visibility.Hidden;
        }
    }
}