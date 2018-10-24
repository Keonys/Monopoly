#region NAMESPACE
using MonopolyVS.Modeles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace MonopolyVS
{
    public class Joueur
    {
        #region PARAMETRES ET VARIABLES
        public string Nom { get; }
        //Solde compte du joueur
        public double Argent { get; set; }
        //Position du joueur sur le plateau
        public int Position { get; set; }
        //liste contenant l'ensemble des propriétés acquises par le joueur
        public List<string> Patrimoine { get; set; } = new List<string>();

        //variables pour le nombre de doublés d'affilée et le nombre de tours restant en prison
        int nbrDouble, iPeine;
        bool estEnPrison = false;
        //Si c'est le tour du joueur
        bool sonTour = false;
        #endregion

        /// <summary>
        /// Permet de se déplacacer dans le plateau
        /// </summary>
        /// <param name="distance">Nombre de case à parcourir</param>
        public void Bouge(int distance)
        {
            Position += distance;
        }

        /// <summary>
        /// Permet d'acheter une propriété et l'ajoute au patrimoine
        /// </summary>
        /// <param name="proprieteAchetee">Propriété achetée</param>
        public void AcheterUnePropriete(Propriete proprieteAchetee, Banque banquier)
        {
            banquier.PerdsArgent(this, proprieteAchetee.Prix[0]);   //le solde est mis à jour
            Patrimoine.Add(proprieteAchetee.Nom);   //la liste des propriétés est mise à jour
            proprieteAchetee.EstAchetee = true; //verrouille l'achat de la case
            proprieteAchetee.Proprietaire = Nom;    //met à jour le nom du propriétaire dans la case
        }



        //VOIR COMMENT DE DEROULE UNE PARTIE POUR REMPLIR CES 2 METHODES
        void PerdrePartie()
        {

        }

        void GagnerPartie()
        {

        }

        /// <summary>
        /// Téléporte le joueur vers la case prison, défini la peine du joueur ainsi que son statut de prisonnier.
        /// </summary>
        void AllerPrison()
        {
            Position = -1; //VALEUR A REMPLACER PAR LE NUMERO DE CASE CORRESPONDANT A LA PRISON
            iPeine = 3; //met la peine du joueur à 3 tours
            estEnPrison = true; //verrouille le joueur dans l'état prisonnier
        }
    }
}
