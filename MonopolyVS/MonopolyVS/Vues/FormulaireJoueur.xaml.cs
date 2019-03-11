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

        private void ButtonValider_Click(object sender, RoutedEventArgs e)
        {
            //Lors du click sur le bouton jouer, le logo disparais et laisse place au choix du nom des joueurs ainsi que leurs pions
            TabMenuPrinc.SelectedItem = TabUser;
            TextBoxNom1.IsEnabled = true;
        }

        private void FormulaireJoueur1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }


        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        
        
        /*private void ComboIcones1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (ComboIcones1.SelectedItem)
            {
                case "Death Knight":
                    ImageIcone.Source = new BitmapImage(new Uri(@"../Images/39px-ClassIcon_deathknight.png"));
                    break;
            }
        }*/
    }
            
}

