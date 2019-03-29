#region NAMESPACE
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
using System.Windows.Shapes;
using MonopolyVS.Controleurs;
#endregion

namespace MonopolyVS.Modeles
{
    /// <summary>
    /// Logique d'interaction pour FormulaireJoueur.xaml
    /// </summary>
    public partial class FormulaireJoueur : Window
    {
        bool pretAJouer = false;
        MainWindow Principal;
        Controleur control = new Controleur();
        //TODOCORENTIN Créer les pion ici (les 4 pions, et oui)
        Rectangle pion1 = new Rectangle();
        Rectangle pion2 = new Rectangle();
        Rectangle pion3 = new Rectangle();
        Rectangle pion4 = new Rectangle();

        public FormulaireJoueur(MainWindow m, Controleur c, Rectangle Pion1, Rectangle Pion2, Rectangle Pion3, Rectangle Pion4)
        {
            InitializeComponent();
            Principal = m;
            control = c;
            pion1 = Pion1;
            pion2 = Pion2;
            pion3 = Pion3;
            pion4 = Pion4;
        }

        private void ButtonEntrer_Click_1(object sender, RoutedEventArgs e)
        {
            //Lors du click sur le bouton jouer, le logo disparais et laisse place au choix du nom des joueurs ainsi que leurs pions
            TabMenuPrinc.SelectedItem = TabUser;
            TextBoxNom1.IsEnabled = true;
            LabelJetons.Content = "Veuillez sélectionner des jetons" + "\n" + "et des noms différents pour" + "\n" + "chaques joueurs.";
        }

        private void FormulaireJoueur1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
            if (pretAJouer == false)
            {
                Application.Current.Shutdown();
            }
            else Principal.Visibility = Visibility.Visible;
        }

        #region JOUEUR1
        private void ComboIcones1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboIcones2.SelectedIndex >= 0 && TextBoxNom1.Text != "" && TextBoxNom2.Text != "")
                ButtonValider.IsEnabled = true;
            else ButtonValider.IsEnabled = false;

            //Affiche le Pion de la classe selectionné
            control.choixPion(ComboIcones1, ImageIcone);
        }

        private void TextBoxNom1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (ComboIcones1.SelectedIndex >= 0 && ComboIcones2.SelectedIndex >= 0
               && TextBoxNom1.Text != "" && TextBoxNom2.Text != "")
                ButtonValider.IsEnabled = true;
            else ButtonValider.IsEnabled = false;

            if (TextBoxNom1.Text != "")
            {
                if (TextBoxNom3.Text != "")
                {
                    ComboIcones3.IsEnabled = true;
                    TextBoxNom3.IsEnabled = true;
                }
                if (TextBoxNom4.Text != "")
                {
                    ComboIcones4.IsEnabled = true;
                    TextBoxNom4.IsEnabled = true;
                }

                ComboIcones2.IsEnabled = true;
                TextBoxNom2.IsEnabled = true;
            }
            else
            {
                ComboIcones2.IsEnabled = false;
                TextBoxNom2.IsEnabled = false;
                ComboIcones3.IsEnabled = false;
                TextBoxNom3.IsEnabled = false;
                ComboIcones4.IsEnabled = false;
                TextBoxNom4.IsEnabled = false;
            }
        }
        #endregion

        #region JOUEUR2
        private void ComboIcones2_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (TextBoxNom1.Text != "" && TextBoxNom2.Text != "")
                ButtonValider.IsEnabled = true;
            else ButtonValider.IsEnabled = false;

            //Affiche le Pion de la classe selectionné
            control.choixPion(ComboIcones2, ImageIcone2);
        }
        
        private void TextBoxNom2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (ComboIcones1.SelectedIndex >= 0 && ComboIcones2.SelectedIndex >= 0
               && TextBoxNom1.Text != "" && TextBoxNom2.Text != "")
                ButtonValider.IsEnabled = true;
            else ButtonValider.IsEnabled = false;

            if (TextBoxNom2.Text != "" && TextBoxNom1.Text != "")
            {
                if (TextBoxNom4.Text != "")
                {
                    ComboIcones4.IsEnabled = true;
                    TextBoxNom4.IsEnabled = true;
                }

                ComboIcones3.IsEnabled = true;
                TextBoxNom3.IsEnabled = true;
            }
            else
            {
                ComboIcones3.IsEnabled = false;
                TextBoxNom3.IsEnabled = false;
                ComboIcones4.IsEnabled = false;
                TextBoxNom4.IsEnabled = false;
            }
        }
        #endregion

        #region JOUEUR3
        private void ComboIcones3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Affiche le Pion de la classe selectionné
            control.choixPion(ComboIcones3, ImageIcone3);
        }

        private void TextBoxNom3_TextChanged(object sender, TextChangedEventArgs e)
        {
           if (TextBoxNom3.Text != "")
            {
                ComboIcones4.IsEnabled = true;
                TextBoxNom4.IsEnabled = true;
            }
            else
            {
                ComboIcones4.IsEnabled = false;
                TextBoxNom4.IsEnabled = false;
            }
        }
        #endregion

        #region JOUEUR4
        private void ComboIcones4_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Affiche le Pion de la classe selectionné
            control.choixPion(ComboIcones4, ImageIcone4);
        }
        #endregion

        private void Valider_Click(object sender, RoutedEventArgs e)
        {
            //Check si jeton est selectionné quand nom joueur 3 entré
            if (ComboIcones3.SelectedIndex < 0 && TextBoxNom3.Text != "")
                LabelJetons.Visibility = Visibility.Visible;

            //Check si jeton est selectionné quand nom joueur 4 entré
            if (ComboIcones4.SelectedIndex < 0 && TextBoxNom4.Text != "")
                LabelJetons.Visibility = Visibility.Visible;
            
            if (ComboIcones3.SelectedIndex >= 0 && TextBoxNom3.Text != "")
            {
                if (ComboIcones4.SelectedIndex >= 0 && TextBoxNom4.Text != "")
                {
                    //Check si tout les 4 joueurs ont des jetons & noms différents
                    if (ComboIcones1.SelectedIndex == ComboIcones2.SelectedIndex || ComboIcones1.SelectedIndex == ComboIcones3.SelectedIndex
                        || ComboIcones1.SelectedIndex == ComboIcones4.SelectedIndex || ComboIcones2.SelectedIndex == ComboIcones3.SelectedIndex
                        || ComboIcones2.SelectedIndex == ComboIcones4.SelectedIndex || ComboIcones3.SelectedIndex == ComboIcones4.SelectedIndex
                        || TextBoxNom1.Text == TextBoxNom2.Text || TextBoxNom1.Text == TextBoxNom3.Text
                        || TextBoxNom1.Text == TextBoxNom4.Text || TextBoxNom2.Text == TextBoxNom3.Text
                        || TextBoxNom2.Text == TextBoxNom4.Text || TextBoxNom3.Text == TextBoxNom4.Text)
                        LabelJetons.Visibility = Visibility.Visible;
                    else
                    {
                        control.AddJoueurs(TextBoxNom1.Text, TextBoxNom2.Text, TextBoxNom3.Text, TextBoxNom4.Text, 4,
                            pion1, pion2, pion3, pion4, ComboIcones1, ComboIcones2, ComboIcones3, ComboIcones4);
                        pretAJouer = true;
                        FormulaireJoueur1.Close();
                    }
                }
                else
                {
                    //Check si tout les 3 joueurs ont des jetons & noms différents
                    if (ComboIcones1.SelectedIndex == ComboIcones2.SelectedIndex || ComboIcones1.SelectedIndex == ComboIcones3.SelectedIndex
                        || ComboIcones2.SelectedIndex == ComboIcones3.SelectedIndex
                        || TextBoxNom1.Text == TextBoxNom2.Text || TextBoxNom1.Text == TextBoxNom3.Text || TextBoxNom2.Text == TextBoxNom3.Text)
                        LabelJetons.Visibility = Visibility.Visible;
                    else
                    {
                        control.AddJoueurs(TextBoxNom1.Text, TextBoxNom2.Text, TextBoxNom3.Text, TextBoxNom4.Text, 3,
                            pion1, pion2, pion3, pion4, ComboIcones1, ComboIcones2, ComboIcones3, ComboIcones4);
                        pretAJouer = true;
                        FormulaireJoueur1.Close();
                    }
                }
            }
            else
            {
                //Check si les 2 joueurs ont des jetons & noms différents
                if (ComboIcones1.SelectedIndex == ComboIcones2.SelectedIndex || TextBoxNom1.Text == TextBoxNom2.Text)
                    LabelJetons.Visibility = Visibility.Visible;
                else
                {
                    control.AddJoueurs(TextBoxNom1.Text, TextBoxNom2.Text, TextBoxNom3.Text, TextBoxNom4.Text, 2,
                        pion1, pion2, pion3, pion4, ComboIcones1, ComboIcones2, ComboIcones3, ComboIcones4);
                    pretAJouer = true;
                    FormulaireJoueur1.Close();
                }
            }
        }

        
    }

}