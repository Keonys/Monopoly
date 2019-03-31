using MonopolyVS.Controleurs;
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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MonopolyVS.Vues
{
    /// <summary>
    /// Logique d'interaction pour FormulaireAchat.xaml
    /// </summary>
    public partial class FormulaireAchat : Window
    {
        private bool Hotel;
        Banque B;
        Joueur Acheteur;
        Propriete Constructible;
        Controleur control;

        public FormulaireAchat()
        {
            InitializeComponent();
        }

        public FormulaireAchat(int type, Banque b, Joueur acheteur, Propriete construct, Controleur c)
        {
            InitializeComponent();
            B = b;
            Acheteur = acheteur;
            Constructible = construct;
            control = c;

            if (type == 1)
                Hotel = true;

            initForm(Hotel);
        }

        private void initForm(bool hotel)
        {
            if (hotel)
            {
                LabelMaisons.Visibility = Visibility.Hidden;
                ComboMaisons.Visibility = Visibility.Hidden;
                ButtonValider.Visibility = Visibility.Hidden;
                ButtonValider.IsEnabled = false;
                LabelPrix.Content = "Prix : " + Constructible.PrixMaison + " PO";
            }
            else
            {
                ButtonHotel.Visibility = Visibility.Hidden;
                ButtonValider.IsEnabled = false;
                int nbrMax = B.NbrMaisonAchetable(Acheteur, Constructible, control.listePropriete);
                for(int i = 0; i < nbrMax; i++)
                {
                    ComboMaisons.Items.Add(i + 1);
                }
            }
                

                
        }

        private void ComboMaisons_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ButtonValider.IsEnabled = true;
            LabelPrix.Content = "Prix : " + Constructible.PrixMaison * Convert.ToInt32(ComboMaisons.SelectedItem) + " PO";
        }
        private void ButtonValider_Click(object sender, RoutedEventArgs e)
        {
            B.ConstruireMaison(Convert.ToInt32(ComboMaisons.SelectedItem));
            Acheteur.Argent -= Constructible.PrixMaison * Convert.ToInt32(ComboMaisons.SelectedItem);
            Constructible.NbrMaison += Convert.ToInt32(ComboMaisons.SelectedItem);
            Constructible.configMaison(control.listeCases);
            control.SwitchVerrouFenetre();
            Close();
        }

        private void ButtonHotel_Click(object sender, RoutedEventArgs e)
        {
            B.ConstruireHotel(1);
            Acheteur.Argent -= Constructible.PrixMaison;
            Constructible.Hotel = true;
            Constructible.configMaison(control.listeCases);
            control.SwitchVerrouFenetre();
            Close();
        }

    }
}
