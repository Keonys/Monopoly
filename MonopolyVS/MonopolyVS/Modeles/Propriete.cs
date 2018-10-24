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
        #region PARAMETRES ET VARIABLES
        public string Nom { get; set; }
        //Type de case (Gare, rue ...)
        public string Type { get; }
        //Couleur case (si rue)
        public string Couleur { get; }
        public bool EstAchetee { get; set; } = false;
        //Nom du joueur qui a acquis la case
        public string Proprietaire { get; set; } = String.Empty;
        public bool EstHypotheque { get; set; } = false;
        //Prix d'achat de la case [0], des maisons [1], des hôtels[2], du loyer[3]. Indique aussi le montant de l'hypothèque [4]
        public double[] Prix { get; } = new double[5];
        //Nombre maisons sur case
        public int NbrMaison { get; set; } = 0;
        //Nombre hôtel sur case (0 ou 1)
        public bool NbrHotel { get; set; } = false;
        #endregion
    }
}