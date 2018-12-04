#region NAMESPACE
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace MonopolyVS.Modeles
{
    public class Prison
    {
        //prix de la sortie de prison
        public int Caution { get; }
        //liste des prisoniers
        List<string> sPrisoniers = new List<string>();

        /// <summary>
        /// Téléporte le joueur vers la case prison, défini la peine du joueur ainsi que son statut de prisonnier.
        /// </summary>
        /// <param name="joueur">Joueur à mettre en prison</param>
        void AllerPrison(Joueur joueur)
        {
            joueur.Position = -1; //VALEUR A REMPLACER PAR LE NUMERO DE CASE CORRESPONDANT A LA PRISON
            joueur.Peine = 3; //met la peine du joueur à 3 tours
            joueur.EstEnPrison = true; //verrouille le joueur dans l'état prisonnier
            sPrisoniers.Add(joueur.Nom);    //ajoute le joueur à la liste des prisonniers
        }
    }
}
