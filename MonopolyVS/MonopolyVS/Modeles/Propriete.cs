#region NAMESPACE
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Shapes;
#endregion

namespace MonopolyVS.Modeles
{
    public class Propriete : Case
    {
        #region Propriétés et variables

        /// <summary>
        /// Numero de la Propriete
        /// </summary>
        public int Numero { get; set; }

        /// <summary>
        /// Nom de la Propriete
        /// </summary>
        public string Nom { get; set; }

        /// <summary>
        /// Couleur de la Propriete (ou "Type")
        /// </summary>
        public string Couleur { get; }

        /// <summary>
        /// Joueur Propriétaire de la propriété
        /// </summary>
        public Joueur Proprietaire { get; set; } = null;

        /// <summary>
        /// Indique si la propriété est hypothèquée
        /// </summary>
        public bool EstHypotheque { get; set; } = false;

        /// <summary>
        /// Loyer du terrain [0], des maisons [1-2-3-4], de l'hôtel [5]
        /// </summary>
        public double[] Loyer { get; } = new double[6];

        /// <summary>
        /// Prix du Terrain
        /// </summary>
        public int PrixTerrain { get; } = 0;

        /// <summary>
        /// Prix de chaque maison et d'un hotel
        /// </summary>
        public int PrixMaison { get; } = 0;

        /// <summary>
        /// Nombre de maisons sur la case
        /// </summary>
        public int NbrMaison { get; set; } = 0;

        /// <summary>
        /// 0 pas d'hôtel sur la propriété -- 1 hôtel sur la propriété
        /// </summary>
        public bool Hotel { get; set; } = false;

        //TODOCORENTIN LOYER + HYPOTHEQUE A AJOUTER

        #endregion

        #region Constructeurs

        public Propriete()
        {

        }

        public Propriete(int numero, string nom, string couleur, int prixTerrain, int prixMaison, double[] loyer)
        {
            Numero = numero;
            Nom = nom;
            Couleur = couleur;
            PrixTerrain = prixTerrain;
            PrixMaison = prixMaison;
            Loyer = loyer;
        }

        #endregion

        #region Méthodes

        /// <summary>
        /// Configuration d'un donjon
        /// </summary>
        public void configDonjon(Joueur j, System.Windows.Controls.TextBox txtboxConsole)
        {
            if (this.Proprietaire == null)
            {
                DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("Voulez-vous acheter le donjon : " + this.Nom + " ?", "Achat de Donjon", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    txtboxConsole.AppendText(j.Nom + " a acheté le donjon : " + this.Nom + ". \n");
                    j.nbrDonjons++;
                    j.Argent -= this.PrixTerrain;
                    this.Proprietaire = j;
                    j.Patrimoine.Add(this);
                }
                else if (dialogResult == DialogResult.No)
                {
                    txtboxConsole.AppendText(j.Nom + " a choisi de ne pas acheter le donjon : " + this.Nom + ". \n");
                }
            }
            else
            {
                j.Argent -= this.Loyer[this.Proprietaire.nbrDonjons];
                txtboxConsole.AppendText(j.Nom + " paie " + this.Loyer[this.Proprietaire.nbrDonjons] + "€ de loyer à " + this.Proprietaire.Nom + ". \n");
            }
        }

        /// <summary>
        /// Configuration d'une Propriété
        /// </summary>
        /// <param name="j"></param>
        /// <param name="listePropriete"></param>
        /// <param name="txtboxConsole"></param>
        /// <param name="couleurTotal"></param>
        /// <param name="couleur"></param>
        /// <param name="maison"></param>
        /// <param name="hotel"></param>
        public void configPropriete(Joueur j, List<Propriete> listePropriete, System.Windows.Controls.TextBox txtboxConsole, 
            int couleurTotal, int couleur, bool maison, bool hotel)
        {
            foreach (Propriete prop in listePropriete)
            {
                //Vérifie si tout les terrain sont possédé (si couleur == couleurTotal)
                if (prop.Couleur == this.Couleur)
                    couleurTotal++;
                if (prop.Couleur == this.Couleur && prop.Proprietaire == j)
                    couleur++;

                if (prop.Couleur == this.Couleur && this.NbrMaison != 4 && (prop.NbrMaison != 4 || !prop.Hotel))
                    hotel = false;
                if (prop.Couleur == this.Couleur && this.NbrMaison > prop.NbrMaison)
                    maison = false;
            }

            if (this.Proprietaire == null)
            {
                DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("Voulez-vous acheter " + this.Nom + " ?", "Achat de Propriété", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    txtboxConsole.AppendText(j.Nom + " a acheté " + this.Nom + ". \n");
                    this.Proprietaire = j;
                    j.Patrimoine.Add(this);
                    j.Argent -= this.PrixTerrain;
                }
                else if (dialogResult == DialogResult.No)
                {
                    txtboxConsole.AppendText(j.Nom + " a choisi de ne pas acheter " + this.Nom + ". \n");
                    //TODOCORENTIN Vente aux enchères à créer
                }
            }
            else if (this.Proprietaire == j && couleur == couleurTotal && maison == true)
            {
                if(this.NbrMaison == 4 && !this.Hotel)
                {
                    DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("Voulez-vous acheter un hotel pour " + this.Nom + " ?", "Achat d'Hotel", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        txtboxConsole.AppendText(j.Nom + " a acheté un hotel pour " + this.Nom + ". \n");
                        this.Hotel = true;
                        j.Argent -= this.PrixMaison;
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        txtboxConsole.AppendText(j.Nom + " a choisi de ne pas acheter d'hotel pour " + this.Nom + ". \n");
                    }
                }
                else if(this.NbrMaison == 4 && this.Hotel)
                {
                    txtboxConsole.AppendText(j.Nom + " ne peut plus rien placer sur " + this.Nom + ". \n");
                }
                else
                {
                    DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("Voulez-vous acheter une maison pour " + this.Nom + " ?", "Achat de Maison", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        txtboxConsole.AppendText(j.Nom + " a acheté une maison pour " + this.Nom + ". \n");
                        this.NbrMaison++;
                        j.Argent -= this.PrixMaison;
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        txtboxConsole.AppendText(j.Nom + " a choisi de ne pas acheter de maison pour " + this.Nom + ". \n");
                    }
                }
            }
            else if(this.Proprietaire != j)
            {
                j.Argent -= this.Loyer[this.NbrMaison];
                this.Proprietaire.Argent += this.Loyer[this.NbrMaison];
                txtboxConsole.AppendText(j.Nom + " paie " + this.Loyer[this.NbrMaison] + "€ de loyer à " + this.Proprietaire.Nom + ". \n");
            }
            else
            {
                txtboxConsole.AppendText(this.Nom + " vous appartient déjà " + j.Nom + " ! \n");
            }
        }

        /// <summary>
        /// Affiche les Maisons ou Hotels
        /// </summary>
        /// <param name="listeCases"></param>
        public void configMaison(List<Case> listeCases)
        {
            Case c = new Case();

            foreach(Case ca in listeCases)
            {
                if (this.Numero == ca.Num)
                    c = ca;
            }

            if (this.Hotel)
            {
                c.NomHotel.Visibility = Visibility.Visible;
                c.Maison1.Visibility = Visibility.Visible;
                c.Maison2.Visibility = Visibility.Visible;
                c.Maison3.Visibility = Visibility.Visible;
                c.Maison4.Visibility = Visibility.Visible;
            }
            else
            {
                c.NomHotel.Visibility = Visibility.Hidden;
                switch (this.NbrMaison)
                {
                    case (0):
                        c.Maison1.Visibility = Visibility.Hidden;
                        c.Maison2.Visibility = Visibility.Hidden;
                        c.Maison3.Visibility = Visibility.Hidden;
                        c.Maison4.Visibility = Visibility.Hidden;
                        break;
                    case (1):
                        c.Maison1.Visibility = Visibility.Visible;
                        c.Maison2.Visibility = Visibility.Hidden;
                        c.Maison3.Visibility = Visibility.Hidden;
                        c.Maison4.Visibility = Visibility.Hidden;
                        break;
                    case (2):
                        c.Maison1.Visibility = Visibility.Visible;
                        c.Maison2.Visibility = Visibility.Visible;
                        c.Maison3.Visibility = Visibility.Hidden;
                        c.Maison4.Visibility = Visibility.Hidden;
                        break;
                    case (3):
                        c.Maison1.Visibility = Visibility.Visible;
                        c.Maison2.Visibility = Visibility.Visible;
                        c.Maison3.Visibility = Visibility.Visible;
                        c.Maison4.Visibility = Visibility.Hidden;
                        break;
                    case (4):
                        c.Maison1.Visibility = Visibility.Visible;
                        c.Maison2.Visibility = Visibility.Visible;
                        c.Maison3.Visibility = Visibility.Visible;
                        c.Maison4.Visibility = Visibility.Visible;
                        break;
                }
            }
        }

        #endregion
    }
}