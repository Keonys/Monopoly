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
        public int Premier { get; set; } = -1;
        public int Deuxieme { get; set; } = -1;
        Random alea = new Random(); //initialisation du générateur de valeurs aléatoires
        
        
        /// <summary>
        /// Methode permettant de lancer les 2 dés, ne retourne aucune valeur.
        /// </summary>
        public void Lancer()
        {

            Premier = alea.Next(1, 13);
            Deuxieme = alea.Next(1, 13);
        }

        /// <summary>
        /// Permet de savoir si les deux dés ont la même valeur.
        /// </summary>
        /// <returns></returns>
        public bool EstDouble()
        {
            if (Premier == Deuxieme)
                return true;
            else
                return false;
        }
    }
}
