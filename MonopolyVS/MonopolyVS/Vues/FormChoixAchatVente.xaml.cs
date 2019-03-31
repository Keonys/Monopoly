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
    /// Logique d'interaction pour FormChoixAchatVente.xaml
    /// </summary>
    public partial class FormChoixAchatVente : Window
    {
        Joueur Vendeur;
        List<Joueur> JoueursEnJeu;
        Propriete Prop;
        Banque B;
        Controleur C;

        public FormChoixAchatVente(Joueur v, List<Joueur> joueursEnJeu, Banque banque, Propriete nomProp, Controleur c)
        {
            InitializeComponent();
            Vendeur = v;
            JoueursEnJeu = joueursEnJeu;
            B = banque;
            Prop = nomProp;
            C = c;
        }

        private void ButtonValider_Click(object sender, RoutedEventArgs e)
        {
            if (RadioVente.IsChecked == true)
            {
                B.initVendPropriete(Prop, Vendeur, JoueursEnJeu, C);
                Close();
            }
            if (RadioAchat.IsChecked == true)
            {
                
            }
            if (RadioHypotheque.IsChecked == true)
            {
                
            }
        }

        private void ButtonAnnuler_Click(object sender, RoutedEventArgs e)
        {
            C.SwitchVerrouFenetre();
            Close();
        }
    }
}
