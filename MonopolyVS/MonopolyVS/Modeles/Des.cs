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
        public int Resultat { get; set; }
        Random alea = new Random(); //initialisation du générateur de valeurs aléatoires
        
        
        /// <summary>
        /// Lance les 2 dés.
        /// </summary>
        public void Lancer()
        {
            //donne une valeur aleatoire entre 1 et 12 pour les deux dés
            Premier = alea.Next(1, 13);
            Deuxieme = alea.Next(1, 13);
            Resultat = Premier + Deuxieme;
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
    }
}
