using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyVS.Modeles
{
    public class Gestion
    {
        List<string> Ordre = new List<string>();

        void DefOrdre(Des des)
        {
            //DEFINI L'ORDRE DES JOUEURS
            List<int> tri = new List<int>();
            for(int i = 0; i < Ordre.Count; i++)
            {
                des.Lancer();
                tri[i] = des.Premier + des.Deuxieme;
            }
        }
    }
}
