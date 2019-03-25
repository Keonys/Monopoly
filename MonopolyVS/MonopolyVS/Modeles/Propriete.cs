#region NAMESPACE
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace MonopolyVS.Modeles
{
    public class Propriete : Case
    {
        #region Propriétés et variables

        public int Numero { get; set; }
        public string Nom { get; set; }
        //Type de case (Gare, rue ...)
        public string Type { get; }
        //Couleur case (si rue)
        public string Couleur { get; }
        public bool EstAchetee { get; set; } = false;
        //Joueur qui a acquis la case
        public Joueur Proprietaire { get; set; }
        public bool EstHypotheque { get; set; } = false;
        //Loyer du terrain [0], des maisons [1-2-3-4], de l'hôtel [5]
        public double[] Loyer { get; } = new double[6];
        //Prix du Terrain
        public int PrixTerrain { get; } = 0;
        //Prix de chaque maison et d'un hotel
        public int PrixMaison { get; } = 0;
        //TODOCORENTIN LOYER + HYPOTHEQUE A AJOUTER
        //Nombre maisons sur case
        public int NbrMaison { get; set; } = 0;
        //Nombre hôtel sur case (0 ou 1)
        public bool NbrHotel { get; set; } = false;

        #endregion

        #region Constructeurs

        public Propriete()
        {

        }

        public Propriete(int numero, string nom, string couleur, int prixTerrain, int prixMaison, double[] loyer)
        {
            Numero = numero;
            Nom = nom;
            Couleur = couleur;
            PrixTerrain = prixTerrain;
            PrixMaison = prixMaison;
            Loyer = loyer;
        }

        #endregion
    }
}