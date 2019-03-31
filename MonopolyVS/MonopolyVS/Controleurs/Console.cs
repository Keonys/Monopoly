using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MonopolyVS.Controleurs
{
    public class Console
    {
        #region MEMBRES
        private TextBox Afficheur;
        #endregion
        
        #region CONSTRUCTEURS
        public Console()
        {

        }

        public Console(TextBox console)
        {
            Afficheur = console;
        }
        #endregion

        #region METHODES
        private void Print(string aAfficher)
        {
            Afficheur.AppendText(aAfficher);
            Afficheur.ScrollToEnd();
        }

        public void SautLigne()
        {
            Print("\n");
        }

        public void AfficheDe(int result1, int result2)
        {
            Print("Le premier dé affiche un " + Convert.ToString(result1) + ".\n" +
                "Le deuxième dé affiche un " + Convert.ToString(result2) + ".\n");
        }

        public void Double()
        {
            Print("Doublé !\n");
        }

        public void ResultatLance(string joueur, int resultat)
        {
            Print(joueur + " a fait un " + Convert.ToString(resultat) + ".\n");
        }

        public void JoueurAvance(string joueur, int resultat)
        {
            Print(joueur + " avance de : " + Convert.ToString(resultat) + " cases.\n");
        }
        public void OrdreJoueurs(string joueur, int ordre)
        {
            Print(joueur + " jouera en position " + Convert.ToString(ordre) + ".\n");
        }
        
        public void Gain(string joueur, int prix)
        {
            Print(joueur + " gagne " + Convert.ToString(prix) +" PO.\n");
        }

        #region CHAMP DE BATAILLE
        public void ChampBataille(string joueur)
        {
            Print(joueur + " entre dans le champ de bataille.\n");
        }

        public void TripleDouble(string joueur)
        {
            Print("C'est votre 3ème double ! Direction le champ de bataille.\nVous pourrez retenter un double au prochain tour pour sortir du champ de bataille.\n");
            ChampBataille(joueur);
        }

        public void TenteDouble()
        {
            Print("Vous devez faire un doublé pour sortir de prison.\n");
        }

        public void ResterChampBataille(string joueur)
        {
            Print(joueur + " a choisi de rester ce battre !\n");
        }

        public void SortieChampBataille(string joueur, bool parDouble, bool jetonChance, bool potVin)
        {
            if (parDouble)
                Print("Doublé, vous pouvez sortir du champ de bataille et rejouer !\n");

            if (jetonChance)
                Print("Jeton utilisé !\n");

            if (potVin)
                Print("Vous avez payé un pot de vin, sortez du champ de bataille.\n");

            Print(joueur + " quitte le champ de bataille.\n");
        }
        #endregion

        public void Carte(bool chance, string contenu)
        {
            if (chance)
                Print("Carte Chance : \n");
            else
                Print("Carte Caisse de Communauté : \n");

            Print(contenu + "\n");
        }

        public void AchatPropriete(bool donjon, bool vendu, string joueur, string propriete, bool achete)
        {
            if (vendu)
            {
                if (donjon)
                    Print(joueur+ " a acheté le donjon : " + propriete + ".\n");
                else Print(joueur + " a acheté : " + propriete + ".\n");
            }
            else
            {
                if (donjon)
                    Print(joueur + " a choisi de ne pas acheter le donjon : " + propriete + ".\n");
                else Print(joueur + " a choisi de ne pas acheter : " + propriete + ".\n");
            }

            if (achete)
            {
                Print(propriete + " vous appartient déjà " + joueur + " !\n");
            }
        }

        public void VentePropriete(string vendeur, string propriete, string acheteur, int prix)
        {
            Print(vendeur + " a vendu " + propriete + " pour " + Convert.ToString(prix) + " PO à " + acheteur + ".\n");
        }

        public void AchatVenteMaison(bool hotel, bool vendu, string joueur, string propriete)
        {
            if (vendu)
            {
                if (hotel)
                    Print(joueur + " a acheté un hôtel pour " + propriete + ".\n");
                else Print(joueur + " a acheté une maison pour " + propriete + ".\n");
            }
            else
            {
                if (hotel)
                    Print(joueur + " a choisi de ne pas un hôtel " + propriete + ".\n");
                else Print(joueur + " a choisi de ne pas de maison pour " + propriete + ".\n");
            }
        }

        //PEUT ETRE INUTILE A L'AVENIR
        public void ImpossibleConstruire(string joueur, string propriete)
        {
            Print(joueur + " ne peut plus rien construire sur " + propriete + ".\n");
        }

        public void Paie(string payeur, string paye, bool loyer, double prix)
        {
            if (loyer)
                Print(payeur + " paie " + prix + "PO de loyer à " + paye + ".\n");
            else Print(payeur + " paie " + prix + "PO à " + paye + ".\n");
        }

        public void Evenements(int position, string joueur)
        {
            switch (position)
            {
                case (4):
                    Print(joueur + " paie 200 PO à l'entraîneur.\n");
                    break;
                case (10):
                    Print(joueur + " longe le champ de bataille.\n");
                    break;
                case (12):
                    Print(joueur + " doit 150 PO au service postal.\n");
                    break;
                case (28):
                    Print(joueur + " paie 150 PO de barbier. Superbe barbe !\n");
                    break;
                case (30):
                    ChampBataille(joueur);
                    break;
                case (38):
                    Print(joueur + " répare son équipement pour 200 PO.\n");
                    break;
            }
        }

        #region VICTOIRE DEFAITE
        public void Perdre(string joueur)
        {
            Print(joueur + " n'as plus d'argent. Il faudra vendre un terrain, un bâtiment, ou perdre la partie.\n");
        }

        public void Defaite(string joueur)
        {
            Print(joueur + " a perdu la partie.\n");
        }

        public void Victoire(string joueur)
        {
            Print(joueur + " remporte la partie. \n");
        }
        #endregion

        #endregion
    }
}
