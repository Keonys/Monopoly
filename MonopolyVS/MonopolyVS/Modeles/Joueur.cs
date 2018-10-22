using MonopolyVS.Modeles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyVS
{
    public class Joueur
    {
        string sNom;
        int iArgent, iPosition, iNbrDouble, iPeine; //variables pour le solde en banque, la position sur le plateau et le nombre de doublés d'affilée
        bool bEstEnPrison = false;
        bool bSonTour = false;
        List<string> sPatrimoine = new List<string>();  //liste contenant la liste des propriétés acquises par le joueur

        /// <summary>
        /// Permet de se déplacacer dans le plateau
        /// </summary>
        /// <param name="distance">Nombre de case à parcourir</param>
        public void Bouge(int distance)
        {
            iPosition += distance;
        }

        //2 PROCHAINES METHODES PEUT-ETRE A DEPLACER VERS BANQUE

        /// <summary>
        /// Met à jour le solde du joueur lors d'un gain d'argent
        /// </summary>
        /// <param name="gains">Argent gagné</param>
        void GagneArgent(int gains)
        {
            iArgent += gains;
        }

        /// <summary>
        /// Met à jour le solde du joueur lors d'une perte d'argent
        /// </summary>
        /// <param name="gains">Argent perdu</param>
        void PerdsArgent(int pertes)
        {
            iArgent -= pertes;
        }

        /// <summary>
        /// Permet d'acheter une propriété et l'ajoute au patrimoine
        /// </summary>
        /// <param name="proprieteAchetee">Propriété achetée</param>
        public void AcheterUnePropriete(Propriete proprieteAchetee)
        {
            //ATTENTION LA METHODE NE CONTIENT EN L'ETAT QUE DES ACTIONS SUR L'OBJET JOUEUR (L'OBJET PROPRIETE RESTE INCHANGE)
            //ATTENTION LES OBJETS CASE ET PROPRIETE N'ETANT PAS CREEES, LE CODE NE COMPILE PAS
            PerdsArgent(proprieteAchetee.iPrix); //le solde est mis à jour (peut-être à déplacer vers banque ?)
            sPatrimoine.Add(proprieteAchetee.sNom);//la liste des propriétés est mise à jour
            //proprieteAchetee.bEstAchetee = true;
            //proprieteAchetee.sProprietaire = sNom;
        }

        //VOIR COMMENT DE DEROULE UNE PARTIE POUR REMPLIR CES 2 METHODES
        void PerdrePartie()
        {

        }

        void GagnerPartie()
        {

        }

        /// <summary>
        /// Indique la position sur le plateau
        /// </summary>
        /// <returns>Le numéro de la case du plateau</returns>
        int RecuperePosition()
        {
            return iPosition;
        }

        /// <summary>
        /// Montre la liste des propriétés acquises
        /// </summary>
        /// <returns>La liste des propriétés du joueur</returns>
         List<string> RecuperePatrimoine()
        {
            return sPatrimoine;
        }

        /// <summary>
        /// Téléporte le joueur vers la case prison, défini la peine du joueur ainsi que son statut de prisonnier.
        /// </summary>
        void AllerPrison()
        {
            iPosition = -1; //VALEUR A REMPLACER PAR LE NUMERO DE CASE CORRESPONDANT A LA PRISON
            iPeine = 3;
            bEstEnPrison = true;
        }
    }
}
