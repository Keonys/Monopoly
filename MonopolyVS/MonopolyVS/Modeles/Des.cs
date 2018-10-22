using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyVS.Modeles
{
    public class Des
    {
        //initialisation des variables contenant le résultat des dés
        int iPremier = -1;
        int iDeuxieme = -1;
        Random alea = new Random(); //initialisation du générateur de valeurs aléatoires
        
        
        /// <summary>
        /// Methode permettant de lancer les 2 dés, ne retourne aucune valeur.
        /// </summary>
        public void Lancer()
        {

            iPremier = alea.Next(1, 13);
            iDeuxieme = alea.Next(1, 13);
        }

        /// <summary>
        /// Permet de récupérer la valeur du premier dé
        /// </summary>
        /// <returns>Valeur du 1er dé sous forme de int.</returns>
        public int RecuperePremier()
        {
            return iPremier;
        }

        /// <summary>
        /// Permet de récupérer la valeur du deuxième dé.
        /// </summary>
        /// <returns>Valeur du 2eme dé sous forme de int.</returns>
        public int RecupereDeuxieme()
        {
            return iDeuxieme;
        }

        /// <summary>
        /// Permet de savoir si les deux dés ont la même valeur.
        /// </summary>
        /// <returns></returns>
        public bool EstDouble()
        {
            if (iPremier == iDeuxieme)
                return true;
            else
                return false;
        }
    }
}
