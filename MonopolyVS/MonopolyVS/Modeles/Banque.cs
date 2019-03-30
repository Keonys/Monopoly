#region NAMESPACE
using MonopolyVS.Vues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace MonopolyVS.Modeles
{
    public class Banque
    {

        //Nombre maisons et hôtels pour 1 partie
        //int nbrMaison = 32;
        //int nbrHotel = 12;
        //Lorsque la banque ne peut plus proposer de maisons, une crise du batiment est déclenchée
        public static bool Crise { get; } = false;

        public Banque()
        {

        }

        /// <summary>
        /// Met à jour le solde d'un joueur lors d'un gain d'argent
        /// </summary>
        /// <param name="joueur">Joueur gagnant l'argent</param>
        /// <param name="gains">Argent gagné</param>
        public static void GagneArgent(Joueur joueur, double gains)
        {
            joueur.Argent += gains;
        }

        /// <summary>
        /// Met à jour le solde d'un joueur lors d'une perte d'argent
        /// </summary>
        /// <param name="joueur">Joueur perdant l'argent</param>
        /// <param name="pertes">Argent perdu</param>
        public static void PerdsArgent(Joueur joueur, double pertes)
        {
            joueur.Argent -= pertes;
        }

        /// <summary>
        /// Fait une transaction entre deux joueurs
        /// </summary>
        /// <param name="donneur">Joueur débité</param>
        /// <param name="receveur">Joueur crédité</param>
        /// <param name="montant">Montant de la transaction</param>
        public void Transaction(Joueur donneur, Joueur receveur, int montant)
        {
            PerdsArgent(donneur, montant);  //mise à jour du solde du joueur débité
            GagneArgent(receveur, montant); //mise à jour du solde du joueur crédité
        }
        
        /// <summary>
        /// Construit un nombre de maisons sur une case définie et déduit l'argent nécéssaire au joueur à qui appartient la case
        /// </summary>
        /// <param name="nomJoueur">Joueur construisant les maisons</param>
        /// <param name="propriete">Case où sont construit les maisons</param>
        /// <param name="nombre">Nombre de maisons à construire</param>
        void ConstruireMaison(Joueur nomJoueur, Propriete propriete, int nombre)
        {
            //PerdsArgent(nomJoueur, propriete.Prix[1] * nombre);   //mise à jour du solde du joueur achetant une maison
            //nbrMaison -= nombre;    //mise à jour du solde de maisons en banque
            //propriete.NbrMaison += nombre;  //construction de la maison sur la case
        }

        /// <summary>
        /// Echange 4 maisons de la case d'un joueur contre 1 hôtel et déduis le prix de la trzansaction au joueur
        /// </summary>
        /// <param name="nomJoueur">Joueur construisant l'hôtel</param>
        /// <param name="propriete">Case où est construit l'hôtel</param>
        void ConstruireHotel(Joueur nomJoueur, Propriete propriete)
        {
            //PerdsArgent(nomJoueur, propriete.Prix[2]);  //mise à jour du solde du joueur achetant un hôtel
            //propriete.NbrMaison -= 4;   //echange des maisons pour construire hôtel
            //nbrMaison += 4; //mise à jour du solde de maisons en banque
            //nbrHotel -= 1;  //mise à jour du solde de'hôtels en banque
            //propriete.NbrHotel = true;  //construction de l'hôtel sur la case
        }

        /// <summary>
        /// Met une hypothèque sur la case d'un joueur
        /// </summary>
        /// <param name="joueur">Joueur a qui appartient la propriétée</param>
        /// <param name="propriete">Case hypothèquée</param>
        void Hypotheque(Joueur joueur, Propriete propriete)
        {
            //GagneArgent(joueur, propriete.Prix[4]); //mise à jour du solde du joueur qui hypothèque la case
            //propriete.EstHypotheque = true; //verrouillage de la case hypothèquée
        }

        /// <summary>
        /// Lève une hypothèque sur la case hypothèquée d'un joueur
        /// </summary>
        /// <param name="joueur">>Joueur a qui appartient la propriétée</param>
        /// <param name="propriete">Case hypothèquée</param>
        void LeverHypotheque(Joueur joueur, Propriete propriete)
        {
            //PerdsArgent(joueur, (propriete.Prix[4] * 1.1)); //mise à jour du solde du joueur qui lève hypothèque la case
            //propriete.EstHypotheque = false;    //déverrouillage de la case hypothèquée
        }

        /// <summary>
        /// Vend la propriétée d'un joueur spécifié à un autre joueur
        /// </summary>
        /// <param name="AVendre">Propriété à vendre</param>
        /// <param name="Vendeur">Joueur vendeur</param>
        /// <param name="Acheteur">Joueur aquereur</param>
        /// <param name="Prix"></param>
        public void VendPropriete(Propriete AVendre, Joueur Vendeur, List<Joueur> joueursEnJeu)
        {
            FormulaireVente modalites = new FormulaireVente(Vendeur, joueursEnJeu, this, AVendre.Nom);
            modalites.Show();
            Joueur acheteur = modalites.GetVendeur();
            if (AVendre.Numero == 5 || AVendre.Numero == 15 || AVendre.Numero == 25 || AVendre.Numero == 35)
            {
                acheteur.nbrDonjons++;
                Vendeur.nbrDonjons--;
            }

            AVendre.Proprietaire = acheteur;
            Vendeur.Patrimoine.Remove(AVendre);
            acheteur.Patrimoine.Add(AVendre);
        }
    }
}
