#region NAMESPACE
using MonopolyVS.Modeles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Shapes;
#endregion

namespace MonopolyVS
{
    public class Joueur
    {
        #region Objets

        Banque Banque = new Banque();
        Des Des = new Des();

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
        /// <param name="pion"></param>
        public Joueur(int numero, string nom, int position, int argent)
        {
            Numero = numero;
            Nom = nom;
            Position = position;
            Argent = argent;
        }

        #endregion

        #region Méthodes

        /// <summary>
        /// Termine le tour du joueur puis le change
        /// </summary>
        /// <param name="listeJoueurs"></param>
        /// <param name="nbrMax"></param>
        /// <param name="lblNomJoueur"></param>
        public void finTour(List<Joueur> listeJoueurs, int nbrMax, System.Windows.Controls.Label lblNomJoueur, System.Windows.Controls.Label lblArgentJoueur)
        {
            foreach(Joueur j in listeJoueurs)
            {
                if (j.sonTour == true)
                {
                    if(j.Numero == nbrMax)
                        changeTour(listeJoueurs, 0, lblNomJoueur, lblArgentJoueur);
                    else
                        changeTour(listeJoueurs, j.Numero, lblNomJoueur, lblArgentJoueur);
                    break;
                }
            }
        }

        /// <summary>
        /// Change le tour des joueurs
        /// </summary>
        /// <param name="nbr">Numero du Joueur</param>
        public void changeTour(List<Joueur> listeJoueurs, int nbr, System.Windows.Controls.Label lblNomJoueur, System.Windows.Controls.Label lblArgentJoueur)
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
                }
                else
                    j.sonTour = false;
            }
        }

        /// <summary>
        /// Affecte des coordonnées aux pions
        /// </summary>
        /// <param name="top1"></param>
        /// <param name="left1"></param>
        /// <param name="top2"></param>
        /// <param name="left2"></param>
        public void setValueCanvas(double top, double left, Joueur j, Rectangle pion1, Rectangle pion2)
        {
            if (j.Numero == 1)
            {
                pion1.SetValue(Canvas.TopProperty, top);
                pion1.SetValue(Canvas.LeftProperty, left);
            }
            else if (j.Numero == 2)
            {
                pion2.SetValue(Canvas.TopProperty, top);
                pion2.SetValue(Canvas.LeftProperty, left);
            }
        }

        /// <summary>
        /// Place le pion sur la bonne case, grâce au positionnement du canvas
        /// </summary>
        /// <param name="position">Case où ce trouve le pion à la fin du tour</param>
        public void Placement(int position, Joueur j, Rectangle pion1, Rectangle pion2)
        {
            switch (position)
            {
                case (0):
                    //Case départ -- +200€ ; l'ajout des 200€ est géré au moment du passage sur la case dans Controleur.Move()
                    setValueCanvas(0.0, 0.0, j, pion1, pion2);
                    setValueCanvas(0.0, 0.0, j, pion1, pion2);
                    break;
                case (1):
                    //Cross Roads -- Propriété de 60€
                    setValueCanvas(0.0, -95.0, j, pion1, pion2);
                    setValueCanvas(0.0, -100.0, j, pion1, pion2);

                    

                    DialogResult dialogResult = MessageBox.Show("Sure", "Some Title", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        //do something
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        //do something else
                    }

                    break;
                case (2):
                    setValueCanvas(0.0, -165.0, j, pion1, pion2);
                    setValueCanvas(0.0, -175.0, j, pion1, pion2);
                    break;
                case (3):
                    setValueCanvas(0.0, -239.0, j, pion1, pion2);
                    setValueCanvas(0.0, -244.0, j, pion1, pion2);
                    break;
                case (4):
                    setValueCanvas(0.0, -314.0, j, pion1, pion2);
                    setValueCanvas(0.0, -319.0, j, pion1, pion2);
                    break;
                case (5):
                    setValueCanvas(0.0, -387.0, j, pion1, pion2);
                    setValueCanvas(0.0, -392.0, j, pion1, pion2);
                    break;
                case (6):
                    setValueCanvas(0.0, -461.0, j, pion1, pion2);
                    setValueCanvas(0.0, -466.0, j, pion1, pion2);
                    break;
                case (7):
                    setValueCanvas(0.0, -532.0, j, pion1, pion2);
                    setValueCanvas(0.0, -537.0, j, pion1, pion2);
                    break;
                case (8):
                    setValueCanvas(0.0, -606.0, j, pion1, pion2);
                    setValueCanvas(0.0, -611.0, j, pion1, pion2);
                    break;
                case (9):
                    setValueCanvas(0.0, -680.0, j, pion1, pion2);
                    setValueCanvas(0.0, -685.0, j, pion1, pion2);
                    break;
                case (10):
                    //CASE VISITE PRISON
                    setValueCanvas(0.0, -795.0, j, pion1, pion2);
                    setValueCanvas(26.0, -770.0, j, pion1, pion2);
                    break;
                case (11):
                    setValueCanvas(-83.0, -777.0, j, pion1, pion2);
                    setValueCanvas(-74.0, -782.0, j, pion1, pion2);
                    break;
                case (12):
                    setValueCanvas(-143.0, -777.0, j, pion1, pion2);
                    setValueCanvas(-134.0, -782.0, j, pion1, pion2);
                    break;
                case (13):
                    setValueCanvas(-203.0, -777.0, j, pion1, pion2);
                    setValueCanvas(-194.0, -782.0, j, pion1, pion2);
                    break;
                case (14):
                    setValueCanvas(-263.0, -777.0, j, pion1, pion2);
                    setValueCanvas(-254.0, -782.0, j, pion1, pion2);
                    break;
                case (15):
                    setValueCanvas(-323.0, -777.0, j, pion1, pion2);
                    setValueCanvas(-314.0, -782.0, j, pion1, pion2);
                    break;
                case (16):
                    setValueCanvas(-383.0, -777.0, j, pion1, pion2);
                    setValueCanvas(-374.0, -782.0, j, pion1, pion2);
                    break;
                case (17):
                    setValueCanvas(-443.0, -777.0, j, pion1, pion2);
                    setValueCanvas(-434.0, -782.0, j, pion1, pion2);
                    break;
                case (18):
                    setValueCanvas(-503.0, -777.0, j, pion1, pion2);
                    setValueCanvas(-494.0, -782.0, j, pion1, pion2);
                    break;
                case (19):
                    setValueCanvas(-563.0, -777.0, j, pion1, pion2);
                    setValueCanvas(-554.0, -782.0, j, pion1, pion2);
                    break;
                case (20):
                    setValueCanvas(-655.0, -777.0, j, pion1, pion2);
                    setValueCanvas(-645.0, -782.0, j, pion1, pion2);
                    break;
                case (21):
                    setValueCanvas(-655.0, -680.0, j, pion1, pion2);
                    setValueCanvas(-645.0, -685.0, j, pion1, pion2);
                    break;
                case (22):
                    setValueCanvas(-655.0, -606.0, j, pion1, pion2);
                    setValueCanvas(-645.0, -611.0, j, pion1, pion2);
                    break;
                case (23):
                    setValueCanvas(-655.0, -532.0, j, pion1, pion2);
                    setValueCanvas(-645.0, -537.0, j, pion1, pion2);
                    break;
                case (24):
                    setValueCanvas(-655.0, -461.0, j, pion1, pion2);
                    setValueCanvas(-645.0, -466.0, j, pion1, pion2);
                    break;
                case (25):
                    setValueCanvas(-655.0, -387.0, j, pion1, pion2);
                    setValueCanvas(-645.0, -392.0, j, pion1, pion2);
                    break;
                case (26):
                    setValueCanvas(-655.0, -314.0, j, pion1, pion2);
                    setValueCanvas(-645.0, -319.0, j, pion1, pion2);
                    break;
                case (27):
                    setValueCanvas(-655.0, -239.0, j, pion1, pion2);
                    setValueCanvas(-645.0, -244.0, j, pion1, pion2);
                    break;
                case (28):
                    setValueCanvas(-655.0, -165.0, j, pion1, pion2);
                    setValueCanvas(-645.0, -175.0, j, pion1, pion2);
                    break;
                case (29):
                    setValueCanvas(-655.0, -95.0, j, pion1, pion2);
                    setValueCanvas(-645.0, -100.0, j, pion1, pion2);
                    break;
                case (30):
                    setValueCanvas(-655.0, 0.0, j, pion1, pion2);
                    setValueCanvas(-645.0, 0.0, j, pion1, pion2);
                    break;
                case (31):
                    setValueCanvas(-563.0, 10.0, j, pion1, pion2);
                    setValueCanvas(-554.0, 4.0, j, pion1, pion2);
                    break;
                case (32):
                    setValueCanvas(-503.0, 10.0, j, pion1, pion2);
                    setValueCanvas(-494.0, 4.0, j, pion1, pion2);
                    break;
                case (33):
                    setValueCanvas(-443.0, 10.0, j, pion1, pion2);
                    setValueCanvas(-494.0, 4.0, j, pion1, pion2);
                    break;
                case (34):
                    setValueCanvas(-383.0, 10.0, j, pion1, pion2);
                    setValueCanvas(-374.0, 4.0, j, pion1, pion2);
                    break;
                case (35):
                    setValueCanvas(-323.0, 10.0, j, pion1, pion2);
                    setValueCanvas(-314.0, 4.0, j, pion1, pion2);
                    break;
                case (36):
                    setValueCanvas(-263.0, 10.0, j, pion1, pion2);
                    setValueCanvas(-254.0, 4.0, j, pion1, pion2);
                    break;
                case (37):
                    setValueCanvas(-203.0, 10.0, j, pion1, pion2);
                    setValueCanvas(-194.0, 4.0, j, pion1, pion2);
                    break;
                case (38):
                    setValueCanvas(-143.0, 10.0, j, pion1, pion2);
                    setValueCanvas(-134.0, 4.0, j, pion1, pion2);
                    break;
                case (39):
                    setValueCanvas(-83.0, 10.0, j, pion1, pion2);
                    setValueCanvas(-74.0, 4.0, j, pion1, pion2);
                    break;
                case (40):
                    //CASE PRISON
                    setValueCanvas(-21.0, -757.0, j, pion1, pion2);
                    setValueCanvas(-3.0, -757.0, j, pion1, pion2);
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
            //Patrimoine.Add(proprieteAchetee.Nom);   //la liste des propriétés est mise à jour
            //proprieteAchetee.EstAchetee = true; //verrouille l'achat de la case
            //proprieteAchetee.Proprietaire = Nom;    //met à jour le nom du propriétaire dans la case
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
