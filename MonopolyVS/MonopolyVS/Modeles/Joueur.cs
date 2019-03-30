#region NAMESPACE
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
        #region Objets

        Banque Banque = new Banque();
        Des Des = new Des();
        bool donjon = false;
        bool prop = false;

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
        public int Position { get; set; }

        /// <summary>
        /// Nombre de tour à rester en prison
        /// </summary>
        public int Peine { get; set; }

        /// <summary>
        /// Listes des propriétés du joueur
        /// </summary>
        public List<Propriete> Patrimoine { get; set; } = new List<Propriete>();

        /// <summary>
        /// Numéro du joueur
        /// </summary>
        public int Numero { get; set; }

        /// <summary>
        /// Nombre de tour passé en prison
        /// </summary>
        public int nbrTourPrison = 0;

        /// <summary>
        /// Indique si le joueur est en prison
        /// </summary>
        public bool EstEnPrison = false;

        /// <summary>
        /// Nombre de doubles effectués à l'affilé
        /// </summary>
        public int nbrDouble = 0;

        /// <summary>
        /// Indique si le joueur vient de faire un doublé
        /// </summary>
        public bool estDouble = false;

        /// <summary>
        /// Indique le tour du joueur
        /// </summary>
        public bool sonTour = false;

        /// <summary>
        /// Indique le nbr de donjons en possession du joueur
        /// </summary>
        public int nbrDonjons = 0;

        /// <summary>
        /// Indique le nombre de carte de sortie possédé par le joueur 
        /// (il y en a 2 dans le jeu, une dans les cartes chance et une dans les cartes caisse de communautée)
        /// </summary>
        public int Sortie = 0;

        /// <summary>
        /// Pion du Joueur
        /// </summary>
        public Rectangle Pion;

        /// <summary>
        /// Voir dans la méthode "affichePion()", chaque classe possède un numéro
        /// </summary>
        public int NumClasse;

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
        public void finTour(List<Joueur> listeJoueurs, int nbrMax, System.Windows.Controls.Label lblNomJoueur,
            System.Windows.Controls.Label lblArgentJoueur, Image imgSortie)
        {
            foreach(Joueur j in listeJoueurs)
            {
                if (j.sonTour == true)
                {
                    if(j.Numero == nbrMax)
                        changeTour(listeJoueurs, 0, lblNomJoueur, lblArgentJoueur, imgSortie);
                    else
                        changeTour(listeJoueurs, j.Numero, lblNomJoueur, lblArgentJoueur, imgSortie);
                    break;
                }
            }
        }

        /// <summary>
        /// Change le tour des joueurs
        /// </summary>
        /// <param name="nbr">Numero du Joueur</param>
        public void changeTour(List<Joueur> listeJoueurs, int nbr, System.Windows.Controls.Label lblNomJoueur,
            System.Windows.Controls.Label lblArgentJoueur, Image imgSortie)
        {
            nbr++;
            foreach(Joueur j in listeJoueurs)
            {
                if (j.Numero == nbr)
                {
                    j.sonTour = true;
                    lblNomJoueur.Content = j.Nom;
                    //TODOCORENTIN Utiliser fonction "GagnerArgent"
                    lblArgentJoueur.Content = j.Argent;
                    if (j.Sortie > 0)
                        imgSortie.Visibility = Visibility.Visible;
                    else
                        imgSortie.Visibility = Visibility.Hidden;
                }
                else
                    j.sonTour = false;
            }
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
                    txtboxConsole.AppendText(j.Nom + " paie 200€ à l'entraîneur. \n");
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
                    txtboxConsole.AppendText(j.Nom + " doit 150€ au service postal. \n");
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
                    txtboxConsole.AppendText(j.Nom + " paie 150€ de barbier. Superbe barbe ! \n");
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
                    txtboxConsole.AppendText(j.Nom + " rentre sur le champ de bataille ! \n");
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
                    txtboxConsole.AppendText(j.Nom + " répare son équipement pour 200€. \n");
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

        /// <summary>
        /// Permet d'acheter une propriété et l'ajoute au patrimoine
        /// </summary>
        /// <param name="proprieteAchetee">Propriété achetée</param>
        public void AcheterUnePropriete(Propriete proprieteAchetee, Banque banquier)
        {
            //banquier.PerdsArgent(this, proprieteAchetee.Prix[0]);   //le solde est mis à jour
            //Patrimoine.Add(proprieteAchetee.Nom);                   //la liste des propriétés est mise à jour
            //proprieteAchetee.EstAchetee = true;                     //verrouille l'achat de la case
            //proprieteAchetee.Proprietaire = Nom;                    //met à jour le nom du propriétaire dans la case
        }

        //TODOLORENZO VOIR COMMENT CE DEROULE UNE PARTIE POUR REMPLIR CES 2 METHODES
        void PerdrePartie()
        {

        }

        void GagnerPartie()
        {

        }
    }
}
