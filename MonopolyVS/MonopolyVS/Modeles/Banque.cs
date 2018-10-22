using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyVS.Modeles
{
    public class Banque : Joueur
    {
        int nbrMaison = 32;
        int nbrHotel = 12;

        /// <summary>
        /// Met à jour le solde d'un joueur lors d'un gain d'argent
        /// </summary>
        /// <param name="joueur">Joueur gagnant l'argent</param>
        /// <param name="gains">Argent gagné</param>
        public void GagneArgent(Joueur joueur, int gains)
        {
            joueur.Argent += gains;
        }

        /// <summary>
        /// Met à jour le solde d'un joueur lors d'une perte d'argent
        /// </summary>
        /// <param name="joueur">Joueur perdant l'argent</param>
        /// <param name="pertes">Argent perdu</param>
        public void PerdsArgent(Joueur joueur, int pertes)
        {
            joueur.Argent -= pertes;
        }
        
        //2 PROCHAINES METHODES NON FINIES
        /// <summary>
        /// Construit un nombre de maisons sur une case définie et déduit l'argent nécéssaire au joueur à qui appartient la case
        /// </summary>
        /// <param name="nomJoueur">Joueur construisant les maisons</param>
        /// <param name="propriete">Case où sont construit les maisons</param>
        /// <param name="nombre">Nombre de maisons à construire</param>
        void ConstruireMaison(Joueur nomJoueur, Propriete propriete, int nombre)
        {
            //PerdsArgent(propriete.PrixMaison * nombre);
            nbrMaison -= nombre;
            //propriete.nbrMaison += nombre.
        }

        /// <summary>
        /// Echange 4 maisons de la case d'un joueur contre 1 hôtel et déduis le prix de la trzansaction au joueur
        /// </summary>
        /// <param name="nomJoueur">Joueur construisant l'hôtel</param>
        /// <param name="propriete">Case où est construit l'hôtel</param>
        void ConstruireHotel(Joueur nomJoueur, Propriete propriete)
        {
            //PerdsArgent(propriete.PrixHotel * nombre);
            //propriete.nbrMaison -= 4
            nbrMaison += 4;
            nbrHotel -= 1;
            //propriete.nbrHotel ++;
        }

        /// <summary>
        /// Met une hypothèque sur la case d'un joueur
        /// </summary>
        /// <param name="joueur">Joueur a qui appartient la propriétée</param>
        /// <param name="propriete">Case hypothèquée</param>
        void Hypotheque(Joueur joueur, Propriete propriete)
        {
            //GagneArgent(joueur, propriete.Hypotheque);
            //propriete.estHypotheque = true;
        }

        /// <summary>
        /// Lève une hypothèque sur la case hypothèquée d'un joueur
        /// </summary>
        /// <param name="joueur">>Joueur a qui appartient la propriétée</param>
        /// <param name="propriete">Case hypothèquée</param>
        void LeverHypotheque(Joueur joueur, Propriete propriete)
        {
            //PerdsArgent(joueur, (propriete.Hypotheque * 1.1));
            //propriete.estHypotheque = false;
        }
    }
}
