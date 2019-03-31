#region NAMESPACE
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace MonopolyVS.Modeles
{
    public class Des
    {
        #region MEMBRES
        //initialisation des variables contenant le résultat des dés
        public int Premier { get; set; } = -1;
        public int Deuxieme { get; set; } = -1;
        public int Resultat { get; set; }
        Random alea = new Random(); //initialisation du générateur de valeurs aléatoires
        #endregion

        #region METHODES
        /// <summary>
        /// Lance les 2 dés.
        /// </summary>
        public int Lancer()
        {
            //donne une valeur aleatoire entre 1 et 6 pour les deux dés
            Premier = alea.Next(1, 7);
            Deuxieme = alea.Next(1, 7);
            Resultat = Premier + Deuxieme;
            return Resultat;
        }

        /// <summary>
        /// Permet de savoir si les deux dés ont la même valeur.
        /// </summary>
        /// <returns>Si doublé ou pas</returns>
        public bool EstDouble()
        {
            //vérifie si les deux dés ont la même valeur
            if (Premier == Deuxieme)
                return true;
            else
                return false;
        }
        #endregion
    }
}
