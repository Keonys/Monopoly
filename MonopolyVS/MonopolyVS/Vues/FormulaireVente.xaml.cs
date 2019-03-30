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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MonopolyVS.Vues
{
    /// <summary>
    /// Logique d'interaction pour FormulaireVente.xaml
    /// </summary>
    public partial class FormulaireVente : Window
    {
        private readonly Joueur vendeur;

        List<Joueur> listeJoueurs;
        Banque banque;
        private string prop;

        public FormulaireVente()
        {
            InitializeComponent();
            QuestionVente();
        }

        /// <summary>
        /// Initialise un formulaire de vente
        /// </summary>
        /// <param name="v">Joueur vendeur</param>
        /// <param name="joueursEnJeu">Liste des joueurs en jeu</param>
        /// <param name="b">Banque de la partie</param>
        public FormulaireVente(Joueur v, List<Joueur> joueursEnJeu, Banque b, string nomProp)
        {
            InitializeComponent();
            
            vendeur = v;
            listeJoueurs = joueursEnJeu;
            banque = b;
            prop = nomProp;

            QuestionVente();
        }

        private void ButtonValider_Click(object sender, RoutedEventArgs e)
        {
            if (ComboJoueur.SelectedIndex >= 0 && CheckPrix(TextBoxPrix.Text))
            {
                Joueur acheteur = listeJoueurs[ComboJoueur.SelectedIndex];
                banque.Transaction(acheteur, GetVendeur(), int.Parse(TextBoxPrix.Text));
                Close();
            }
            else if (ComboJoueur.SelectedIndex <= 0)
                LabelInfo.Content = "Choisissez un acheteur.";
        }

        private void QuestionVente()
        {
            this.Visibility = Visibility.Hidden;
            DialogResult vente = System.Windows.Forms.MessageBox.Show("Voulez-vous vendre la propriété : " + prop + " ?", "", MessageBoxButtons.YesNo);
            if (vente == System.Windows.Forms.DialogResult.Yes)
            {
                foreach (Joueur j in listeJoueurs)
                {
                    ComboJoueur.Items.Add(j.Nom);
                }
                this.Visibility = Visibility.Visible;
            }
            else Close();
        }
        
        /// <summary>
        /// Vérifie si le prix en paramètre est un nombre non signé
        /// </summary>
        /// <param name="prix">Prix à vérifier</param>
        /// <returns>Si est un nombre ou pas</returns>
        private bool CheckPrix(string prix)
        {
            bool isNumber = true;
            foreach (char ca in prix)
            {
                if (ca <= '0' && ca >= '9')
                    isNumber = false;
            }

            if (isNumber == true)
                return isNumber;
            else
            {
                LabelInfo.Content = "Entrez un prix valide";
                return isNumber;
            }
        }

        public Joueur GetVendeur()
        {
            return vendeur;
        }
    }
}
