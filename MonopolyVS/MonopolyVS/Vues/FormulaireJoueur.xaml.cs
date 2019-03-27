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
        public FormulaireJoueur()
        {
            InitializeComponent();
        }

        private void ButtonEntrer_Click_1(object sender, RoutedEventArgs e)
        {
            //Lors du click sur le bouton jouer, le logo disparais et laisse place au choix du nom des joueurs ainsi que leurs pions
            TabMenuPrinc.SelectedItem = TabUser;
            TextBoxNom1.IsEnabled = true;
            LabelJetons.Content = "Veuillez sélectionner des jetons" + "\n" + "différents pour chaques joueurs.";
        }

        private void FormulaireJoueur1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        #region JOUEUR1
        private void ComboIcones1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboIcones2.SelectedIndex >= 0
               && TextBoxNom1.Text != "" && TextBoxNom2.Text != "")
                ButtonValider.IsEnabled = true;
            
            switch (ComboIcones1.SelectedIndex)
            {
                //CASE Death Knight
                case 0:
                    ImageIcone.Fill = new ImageBrush(new BitmapImage(new Uri(@"../../Images/39px-ClassIcon_deathknight.png", UriKind.Relative)));
                    break;
                //CASE Mage
                case 4:
                    ImageIcone.Fill = new ImageBrush(new BitmapImage(new Uri(@"../../Images/39px-ClassIcon_Mage.png", UriKind.Relative)));
                    break;

                default:
                    ImageIcone.Fill = new ImageBrush(new BitmapImage(new Uri(@"../../Images/vide.png", UriKind.Relative)));
                    break;
            }
        }

        private void TextBoxNom1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (ComboIcones1.SelectedIndex >= 0 && ComboIcones2.SelectedIndex >= 0
               && TextBoxNom1.Text != "" && TextBoxNom2.Text != "")
                ButtonValider.IsEnabled = true;

            if (TextBoxNom1.Text != "")
            {
                ComboIcones2.IsEnabled = true;
                TextBoxNom2.IsEnabled = true;
            }
            else
            {
                ComboIcones2.IsEnabled = false;
                TextBoxNom2.IsEnabled = false;
            }
        }
        #endregion

        #region JOUEUR2
        private void ComboIcones2_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (TextBoxNom1.Text != "" && TextBoxNom2.Text != "")
                ButtonValider.IsEnabled = true;

            switch (ComboIcones2.SelectedIndex)
            {
                //CASE Death Knight
                case 0:
                    ImageIcone2.Fill = new ImageBrush(new BitmapImage(new Uri(@"../../Images/39px-ClassIcon_deathknight.png", UriKind.Relative)));
                    break;
                //CASE Mage
                case 4:
                    ImageIcone2.Fill = new ImageBrush(new BitmapImage(new Uri(@"../../Images/39px-ClassIcon_Mage.png", UriKind.Relative)));
                    break;

                default:
                    ImageIcone2.Fill = new ImageBrush(new BitmapImage(new Uri(@"../../Images/vide.png", UriKind.Relative)));
                    break;
            }
        }
        
        private void TextBoxNom2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (ComboIcones1.SelectedIndex >= 0 && ComboIcones2.SelectedIndex >= 0
               && TextBoxNom1.Text != "" && TextBoxNom2.Text != "")
                ButtonValider.IsEnabled = true;

            if (TextBoxNom2.Text != "")
            {
                ComboIcones3.IsEnabled = true;
                TextBoxNom3.IsEnabled = true;
            }
            else
            {
                ComboIcones3.IsEnabled = false;
                TextBoxNom3.IsEnabled = false;
            }
        }
        #endregion

        #region JOUEUR3
        private void ComboIcones3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (ComboIcones3.SelectedIndex)
            {
                //CASE Death Knight
                case 0:
                    ImageIcone3.Fill = new ImageBrush(new BitmapImage(new Uri(@"../../Images/39px-ClassIcon_deathknight.png", UriKind.Relative)));
                    break;
                //CASE Mage
                case 4:
                    ImageIcone3.Fill = new ImageBrush(new BitmapImage(new Uri(@"../../Images/39px-ClassIcon_Mage.png", UriKind.Relative)));
                    break;

                default:
                    ImageIcone3.Fill = new ImageBrush(new BitmapImage(new Uri(@"../../Images/vide.png", UriKind.Relative)));
                    break;
            }
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
            switch (ComboIcones4.SelectedIndex)
            {
                //CASE Death Knight
                case 0:
                    ImageIcone4.Fill = new ImageBrush(new BitmapImage(new Uri(@"../../Images/39px-ClassIcon_deathknight.png", UriKind.Relative)));
                    break;
                //CASE Mage
                case 4:
                    ImageIcone4.Fill = new ImageBrush(new BitmapImage(new Uri(@"../../Images/39px-ClassIcon_Mage.png", UriKind.Relative)));
                    break;

                default:
                    ImageIcone4.Fill = new ImageBrush(new BitmapImage(new Uri(@"../../Images/vide.png", UriKind.Relative)));
                    break;
            }
        }
        #endregion

        private void Valider_Click(object sender, RoutedEventArgs e)
        {
            
        }

        
    }

}