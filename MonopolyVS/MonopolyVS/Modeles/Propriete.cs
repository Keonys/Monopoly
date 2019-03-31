#region NAMESPACE
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MonopolyVS.Controleurs;
#endregion

namespace MonopolyVS.Modeles
{
    public class Propriete : Case
    {
        #region Propriétés et variables

        /// <summary>
        /// Position sur plateau
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

        Controleur controleur;

        //Toutes les coordonnées du joueur sur la case
        public double XJ1 { get; set; } = 0.0;
        public double YJ1 { get; set; } = 0.0;
        public double XJ2 { get; set; } = 0.0;
        public double YJ2 { get; set; } = 0.0;
        public double XJ3 { get; set; } = 0.0;
        public double YJ3 { get; set; } = 0.0;
        public double XJ4 { get; set; } = 0.0;
        public double YJ4 { get; set; } = 0.0;
        public Controleur Controleur { get => controleur; set => controleur = value; }

        /// <summary>
        /// Prix d'hypothèque (vente), pour obtenir le prix de rachat, il faut multiplier ce prix par 1.1
        /// </summary>
        public int PrixHypotheque { get; set; } = 0;

        /// <summary>
        /// Indique si la propriété est hypothequee
        /// </summary>
        public bool isHypotheque { get; set; } = false;

        #endregion

        #region Constructeurs

        public Propriete()
        {

        }

        public Propriete(int numero, string nom, string couleur, int prixTerrain, int prixMaison, double[] loyer, double xJ1, double yJ1, double xJ2, double yJ2, double xJ3,
            double yJ3, double xJ4, double yJ4, Controleurs.Controleur c, int prixHypotheque)
        {
            Numero = numero;
            Nom = nom;
            Couleur = couleur;
            PrixTerrain = prixTerrain;
            PrixMaison = prixMaison;
            Loyer = loyer;
            controleur = c;
            XJ1 = xJ1;
            YJ1 = yJ1;
            XJ2 = xJ2;
            YJ2 = yJ2;
            XJ3 = xJ3;
            YJ3 = yJ3;
            XJ4 = xJ4;
            YJ4 = yJ4;
            controleur = c;
            PrixHypotheque = prixHypotheque;
        }

        #endregion

        #region Méthodes

        /// <summary>
        /// Récupère la position du joueur sur la case
        /// </summary>
        /// <param name="j"></param>
        /// <returns></returns>
        public double[] getPositions(Joueur j)
        {
            double[] tab = new double[2];
            double x = 0.0;
            double y = 0.0;

            if (j.Numero == 1)
            {
                x = XJ1;
                y = YJ1;
            }
            else if (j.Numero == 2)
            {
                x = XJ2;
                y = YJ2;
            }
            else if (j.Numero == 3)
            {
                x = XJ3;
                y = YJ3;
            }
            else
            {
                x = XJ4;
                y = YJ4;
            }

            tab[0] = x;
            tab[1] = y;

            return tab;
        }

        /// <summary>
        /// Permet a un joueur d'acheter (ou pas) un Donjon
        /// </summary>
        public void configDonjon(Joueur j, System.Windows.Controls.TextBox txtboxConsole)
        {
            if (this.Proprietaire == null)
            {
                //Affiche boite de dialogue demande si le joueur souhaite achetert le donjon
                DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("Voulez-vous acheter le donjon : " + this.Nom + " ?", "Achat de Donjon", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    //CAS ACCEPTE ACHAT
                    //txtboxConsole.AppendText(j.Nom + " a acheté le donjon : " + this.Nom + ". \n"); //à implémenter
                    controleur.C.AchatVentePropriete(true, true, j.Nom, this.Nom, false);
                    j.nbrDonjons++;
                    j.Argent -= this.PrixTerrain;
                    this.Proprietaire = j;
                    j.Patrimoine.Add(this);
                    
                    foreach (Case ca in Controleur.listeCases)
                    {
                        if (ca.Num == Numero)
                        {
                            afficheAppartenanceCase(j, ca);
                        }
                    }
                }
                else if (dialogResult == DialogResult.No)
                {
                    //CAS REFUS ACHAT
                    //txtboxConsole.AppendText(j.Nom + " a choisi de ne pas acheter le donjon : " + this.Nom + ". \n"); //à implémenter
                    controleur.C.AchatVentePropriete(true, false, j.Nom, this.Nom, false);
                }
            }
            else
            {
                j.Argent -= this.Loyer[this.Proprietaire.nbrDonjons];
                //txtboxConsole.AppendText(j.Nom + " paie " + this.Loyer[this.Proprietaire.nbrDonjons] + "€ de loyer à " + this.Proprietaire.Nom + ". \n"); //à implémenter
                controleur.C.Paie(j.Nom, this.Proprietaire.Nom, true, this.Loyer[this.Proprietaire.nbrDonjons]);
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
            //ACHAT DE PROPRIETE
            if (this.Proprietaire == null)
            {
                DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("Voulez-vous acheter " + this.Nom + " ?", "Achat de Propriété", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    //CAS ACCEPTE ACHAT
                    //txtboxConsole.AppendText(j.Nom + " a acheté " + this.Nom + ". \n"); //à implémenter
                    controleur.C.AchatVentePropriete(false, true, j.Nom, this.Nom, false);
                    this.Proprietaire = j;
                    j.Patrimoine.Add(this);
                    j.Argent -= this.PrixTerrain;

                    foreach (Case ca in Controleur.listeCases)
                    {
                        if (ca.Num == Numero)
                        {
                            afficheAppartenanceCase(j, ca);
                        }
                    }
                }
                else if (dialogResult == DialogResult.No)
                {
                    //CAS REFUS ACHAT
                    //txtboxConsole.AppendText(j.Nom + " a choisi de ne pas acheter " + this.Nom + ". \n"); //à implémenter
                    controleur.C.AchatVentePropriete(false, false, j.Nom, this.Nom, false);
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
                        //txtboxConsole.AppendText(j.Nom + " a acheté un hotel pour " + this.Nom + ". \n"); //à implémenter
                        controleur.C.AchatVenteMaison(true, true, j.Nom, this.Nom);
                        this.Hotel = true;
                        j.Argent -= this.PrixMaison;
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        //txtboxConsole.AppendText(j.Nom + " a choisi de ne pas acheter d'hotel pour " + this.Nom + ". \n"); //à implémenter
                        controleur.C.AchatVenteMaison(true, false, j.Nom, this.Nom);
                    }
                }
                else if (this.NbrMaison == 4 && this.Hotel) //PEUT ETRE INUTILE A L'AVENIR
                {
                    //txtboxConsole.AppendText(j.Nom + " ne peut plus rien placer sur " + this.Nom + ". \n"); //à implémenter
                    controleur.C.ImpossibleConstruire(j.Nom, this.Nom);
                }
                else
                {
                    DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("Voulez-vous acheter une maison pour " + this.Nom + " ?", "Achat de Maison", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        //txtboxConsole.AppendText(j.Nom + " a acheté une maison pour " + this.Nom + ". \n"); //à implémenter
                        controleur.C.AchatVenteMaison(false, true, j.Nom, this.Nom);
                        this.NbrMaison++;
                        j.Argent -= this.PrixMaison;
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        //txtboxConsole.AppendText(j.Nom + " a choisi de ne pas acheter de maison pour " + this.Nom + ". \n"); //à implémenter
                        controleur.C.AchatVenteMaison(false, false, j.Nom, this.Nom);
                    }
                }
            }
            else if(this.Proprietaire != j)
            {
                j.Argent -= this.Loyer[this.NbrMaison];
                this.Proprietaire.Argent += this.Loyer[this.NbrMaison];
                //txtboxConsole.AppendText(j.Nom + " paie " + this.Loyer[this.NbrMaison] + "€ de loyer à " + this.Proprietaire.Nom + ". \n"); //à implémenter
                controleur.C.Paie(j.Nom, this.Proprietaire.Nom, true, this.Loyer[this.NbrMaison]);
            }
            else
            {
                //txtboxConsole.AppendText(this.Nom + " vous appartient déjà " + j.Nom + " ! \n"); //à implémenter
                controleur.C.AchatVentePropriete(false, false, j.Nom, this.Nom, true);
            }
        }

        /// <summary>
        /// Fill un rectangle avec le pion du joueur en question
        /// </summary>
        /// <param name="j"></param>
        /// <param name="ca"></param>
        public void afficheAppartenanceCase(Joueur j, Case ca)
        {
            switch (j.NumClasse)
            {
                //CASE DeathKnight
                case 0:
                    ca.RectAppart.Fill = new ImageBrush(new BitmapImage(new Uri(@"../../Images/39px-ClassIcon_deathknight.png", UriKind.Relative)));
                    break;
                //CASE DemonHunter
                case 1:
                    ca.RectAppart.Fill = new ImageBrush(new BitmapImage(new Uri(@"../../Images/39px-ClassIcon_demon_hunter.png", UriKind.Relative)));
                    break;
                //CASE Druid
                case 2:
                    ca.RectAppart.Fill = new ImageBrush(new BitmapImage(new Uri(@"../../Images/39px-ClassIcon_druid.png", UriKind.Relative)));
                    break;
                //CASE Hunter
                case 3:
                    ca.RectAppart.Fill = new ImageBrush(new BitmapImage(new Uri(@"../../Images/39px-ClassIcon_hunter.png", UriKind.Relative)));
                    break;
                //CASE Mage
                case 4:
                    ca.RectAppart.Fill = new ImageBrush(new BitmapImage(new Uri(@"../../Images/39px-ClassIcon_mage.png", UriKind.Relative)));
                    break;
                //CASE Monk
                case 5:
                    ca.RectAppart.Fill = new ImageBrush(new BitmapImage(new Uri(@"../../Images/39px-ClassIcon_monk.png", UriKind.Relative)));
                    break;
                //CASE Paladin
                case 6:
                    ca.RectAppart.Fill = new ImageBrush(new BitmapImage(new Uri(@"../../Images/39px-ClassIcon_paladin.png", UriKind.Relative)));
                    break;
                //CASE Priest
                case 7:
                    ca.RectAppart.Fill = new ImageBrush(new BitmapImage(new Uri(@"../../Images/39px-ClassIcon_priest.png", UriKind.Relative)));
                    break;
                //CASE Rogue
                case 8:
                    ca.RectAppart.Fill = new ImageBrush(new BitmapImage(new Uri(@"../../Images/39px-ClassIcon_rogue.png", UriKind.Relative)));
                    break;
                //CASE Shaman
                case 9:
                    ca.RectAppart.Fill = new ImageBrush(new BitmapImage(new Uri(@"../../Images/39px-ClassIcon_shaman.png", UriKind.Relative)));
                    break;
                //CASE Warlock
                case 10:
                    ca.RectAppart.Fill = new ImageBrush(new BitmapImage(new Uri(@"../../Images/39px-ClassIcon_warlock.png", UriKind.Relative)));
                    break;
                //CASE Warrior
                case 11:
                    ca.RectAppart.Fill = new ImageBrush(new BitmapImage(new Uri(@"../../Images/39px-ClassIcon_warrior.png", UriKind.Relative)));
                    break;
                default:
                    ca.RectAppart.Fill = new ImageBrush(new BitmapImage(new Uri(@"../../Images/vide.png", UriKind.Relative)));
                    break;
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