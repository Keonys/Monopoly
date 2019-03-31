#region NAMESPACE
using MonopolyVS.Controleurs;
using MonopolyVS.Vues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
#endregion

namespace MonopolyVS.Modeles
{
    public class Banque
    {
        #region MEMBRES

        //Nombre maisons et hôtels pour 1 partie
        int nbrMaison = 32;
        int nbrHotel = 12;
        //Lorsque la banque ne peut plus proposer de maisons, une crise du batiment est déclenchée
        public static bool Crise { get; } = false;

        Controleur control;

        #endregion

        #region CONSTRUCTEURS
        public Banque()
        {

        }

        public Banque(Controleur c)
        {
            control = c;
        }
        #endregion

        #region METHODES
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
        public void ConstruireMaison(int nbr)
        {
            nbrMaison -= nbr;
        }

        public void DetruireMaison(int nbr)
        {
            nbrMaison += nbr;
        }

        /// <summary>
        /// Echange 4 maisons de la case d'un joueur contre 1 hôtel et déduis le prix de la trzansaction au joueur
        /// </summary>
        /// <param name="nomJoueur">Joueur construisant l'hôtel</param>
        /// <param name="propriete">Case où est construit l'hôtel</param>
        public void ConstruireHotel(int nbr)
        {
            nbrHotel -= nbr;
        }

        public void DetruireHotel(int nbr)
        {
            nbrHotel += nbr;
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

        public void initOperation(Propriete AVendre, Joueur Vendeur, List<Joueur> joueursEnJeu, Controleur c)
        {
            c.SwitchVerrouFenetre();
            FormChoixAchatVente operation = new FormChoixAchatVente(Vendeur, joueursEnJeu, this, AVendre, c.listePropriete, c);
            operation.Show();
        }

        /// <summary>
        /// Vend la propriétée d'un joueur spécifié à un autre joueur
        /// </summary>
        /// <param name="AVendre">Propriété à vendre</param>
        /// <param name="Vendeur">Joueur vendeur</param>
        /// <param name="Acheteur">Joueur aquereur</param>
        /// <param name="Prix"></param>
        public void initVendPropriete(Propriete AVendre, Joueur Vendeur, List<Joueur> joueursEnJeu, Controleur c)
        {
            FormulaireVente modalites = new FormulaireVente(Vendeur, joueursEnJeu, this, AVendre, c);
            modalites.Show();
        }

        public void initAchatMaison(Propriete constructible, Joueur acheteur, List<Joueur> joueursEnJeu, List<Propriete> listeProp, Controleur c)
        {
            switch (CheckAchatMaison(constructible,acheteur, listeProp))
            {
                default :
                    MessageBox.Show("Aucune opération de construction est disponible en l'état.");
                    c.SwitchVerrouFenetre();
                    break;
                case 0 :
                    FormulaireAchat modalitesMaison = new FormulaireAchat(0, this, acheteur, constructible, c);
                    modalitesMaison.Show();
                    break;
                case 1 :
                    FormulaireAchat modalitesHotel = new FormulaireAchat(1, this, acheteur, constructible, c);
                    modalitesHotel.Show();
                    break;
            }
        }

        public void VendPropriete(FormulaireVente form, Propriete AVendre, Joueur Vendeur)
        {
            Joueur acheteur = form.GetAcheteur();

            if (AVendre.Numero == 5 || AVendre.Numero == 15 || AVendre.Numero == 25 || AVendre.Numero == 35)
            {
                acheteur.nbrDonjons++;
                Vendeur.nbrDonjons--;
            }

            AVendre.Proprietaire = acheteur;
            Vendeur.Patrimoine.Remove(AVendre);
            acheteur.Patrimoine.Add(AVendre);

            foreach (Case ca in control.listeCases)
            {
                if (ca.Num == AVendre.Numero)
                {
                    AVendre.afficheAppartenanceCase(acheteur, ca);
                }
            }
        }

        /// <summary>
        /// Vérifie la disponibilité de la construction d'hôtel ou de maisons
        /// </summary>
        /// <param name="constructible">Terrain sur lequel on souhaite construire</param>
        /// <param name="proprietaire">Propriétaire du terrain</param>
        /// <param name="listePropriete">Liste des propriétés du plateau</param>
        /// <returns></returns>
        private int CheckAchatMaison(Propriete constructible, Joueur proprietaire, List<Propriete> listePropriete)
        {
            bool hotel = true;
            bool maison = true;
            int couleurTotal = 0, couleur = 0;
            foreach (Propriete prop in listePropriete)
            {
                //Vérifie si tout les terrain sont possédé (si couleur == couleurTotal)
                if (prop.Couleur == constructible.Couleur)
                    couleurTotal++;
                if (prop.Couleur == constructible.Couleur && prop.Proprietaire == proprietaire)
                    couleur++;

                if (prop.Couleur == constructible.Couleur && constructible.NbrMaison != 4 && (prop.NbrMaison != 4 || !prop.Hotel))
                    hotel = false;
                if (prop.Couleur == constructible.Couleur && constructible.NbrMaison > prop.NbrMaison)
                    maison = false;
            }

            if (couleur != couleurTotal)
            {
                hotel = false;
                maison = false;
            }

            if (constructible.Hotel == true)
                hotel = false;

            if (nbrHotel == 0)
                hotel = false;

            if (nbrMaison == 0)
                maison = false;

            if (hotel)
                return 1;
            else if (maison)
                return 0;
            else return -1;
        }

        public int NbrMaisonAchetable(Joueur proprietaire, Propriete aComparer, List<Propriete> listeProp)
        {
            int nombreMin = 999;
            foreach (Propriete prop in listeProp)
            {
                if (prop.Couleur == aComparer.Couleur)
                {
                    if (prop.Hotel != true && prop.NbrMaison < nombreMin)
                        nombreMin = prop.NbrMaison;
                }
            }
            if (aComparer.NbrMaison <= nombreMin)
                return 1;
            else return 0;
        }
        #endregion
    }
}
