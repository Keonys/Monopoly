using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MonopolyVS.Controleurs
{
    class Console
    {
        #region
        private TextBox Afficheur;
        #endregion
        
        #region CONSTRUCTEURS
        public Console()
        {

        }

        public Console(TextBox console)
        {

        }
        #endregion

        #region METHODES
        public void Print(string aAfficher)
        {
            Afficheur.AppendText(aAfficher);
            Afficheur.ScrollToEnd();
        }
        #endregion
    }
}
