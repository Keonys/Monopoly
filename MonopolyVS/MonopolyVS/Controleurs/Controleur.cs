using MonopolyVS.Modeles;
using System;
using System.Collections.Generic;
using System.Windows.Shapes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Xml.Linq;
using System.Xml;

namespace MonopolyVS.Controleurs
{
    public class Controleur
    {
        #region Listes et Objets

        /// <summary>
        /// Liste des joueurs
        /// </summary>
        List<Joueur> listeJoueurs = new List<Joueur>();

        /// <summary>
        /// Liste des propriete
        /// </summary>
        List<Propriete> listePropriete = new List<Propriete>();

        /// <summary>
        /// Liste des cartes chance
        /// </summary>
        List<Carte> listeChance = new List<Carte>();

        /// <summary>
        /// Liste des cartes caisse de communauté
        /// </summary>
        List<Carte> listeCaisse = new List<Carte>();

        Des Des = new Des();

        //TODOLORENZO nbrJoueur à mettre en dynamique ci-dessous 
        //(L APPLI NE FONCTIONNE QUE POUR 2 JOUEURS POUR LE MOMENT, et un joueur ne peut pas jouer seul)
        int nbrJoueurs = 2;

        #endregion

        #region Méthodes

        /// <summary>
        /// Ajoute les proprietes du XML dans la listePropriete
        /// </summary>
        public void initPropriete()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../XML/Propriete.xml");
            XmlNodeList nodeList = doc.SelectNodes("//Propriete");
            foreach (XmlNode node in nodeList)
            {
                double[] loyer =
                {
                    int.Parse(node.Attributes["prix0"].Value),
                    int.Parse(node.Attributes["prix1"].Value),
                    int.Parse(node.Attributes["prix2"].Value),
                    int.Parse(node.Attributes["prix3"].Value),
                    int.Parse(node.Attributes["prix4"].Value),
                    int.Parse(node.Attributes["prix5"].Value)
                };
                
                listePropriete.Add(new Propriete(
                    int.Parse(node.Attributes["numero"].Value),
                    node.Attributes["nom"].Value,
                    node.Attributes["couleur"].Value,
                    int.Parse(node.Attributes["terrain"].Value),
                    int.Parse(node.Attributes["maison"].Value),
                    loyer
                    ));
            }
        }

        /// <summary>
        /// Ajoute les cartes du XML dans la listeCartes
        /// </summary>
        public void initCarte()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../XML/Chance.xml");
            XmlNodeList nodeList = doc.SelectNodes("//Chance");
            foreach (XmlNode node in nodeList)
            {
                listeChance.Add(new Carte(
                    int.Parse(node.Attributes["id"].Value),
                    node.Attributes["type"].Value,
                    int.Parse(node.Attributes["valeur"].Value),
                    node.Attributes["contenu"].Value
                    ));
            }

            XmlDocument docu = new XmlDocument();
            docu.Load("../../XML/Caisse.xml");
            XmlNodeList nodeL = docu.SelectNodes("//Caisse");
            foreach (XmlNode node in nodeL)
            {
                listeCaisse.Add(new Carte(
                    int.Parse(node.Attributes["id"].Value),
                    node.Attributes["type"].Value,
                    int.Parse(node.Attributes["valeur"].Value),
                    node.Attributes["contenu"].Value
                    ));
            }
        }

        #region METHODE AddJoueurs
        /// <summary>
        /// Ajoute les joueurs a la liste des joueurs
        /// </summary>
        /// <param name="joueur1"></param>
        /// <param name="joueur2"></param>
        public void AddJoueurs(string joueur1, Rectangle j1, string joueur2, Rectangle j2)
        {
            nbrJoueurs = 2;

            for (int i = 1; i <= 2; i++)
            {
                if (i == 1)
                    listeJoueurs.Add(new Joueur(i, joueur1, 0, 1500, j1));
                if (i == 2)
                    listeJoueurs.Add(new Joueur(i, joueur2, 0, 1500, j2));
            }
        }

        /// <summary>
        /// Ajoute les joueurs a la liste des joueurs
        /// </summary>
        /// <param name="joueur1"></param>
        /// <param name="joueur2"></param>
        /// <param name="joueur3"></param>
        public void AddJoueurs(string joueur1, Rectangle j1, string joueur2, Rectangle j2, string joueur3, Rectangle j3)
        {
            nbrJoueurs = 3;

            for (int i = 1; i <= 3; i++)
            {
                if (i == 1)
                    listeJoueurs.Add(new Joueur(i, joueur1, 0, 1500, j1));
                if (i == 2)
                    listeJoueurs.Add(new Joueur(i, joueur2, 0, 1500, j2));
                if (i == 3)
                    listeJoueurs.Add(new Joueur(i, joueur3, 0, 1500, j3));
            }
        }
        /// <summary>
        /// Ajoute les joueurs a la liste des joueurs
        /// </summary>
        /// <param name="joueur1"></param>
        /// <param name="joueur2"></param>
        /// <param name="joueur3"></param>
        /// <param name="joueur4"></param>
        public void AddJoueurs(string joueur1, Rectangle j1, string joueur2, Rectangle j2, string joueur3, Rectangle j3, string joueur4, Rectangle j4)
        {
            nbrJoueurs = 4;

            for (int i = 1; i <= 3; i++)
            {
                if (i == 1)
                    listeJoueurs.Add(new Joueur(i, joueur1, 0, 1500, j1));
                if (i == 2)
                    listeJoueurs.Add(new Joueur(i, joueur2, 0, 1500, j2));
                if (i == 3)
                    listeJoueurs.Add(new Joueur(i, joueur3, 0, 1500, j3));
                if (i == 4)
                    listeJoueurs.Add(new Joueur(i, joueur4, 0, 1500, j4));
            }
        }
        #endregion

        /// <summary>
        /// Initialise l'application
        /// </summary>
        public void initAppli(Label lblTour, Label lblNomJoueur, Label lblPion, Button btnDk, Button btnMage, 
            Button btnLanceDes, Label lblArgent, Label lblArgentJoueur, Button btnListe1, Button btnListe2, 
            Button btnListe3, Button btnListe4)
        {
            lblTour.Visibility = Visibility.Hidden;
            lblNomJoueur.Visibility = Visibility.Hidden;
            lblPion.Visibility = Visibility.Hidden;
            btnDk.Visibility = Visibility.Hidden;
            btnMage.Visibility = Visibility.Hidden;
            btnLanceDes.Visibility = Visibility.Hidden;
            lblArgent.Visibility = Visibility.Hidden;
            lblArgentJoueur.Visibility = Visibility.Hidden;
            btnListe1.Visibility = Visibility.Hidden;
            btnListe2.Visibility = Visibility.Hidden;
            btnListe3.Visibility = Visibility.Hidden;
            btnListe4.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Affiche la liste de propriété du Joueur 1
        /// </summary>
        public void clicListe1(ListBox listboxBien)
        {
            Joueur j = listeJoueurs[0];
            j.afficheProp(listboxBien);
        }

        /// <summary>
        /// Affiche la liste de propriété du Joueur 2
        /// </summary>
        public void clicListe2(ListBox listboxBien)
        {
            Joueur j = listeJoueurs[1];
            j.afficheProp(listboxBien);
        }

        /// <summary>
        /// Affichage de l'écran d'accueil (avant l'affichage du plateau)
        /// </summary>
        public void afficheFormulaire(MainWindow m)
        {
            FormulaireJoueur Menu = new FormulaireJoueur(m, this);

            m.Visibility = Visibility.Hidden;
            Menu.Show();
        }
        
        /// <summary>
        /// Evénement lors du clic sur btnTour
        /// </summary>
        public void clicbtnTour(TextBox textBox, Button btnTour, Label lblTour, Label lblNomJoueur, Label lblPion, 
            Button btnDk, Button btnMage, Label lblArgentJoueur, Button btnListe1, Button btnListe2, Image imgSortie, 
            Rectangle pion1, Rectangle pion2)
        {
            //Initialisation des Joueurs et des Propriétés
            //ATTENTION LA METHODE EN DESSOUS NE FONCTIONNERA PLUS AVEC CES ARGUMENTS
            //AddJoueurs(nbrJoueurs, pion1, pion2);
            initPropriete();
            initCarte();

            int i = 1;
            List<Joueur> listeJoueursTampon = new List<Joueur>();
            listeJoueursTampon = listeJoueurs;
            Dictionary<Joueur, int> mapJoueurs = new Dictionary<Joueur, int>();

            foreach (Joueur j in listeJoueursTampon)
            {
                mapJoueurs.Add(j, Des.Lancer());
                textBox.AppendText(j.Nom + " a fait un " + Convert.ToString(Des.Resultat) + "\n");
            }

            var sortedMap = from entry in mapJoueurs orderby entry.Value descending select entry;

            foreach (KeyValuePair<Joueur, int> entry in sortedMap)
            {
                entry.Key.Numero = i;
                i++;

                textBox.AppendText(entry.Key.Nom + " jouera en position " + entry.Key.Numero + "\n");
            }

            foreach(Joueur j in listeJoueurs)
            {
                if(j.Numero == 1)
                    j.changeTour(listeJoueurs, 0, lblNomJoueur, lblArgentJoueur, imgSortie);
            }

            //nombtnliste
            Joueur jo = listeJoueurs[0];
            btnListe1.Content = "Liste de " + jo.Nom;
            jo = listeJoueurs[1];
            btnListe2.Content = "Liste de " + jo.Nom;

            btnTour.Visibility = Visibility.Hidden;
            lblTour.Visibility = Visibility.Visible;
            lblNomJoueur.Visibility = Visibility.Visible;
            lblPion.Visibility = Visibility.Visible;
            btnDk.Visibility = Visibility.Visible;
            btnMage.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Nomme les boutons btnListe
        /// </summary>
        /// <param name="jo"></param>
        /// <param name="listeJoueurs"></param>
        public void nomBtnListe(List<Joueur> listeJoueurs, Button btnListe1, Button btnListe2, Button btnListe3, Button btnListe4)
        {
            Joueur jo = new Joueur();

            foreach(Joueur j in listeJoueurs)
            {
                jo = listeJoueurs[j.Numero - 1];
                
            }

            if(nbrJoueurs == 2)
            {
                Joueur jodqds = listeJoueurs[0];
                btnListe1.Content = "Liste de " + jo.Nom;
                jo = listeJoueurs[1];
                btnListe2.Content = "Liste de " + jo.Nom;
            }
            if(nbrJoueurs == 3)
            {

            }
        }

        /// <summary>
        /// Evénement lors du clic sur le btnLanceDes
        /// </summary>
        /// <param name="txtboxConsole"></param>
        public void clicBtnLanceDes(TextBox txtboxConsole, Rectangle pion1, Rectangle pion2, Label lblNomJoueur, 
            Label lblArgentJoueur, List<Case> listeCases, Image imgSortie)
        {
            int resultat = 0;
            int position = 0;

            foreach (Joueur j in listeJoueurs)
            {
                if(j.sonTour == true)
                {
                    Des.Lancer();
                    resultat = Des.Resultat;

                    //Affichage à la suite du résultat du lancé et affiche si le lanceur fait un doublé
                    txtboxConsole.AppendText("\nLe premier dé affiche un " + Convert.ToString(Des.Premier) + "\n");
                    txtboxConsole.AppendText("Le deuxième dé affiche un " + Convert.ToString(Des.Deuxieme) + "\n");
                    if(!j.EstEnPrison)
                        txtboxConsole.AppendText(j.Nom + " avance de : " + resultat + " cases. \n");

                    if (Des.EstDouble() && j.EstEnPrison)
                    {
                        txtboxConsole.AppendText("Doublé, vous pouvez sortir du champ de bataille et rejouer !\n");
                        txtboxConsole.AppendText(j.Nom + " avance de : " + resultat + " cases. \n");
                        j.estDouble = true;
                        j.nbrDouble++;
                    }
                    else if(Des.EstDouble())
                    {
                        txtboxConsole.AppendText("Doublé !\n");
                        j.estDouble = true;
                        j.nbrDouble++;
                    }
                    else if(j.EstEnPrison)
                    {
                        txtboxConsole.AppendText("Vous devez faire un doublé pour sortir de prison. \n");
                        j.estDouble = false;
                        j.nbrDouble = 0;
                        j.nbrTourPrison++;

                        if(j.Sortie > 0)
                        {
                            System.Windows.Forms.DialogResult dialogResult = System.Windows.Forms.MessageBox.Show(
                            "Voulez-vous utiliser votre jeton de sortie pour sortir du champ de bataille ?",
                            "Champ de Bataille", System.Windows.Forms.MessageBoxButtons.YesNo);
                            if (dialogResult == System.Windows.Forms.DialogResult.Yes)
                            {
                                txtboxConsole.AppendText("Jeton utilisé !\n");
                                txtboxConsole.AppendText(j.Nom + " avance de : " + resultat + " cases. \n");
                                j.estDouble = true;
                                j.nbrDouble++;
                                j.Sortie--;
                            }
                            else if (dialogResult == System.Windows.Forms.DialogResult.No)
                            {
                                txtboxConsole.AppendText(j.Nom + " a choisi de rester ce battre ! \n");
                                resultat = 0;
                            }
                        }
                        else
                        {
                            System.Windows.Forms.DialogResult dialogResult = System.Windows.Forms.MessageBox.Show(
                            "Voulez-vous verser un pot de vin de 50€ pour sortir du champ de bataille ?",
                            "Champ de Bataille", System.Windows.Forms.MessageBoxButtons.YesNo);
                            if (dialogResult == System.Windows.Forms.DialogResult.Yes)
                            {
                                txtboxConsole.AppendText("Vous avez payé un pot de vin, sortez du champ de bataille. \n");
                                txtboxConsole.AppendText(j.Nom + " avance de : " + resultat + " cases. \n");
                                j.estDouble = true;
                                j.nbrDouble++;
                                j.Argent -= 50;
                            }
                            else if (dialogResult == System.Windows.Forms.DialogResult.No)
                            {
                                txtboxConsole.AppendText(j.Nom + " a choisi de rester ce battre ! \n");
                                resultat = 0;
                            }
                        }
                    }
                    else
                    {
                        j.estDouble = false;
                        j.nbrDouble = 0;
                    }

                    //se rend à la dernière ligne de la console
                    txtboxConsole.ScrollToEnd();

                    j.Position = Move(position, j, resultat, txtboxConsole);
                    position = j.Position;
                    j.Placement(position, j, pion1, pion2, listePropriete, txtboxConsole, listeCases, listeChance, imgSortie, listeCaisse);

                    lblArgentJoueur.Content = j.Argent;

                    if (j.estDouble)
                        break;
                    else
                    {
                        j.finTour(listeJoueurs, nbrJoueurs, lblNomJoueur, lblArgentJoueur, imgSortie);
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Change la position en fonction de plusieurs facteurs
        /// </summary>
        /// <param name="position"></param>
        public int Move(int position, Joueur j, int resultat, TextBox txtboxConsole)
        {
            position = j.Position;
            position += resultat;

            if(j.EstEnPrison && j.estDouble)
            {
                position = 10 + resultat;
                j.EstEnPrison = false;
            }
            else if(j.nbrTourPrison >= 3)
            {
                j.nbrTourPrison = 0;
                j.EstEnPrison = false;
                position = 10 + resultat;
            }
            else if(j.nbrDouble >= 3)
            {
                txtboxConsole.AppendText("C'est votre 3ème double ! Direction le champ de bataille, vous pourrez retenter un double au prochain tour," +
                    " pour sortir du champ de bataille. \n");
                position = 40;
                j.EstEnPrison = true;
                j.nbrDouble = 0;
                j.estDouble = false;
            }
            else if(position > 39 && j.EstEnPrison == false)
            {
                txtboxConsole.AppendText(j.Nom + " gagne 200€. \n");
                position -= 40;
                j.Argent += 200;
            }

            return position;
        }

        /// <summary>
        /// 
        /// </summary>
        public void listeVisibility(Button btnLanceDes, Label lblArgent, Label lblArgentJoueur, Button btnListe1, Button btnListe2
            , Button btnListe3, Button btnListe4, Label lblPion)
        {
            btnLanceDes.Visibility = Visibility.Visible;
            lblArgent.Visibility = Visibility.Visible;
            lblArgentJoueur.Visibility = Visibility.Visible;
            if (nbrJoueurs >= 1)
                btnListe1.Visibility = Visibility.Visible;
            if (nbrJoueurs >= 2)
                btnListe2.Visibility = Visibility.Visible;
            if (nbrJoueurs >= 3)
                btnListe3.Visibility = Visibility.Visible;
            if (nbrJoueurs >= 4)
                btnListe4.Visibility = Visibility.Visible;
            lblPion.Content = "Listes : ";
        }

        /// <summary>
        /// Evénement lors du clic sur btnDk
        /// </summary>
        public void clicbtnDk(Rectangle pion1, Rectangle pion2, TextBox txtboxConsole, Button btnDk, Label lblPion, Button btnLanceDes,
            Label lblNomJoueur, Label lblArgent, Label lblArgentJoueur, Button btnListe1, Button btnListe2, Button btnListe3,
            Button btnListe4, Image imgSortie)
        {
            foreach(Joueur j in listeJoueurs)
            {
                if(j.sonTour == true)
                {
                    //TODOCORENTIN Fonctionne pour 2 joueurs uniquement
                    if(j.Numero == 1 && j.sonTour == true)
                    {
                        pion1.Fill = new ImageBrush(new BitmapImage(new Uri(@"..\..\Images\39px-ClassIcon_deathknightFOND.png", UriKind.Relative)));
                        txtboxConsole.AppendText(j.Nom + " a choisi le chevalier de la mort." + "\n");
                        txtboxConsole.AppendText("Le joueur 2 choisit son pion : " + "\n");
                        j.finTour(listeJoueurs, nbrJoueurs, lblNomJoueur, lblArgentJoueur, imgSortie);
                        btnDk.Visibility = Visibility.Hidden;
                        break;
                    }
                    else if(j.Numero == 2 && j.sonTour == true)
                    {
                        pion2.Fill = new ImageBrush(new BitmapImage(new Uri(@"..\..\Images\39px-ClassIcon_deathknightFOND.png", UriKind.Relative)));
                        txtboxConsole.AppendText(j.Nom + " a choisi le chevalier de la mort." + "\n");
                        listeVisibility(btnLanceDes, lblArgent, lblArgentJoueur, btnListe1, btnListe2, btnListe3, btnListe4, lblPion);
                        j.finTour(listeJoueurs, nbrJoueurs, lblNomJoueur, lblArgentJoueur, imgSortie);
                        btnDk.Visibility = Visibility.Hidden;
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Evénement lors du clic sur btnMage
        /// </summary>
        public void clicbtnMage(Rectangle pion1, Rectangle pion2, TextBox txtboxConsole, Button btnMage, Label lblPion, Button btnLanceDes, 
            Label lblNomJoueur, Label lblArgent, Label lblArgentJoueur, Button btnListe1, Button btnListe2, Button btnListe3,
            Button btnListe4, Image imgSortie)
        {
            foreach (Joueur j in listeJoueurs)
            {
                if (j.sonTour == true)
                {
                    //TODOCORENTIN Fonctionne pour 2 joueurs uniquement
                    if (j.Numero == 1 && j.sonTour == true)
                    {
                        pion1.Fill = new ImageBrush(new BitmapImage(new Uri(@"..\..\Images\39px-ClassIcon_mageFOND.png", UriKind.Relative)));
                        txtboxConsole.AppendText(j.Nom + " a choisi le mage." + "\n");
                        txtboxConsole.AppendText("Le joueur 2 choisit son pion : " + "\n");
                        j.finTour(listeJoueurs, nbrJoueurs, lblNomJoueur, lblArgentJoueur, imgSortie);
                        btnMage.Visibility = Visibility.Hidden;
                        break;
                    }
                    else if (j.Numero == 2 && j.sonTour == true)
                    {
                        pion2.Fill = new ImageBrush(new BitmapImage(new Uri(@"..\..\Images\39px-ClassIcon_mageFOND.png", UriKind.Relative)));
                        txtboxConsole.AppendText(j.Nom + " a choisi le mage." + "\n");
                        listeVisibility(btnLanceDes, lblArgent, lblArgentJoueur, btnListe1, btnListe2, btnListe3, btnListe4, lblPion);
                        j.finTour(listeJoueurs, nbrJoueurs, lblNomJoueur, lblArgentJoueur, imgSortie);
                        btnMage.Visibility = Visibility.Hidden;
                        break;
                    }
                }
            }
        }
        #endregion
    }
}
