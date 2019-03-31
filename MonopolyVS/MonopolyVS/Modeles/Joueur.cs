#region NAMESPACE
using MonopolyVS.Controleurs;
using MonopolyVS.Modeles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
#endregion

namespace MonopolyVS
{
    public class Joueur
    {
        #region MEMBRES
        #region Objets
        Banque Banque = new Banque();
        Des Des = new Des();
        /// <summary>
        /// Pion du Joueur
        /// </summary>
        public Rectangle Pion;
        /// <summary>
        /// Listes des propriétés du joueur
        /// </summary>
        public List<Propriete> Patrimoine { get; set; } = new List<Propriete>();
        #endregion

        #region Propriétés et variables
        /// <summary>
        /// Nom du joueur
        /// </summary>
        public string Nom { get; set; }

        /// <summary>
        /// Solde du joueur
        /// </summary>
        public double Argent { get; set; }

        /// <summary>
        /// Position du joueur
        /// </summary>
        public int Position { get; set; } = 0;

        /// <summary>
        /// Numéro du joueur
        /// </summary>
        public int Numero { get; set; }

        /// <summary>
        /// Nombre de tour passé en prison
        /// </summary>
        public int nbrTourPrison { get; set; } = 0;

        /// <summary>
        /// Indique si le joueur est en prison
        /// </summary>
        public bool EstEnPrison { get; set; } = false;

        /// <summary>
        /// Nombre de doubles effectués à l'affilé
        /// </summary>
        public int nbrDouble { get; set; } = 0;

        /// <summary>
        /// Indique si le joueur vient de faire un doublé
        /// </summary>
        public bool estDouble { get; set; } = false;

        /// <summary>
        /// Indique le tour du joueur
        /// </summary>
        public bool sonTour { get; set; } = false;

        /// <summary>
        /// Indique le nbr de donjons en possession du joueur
        /// </summary>
        public int nbrDonjons { get; set; } = 0;

        /// <summary>
        /// Indique le nombre de carte de sortie possédé par le joueur 
        /// (il y en a 2 dans le jeu, une dans les cartes chance et une dans les cartes caisse de communautée)
        /// </summary>
        public int Sortie { get; set; } = 0;

        /// <summary>
        /// Le joueur est en banqueroute, il a perdu
        /// </summary>
        public bool isBanqueroute { get; set; } = false;
        
        /// <summary>
        /// Voir dans la méthode "affichePion()", chaque classe possède un numéro
        /// </summary>
        public int NumClasse;

        bool donjon = false;

        bool prop = false;
        #endregion
        #endregion

        #region Constructeurs

        /// <summary>
        /// Constructeur du Joueur Vide
        /// </summary>
        public Joueur()
        {

        }

        /// <summary>
        /// Constructeur du Joueur
        /// </summary>
        /// <param name="numero">Numero du joueur</param>
        /// <param name="nom">Nom du joueur</param>
        /// <param name="position">Position du joueur sur le plateau</param>
        /// <param name="argent">Argent de base sur le compte du joueur</param>
        /// <param name="pion">Pion du plateau avec lequel le joueur est lié</param>
        /// <param name="ComboIcones">Selection du type de jeton</param>
        public Joueur(int numero, string nom, int position, int argent, Rectangle pion, System.Windows.Controls.ComboBox ComboIcones)
        {
            Numero = numero;
            Nom = nom;
            Position = position;
            Argent = argent;
            Pion = pion;
            NumClasse = ComboIcones.SelectedIndex;
            affichePion(NumClasse);
        }

        #endregion

        #region Méthodes

        /// <summary>
        /// Affiche l'image de la classe sur le piondu Joueur
        /// </summary>
        public void affichePion(int NumClasse)
        {
            switch (NumClasse)
            {
                //CASE DeathKnight
                case 0:
                    this.Pion.Fill = new ImageBrush(new BitmapImage(new Uri(@"../../Images/39px-ClassIcon_deathknightFOND.png", UriKind.Relative)));
                    break;
                //CASE DemonHunter
                case 1:
                    this.Pion.Fill = new ImageBrush(new BitmapImage(new Uri(@"../../Images/39px-ClassIcon_demon_hunterFOND.png", UriKind.Relative)));
                    break;
                //CASE Druid
                case 2:
                    this.Pion.Fill = new ImageBrush(new BitmapImage(new Uri(@"../../Images/39px-ClassIcon_druidFOND.png", UriKind.Relative)));
                    break;
                //CASE Hunter
                case 3:
                    this.Pion.Fill = new ImageBrush(new BitmapImage(new Uri(@"../../Images/39px-ClassIcon_hunterFOND.png", UriKind.Relative)));
                    break;
                //CASE Mage
                case 4:
                    this.Pion.Fill = new ImageBrush(new BitmapImage(new Uri(@"../../Images/39px-ClassIcon_mageFOND.png", UriKind.Relative)));
                    break;
                //CASE Monk
                case 5:
                    this.Pion.Fill = new ImageBrush(new BitmapImage(new Uri(@"../../Images/39px-ClassIcon_monkFOND.png", UriKind.Relative)));
                    break;
                //CASE Paladin
                case 6:
                    this.Pion.Fill = new ImageBrush(new BitmapImage(new Uri(@"../../Images/39px-ClassIcon_paladinFOND.png", UriKind.Relative)));
                    break;
                //CASE Priest
                case 7:
                    this.Pion.Fill = new ImageBrush(new BitmapImage(new Uri(@"../../Images/39px-ClassIcon_priestFOND.png", UriKind.Relative)));
                    break;
                //CASE Rogue
                case 8:
                    this.Pion.Fill = new ImageBrush(new BitmapImage(new Uri(@"../../Images/39px-ClassIcon_rogueFOND.png", UriKind.Relative)));
                    break;
                //CASE Shaman
                case 9:
                    this.Pion.Fill = new ImageBrush(new BitmapImage(new Uri(@"../../Images/39px-ClassIcon_shamanFOND.png", UriKind.Relative)));
                    break;
                //CASE Warlock
                case 10:
                    this.Pion.Fill = new ImageBrush(new BitmapImage(new Uri(@"../../Images/39px-ClassIcon_warlockFOND.png", UriKind.Relative)));
                    break;
                //CASE Warrior
                case 11:
                    this.Pion.Fill = new ImageBrush(new BitmapImage(new Uri(@"../../Images/39px-ClassIcon_warriorFOND.png", UriKind.Relative)));
                    break;
            }
        }

        /// <summary>
        /// Termine le tour du joueur puis le change
        /// </summary>
        /// <param name="listeJoueurs"></param>
        /// <param name="nbrMax"></param>
        /// <param name="lblNomJoueur"></param>
        /// <param name="lblArgentJoueur"></param>
        /// <param name="imgSortie"></param>
        /// <param name="txtboxConsole"></param>
        /// <param name="c"></param>
        /// <param name="btnLanceDes"></param>
        /// <param name="btnFinPartie"></param>
        /// <param name="pionWin"></param>
        /// <param name="lblWin"></param>
        public void finTour(List<Joueur> listeJoueurs, int nbrMax, System.Windows.Controls.Label lblNomJoueur,
            System.Windows.Controls.Label lblArgentJoueur, Image imgSortie, System.Windows.Controls.TextBox txtboxConsole, Controleur c,
            System.Windows.Controls.Button btnLanceDes, System.Windows.Controls.Button btnFinPartie, Rectangle pionWin, System.Windows.Controls.Label lblWin)
        {
            foreach(Joueur j in listeJoueurs)
            {
                if (j.sonTour == true)
                {
                    if(j.Numero == nbrMax)
                        changeTour(listeJoueurs, 0, lblNomJoueur, lblArgentJoueur, imgSortie, txtboxConsole, c, btnLanceDes, btnFinPartie, pionWin, lblWin);
                    else
                        changeTour(listeJoueurs, j.Numero, lblNomJoueur, lblArgentJoueur, imgSortie, txtboxConsole, c, btnLanceDes, btnFinPartie, pionWin, lblWin);
                    break;
                }
            }
        }

        /// <summary>
        /// Change le tour des joueurs
        /// </summary>
        /// <param name="nbr">Numero du Joueur</param>
        public void changeTour(List<Joueur> listeJoueurs, int nbr, System.Windows.Controls.Label lblNomJoueur,
            System.Windows.Controls.Label lblArgentJoueur, Image imgSortie, System.Windows.Controls.TextBox txtboxConsole, Controleur c,
            System.Windows.Controls.Button btnLanceDes, System.Windows.Controls.Button btnFinPartie, Rectangle pionWin, System.Windows.Controls.Label lblWin)
        {
            nbr++;
            foreach(Joueur j in listeJoueurs)
            {
                if (j.Numero == nbr)
                {
                    j.sonTour = true;
                    lblNomJoueur.Content = j.Nom;
                    lblArgentJoueur.Content = j.Argent;
                    if (j.Sortie > 0)
                        imgSortie.Visibility = Visibility.Visible;
                    else
                        imgSortie.Visibility = Visibility.Hidden;

                    if (j.Argent <= 0)
                        banqueroute(j, txtboxConsole, listeJoueurs, c, lblNomJoueur, lblArgentJoueur, imgSortie, btnLanceDes, btnFinPartie, pionWin, lblWin);
                    break;
                }
                else
                    j.sonTour = false;
            }
        }

        /// <summary>
        /// Perte de la partie pour le joueur si il n'arrive pas à payer ses dettes
        /// </summary>
        /// <param name="j"></param>
        public void banqueroute(Joueur j, System.Windows.Controls.TextBox txtboxConsole, List<Joueur> listeJoueurs, Controleur c,
            System.Windows.Controls.Label lblNomJoueur, System.Windows.Controls.Label lblArgentJoueur, Image imgSortie, System.Windows.Controls.Button btnLanceDes,
            System.Windows.Controls.Button btnFinPartie, Rectangle pionWin, System.Windows.Controls.Label lblWin)
        {
            txtboxConsole.AppendText(j.Nom + " n'as plus d'argent. Il faudra vendre un terrain, un bâtiment, ou perdre la partie. \n"); //à implémenter
            //Faire ici la banqueroute, il faudra utiliser le système de vente de bâtiment et de terrain pour rembourser les dettes
            //Sinon le joueur perd et il faudra le sortir de la partie
            foreach (Propriete p in j.Patrimoine)
            {
                p.Proprietaire = null;
                p.NbrMaison = 0;
                p.Hotel = false;
            }

            j.isBanqueroute = true;
            j.Position = 0;
            j.Pion.Fill = null;
            c.nbrJoueurs--;

            listeJoueurs.Remove(j);
            foreach(Joueur jo in listeJoueurs)
            {
                if (jo.Numero > j.Numero)
                    jo.Numero--;
            }
            foreach(Joueur jo in listeJoueurs)
            {
                if (jo.Numero == j.Numero)
                    jo.sonTour = true;
            }
            finTour(listeJoueurs, c.nbrJoueurs, lblNomJoueur, lblArgentJoueur, imgSortie, txtboxConsole, c, btnLanceDes, btnFinPartie, pionWin, lblWin);

            if (c.nbrJoueurs < 2)
            {
                listeJoueurs[0].gagnePartie(txtboxConsole, btnLanceDes, btnFinPartie, pionWin, lblWin);
            }
        }

        /// <summary>
        /// Le joueur en question gagne la partie
        /// </summary>
        public void gagnePartie(System.Windows.Controls.TextBox txtboxConsole, System.Windows.Controls.Button btnLanceDes, System.Windows.Controls.Button btnFinPartie,
            Rectangle pionWin, System.Windows.Controls.Label lblWin)
        {
            txtboxConsole.AppendText(this.Nom + " gagne la partie. \n");    //à implémenter
            btnLanceDes.Visibility = Visibility.Hidden;
            btnFinPartie.Visibility = Visibility.Visible;
            pionWin.Visibility = Visibility.Visible;
            lblWin.Visibility = Visibility.Visible;

            //this.NumClasse
        }

        /// <summary>
        /// Affiche les propriétés dans la liste du plateau
        /// </summary>
        public void afficheProp(System.Windows.Controls.ListBox listboxBien)
        {
            listboxBien.Items.Clear();
            listboxBien.Items.Add("Patrimoine de " + this.Nom + " : \n");

            //Donjons
            foreach (Propriete p in this.Patrimoine)
            {
                if (p.Couleur == "Donjon")
                    donjon = true;
            }
            if (donjon)
            {
                listboxBien.Items.Add("Donjons : \n");
            }
            foreach (Propriete p in this.Patrimoine)
            {
                if (p.Couleur == "Donjon")
                {
                    listboxBien.Items.Add(p.Nom);
                }
            }

            //Propriétés
            foreach (Propriete p in this.Patrimoine)
            {
                if (p.Couleur != "Donjon")
                    prop = true;
            }
            if (prop)
            {
                listboxBien.Items.Add("Propriétés : \n");
            }
            foreach (Propriete p in this.Patrimoine)
            {
                if (p.Couleur != "Donjon")
                {
                    listboxBien.Items.Add(p.Nom);
                }
            }

            if (!donjon && !prop)
                listboxBien.Items.Add("Pas de Propriétés ! \n");

            donjon = false;
            prop = false;
        }

        /// <summary>
        /// Affecte des coordonnées aux pions
        /// </summary>
        public void setValueCanvas(double left, double top, Joueur j)
        {
            j.Pion.SetValue(Canvas.LeftProperty, left);
            j.Pion.SetValue(Canvas.TopProperty, top);
        }

        /// <summary>
        /// Place le pion sur la bonne case, grâce au positionnement du canvas
        /// </summary>
        /// <param name="position">Case où ce trouve le pion à la fin du tour</param>
        public void Placement(int position, Joueur j, Rectangle pion1, Rectangle pion2, List<Propriete> listePropriete,
            System.Windows.Controls.TextBox txtboxConsole, List<Case> listeCases, List<Carte> listeChance, Image imgSortie, List<Carte> listeCaisse)
        {
            int couleur = 0;
            int couleurTotal = 0;
            bool maison = true;
            bool hotel = true;
            Propriete p = listePropriete[position];
            Carte c = new Carte();

            double[] tab = listePropriete[position].getPositions(j);

            double posX = tab[0];
            double posY = tab[1];

            setValueCanvas(posX, posY, j);

            switch (position)
            {
                case (0):
                    //Case départ -- +200€ ; l'ajout des 200€ est géré au moment du passage sur la case dans Controleur.Move()
                    break;
                case (1):
                    //Cross Roads
                    p.configPropriete(j, listePropriete, txtboxConsole, couleurTotal, couleur, maison, hotel);
                    p.configMaison(listeCases);
                    break;
                case (2):
                    //Coffre
                    c.piocheCaisse(imgSortie, j, listeChance, txtboxConsole, pion1, pion2, listePropriete, listeCases, listeCaisse);
                    break;
                case (3):
                    //Goldshire
                    p.configPropriete(j, listePropriete, txtboxConsole, couleurTotal, couleur, maison, hotel);
                    p.configMaison(listeCases);
                    break;
                case (4):
                    //Impot -- -200€
                    j.Argent -= 200;
                    txtboxConsole.AppendText(j.Nom + " paie 200€ à l'entraîneur. \n");   //à implémenter
                    break;
                case (5):
                    //Donjon -- -200€
                    p.configDonjon(j, txtboxConsole);
                    break;
                case (6):
                    //Auberdine
                    p.configPropriete(j, listePropriete, txtboxConsole, couleurTotal, couleur, maison, hotel);
                    p.configMaison(listeCases);
                    break;
                case (7):
                    //Chance
                    c.piocheChance(imgSortie, j, listeChance, txtboxConsole, pion1, pion2, listePropriete, listeCases, listeCaisse);
                    break;
                case (8):
                    //Senuin
                    p.configPropriete(j, listePropriete, txtboxConsole, couleurTotal, couleur, maison, hotel);
                    p.configMaison(listeCases);
                    break;
                case (9):
                    //Ambermill
                    p.configPropriete(j, listePropriete, txtboxConsole, couleurTotal, couleur, maison, hotel);
                    p.configMaison(listeCases);
                    break;
                case (10):
                    //Visite Prison -- ne ce passe rien
                    break;
                case (11):
                    //Nighthaven
                    p.configPropriete(j, listePropriete, txtboxConsole, couleurTotal, couleur, maison, hotel);
                    p.configMaison(listeCases);
                    break;
                case (12):
                    //Impot -- -150€
                    j.Argent -= 150;
                    txtboxConsole.AppendText(j.Nom + " doit 150€ au service postal. \n");   //à implémenter
                    break;
                case (13):
                    //Freewind Post
                    p.configPropriete(j, listePropriete, txtboxConsole, couleurTotal, couleur, maison, hotel);
                    p.configMaison(listeCases);
                    break;
                case (14):
                    //Astranaar
                    p.configPropriete(j, listePropriete, txtboxConsole, couleurTotal, couleur, maison, hotel);
                    p.configMaison(listeCases);
                    break;
                case (15):
                    //Donjon -- 200€
                    p.configDonjon(j, txtboxConsole);
                    break;
                case (16):
                    //Booty Bay
                    p.configPropriete(j, listePropriete, txtboxConsole, couleurTotal, couleur, maison, hotel);
                    p.configMaison(listeCases);
                    break;
                case (17):
                    //Coffre
                    c.piocheCaisse(imgSortie, j, listeChance, txtboxConsole, pion1, pion2, listePropriete, listeCases, listeCaisse);
                    break;
                case (18):
                    //Tarren Mill
                    p.configPropriete(j, listePropriete, txtboxConsole, couleurTotal, couleur, maison, hotel);
                    p.configMaison(listeCases);
                    break;
                case (19):
                    //Southshore
                    p.configPropriete(j, listePropriete, txtboxConsole, couleurTotal, couleur, maison, hotel);
                    p.configMaison(listeCases);
                    break;
                case (20):
                    //Gardien des Esprits -- ne ce passe rien
                    break;
                case (21):
                    //Gadgetzan
                    p.configPropriete(j, listePropriete, txtboxConsole, couleurTotal, couleur, maison, hotel);
                    p.configMaison(listeCases);
                    break;
                case (22):
                    //Chance
                    c.piocheChance(imgSortie, j, listeChance, txtboxConsole, pion1, pion2, listePropriete, listeCases, listeCaisse);
                    break;
                case (23):
                    //Camp Mojache
                    p.configPropriete(j, listePropriete, txtboxConsole, couleurTotal, couleur, maison, hotel);
                    p.configMaison(listeCases);
                    break;
                case (24):
                    //Aerie Peak
                    p.configPropriete(j, listePropriete, txtboxConsole, couleurTotal, couleur, maison, hotel);
                    p.configMaison(listeCases);
                    break;
                case (25):
                    //Donjon -- 200€
                    p.configDonjon(j, txtboxConsole);
                    break;
                case (26):
                    //Everlook
                    p.configPropriete(j, listePropriete, txtboxConsole, couleurTotal, couleur, maison, hotel);
                    p.configMaison(listeCases);
                    break;
                case (27):
                    //Lights Hope Chapel
                    p.configPropriete(j, listePropriete, txtboxConsole, couleurTotal, couleur, maison, hotel);
                    p.configMaison(listeCases);
                    break;
                case (28):
                    //Impot -- 150€
                    j.Argent -= 150;
                    txtboxConsole.AppendText(j.Nom + " paie 150€ de barbier. Superbe barbe ! \n");   //à implémenter
                    break;
                case (29):
                    //Stormwind City
                    p.configPropriete(j, listePropriete, txtboxConsole, couleurTotal, couleur, maison, hotel);
                    p.configMaison(listeCases);
                    break;
                case (30):
                    //Vers la Prison
                    this.Position = 40;
                    this.Placement(40, j, pion1, pion2, listePropriete, txtboxConsole, listeCases, listeChance, imgSortie, listeCaisse);
                    j.EstEnPrison = true;
                    txtboxConsole.AppendText(j.Nom + " rentre sur le champ de bataille ! \n");   //à implémenter
                    break;
                case (31):
                    //Thunderbluff
                    p.configPropriete(j, listePropriete, txtboxConsole, couleurTotal, couleur, maison, hotel);
                    p.configMaison(listeCases);
                    break;
                case (32):
                    //Ironforge
                    p.configPropriete(j, listePropriete, txtboxConsole, couleurTotal, couleur, maison, hotel);
                    p.configMaison(listeCases);
                    break;
                case (33):
                    //Coffre
                    c.piocheCaisse(imgSortie, j, listeChance, txtboxConsole, pion1, pion2, listePropriete, listeCases, listeCaisse);
                    break;
                case (34):
                    //Dalaran
                    p.configPropriete(j, listePropriete, txtboxConsole, couleurTotal, couleur, maison, hotel);
                    p.configMaison(listeCases);
                    break;
                case (35):
                    //Donjon -- 200€
                    p.configDonjon(j, txtboxConsole);
                    break;
                case (36):
                    //Chance
                    c.piocheChance(imgSortie, j, listeChance, txtboxConsole, pion1, pion2, listePropriete, listeCases, listeCaisse);
                    break;
                case (37):
                    //Orgrimmar
                    p.configPropriete(j, listePropriete, txtboxConsole, couleurTotal, couleur, maison, hotel);
                    p.configMaison(listeCases);
                    break;
                case (38):
                    //Impot -- 200€
                    j.Argent -= 200;
                    txtboxConsole.AppendText(j.Nom + " répare son équipement pour 200€. \n");   //à implémenter
                    break;
                case (39):
                    //Darnassus
                    p.configPropriete(j, listePropriete, txtboxConsole, couleurTotal, couleur, maison, hotel);
                    p.configMaison(listeCases);
                    break;
                case (40):
                    //Prison -- 50€ pour sortir de la prison
                    //Cela est géré dans le Controleur clicbtnlancedes
                    break;
            }
        }
        #endregion
    }
}
