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

        /// <summary>
        /// Liste des cartes chance (tampon)
        /// </summary>
        public List<Carte> listeChanceTampon = new List<Carte>();

        /// <summary>
        /// Liste des cartes caisse de communauté (tampon)
        /// </summary>
        public List<Carte> listeCaisseTampon = new List<Carte>();

        /// <summary>
        /// Liste des cases du plateau
        /// </summary>
        public List<Case> listeCases;

        Des Des = new Des();

        Banque banque = new Banque();

        private Window Plateau;

        public Console C;
        
        /// <summary>
        /// Nombre de joueur dans la partie, géré dans AddJoueurs
        /// </summary>
        public int nbrJoueurs { get; set; } = 2;

        int patriJoueurAff = -1;
        #endregion

        #region CONSTRUCTEURS
        public Controleur()
        {

        }

        public Controleur(Window plateau, TextBox console)
        {
            Plateau = plateau;
            C = new Console(console);
        }
        #endregion

        #region Méthodes

        public void remplirListeChanceTampon()
        {
            foreach(Carte c in listeChance)
            {
                listeChanceTampon.Add(c);
            }
        }

        public void remplirListeCaisseTampon()
        {
            foreach (Carte c in listeCaisse)
            {
                listeCaisseTampon.Add(c);
            }
        }

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
                    loyer,
                    double.Parse(node.Attributes["XJ1"].Value),
                    double.Parse(node.Attributes["YJ1"].Value),
                    double.Parse(node.Attributes["XJ2"].Value),
                    double.Parse(node.Attributes["YJ2"].Value),
                    double.Parse(node.Attributes["XJ3"].Value),
                    double.Parse(node.Attributes["YJ3"].Value),
                    double.Parse(node.Attributes["XJ4"].Value),
                    double.Parse(node.Attributes["YJ4"].Value),
                    this,
                    int.Parse(node.Attributes["hypotheque"].Value)
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
                Carte c = new Carte(
                    int.Parse(node.Attributes["id"].Value),
                    node.Attributes["type"].Value,
                    int.Parse(node.Attributes["valeur"].Value),
                    node.Attributes["contenu"].Value,
                    this
                    );

                listeChance.Add(c);
                listeChanceTampon.Add(c);
            }

            XmlDocument docu = new XmlDocument();
            docu.Load("../../XML/Caisse.xml");
            XmlNodeList nodeL = docu.SelectNodes("//Caisse");
            foreach (XmlNode node in nodeL)
            {
                Carte c = new Carte(
                    int.Parse(node.Attributes["id"].Value),
                    node.Attributes["type"].Value,
                    int.Parse(node.Attributes["valeur"].Value),
                    node.Attributes["contenu"].Value,
                    this
                    );

                listeCaisse.Add(c);
                listeCaisseTampon.Add(c);
            }
        }
       
        /// <summary>
        /// Ajoute les joueurs a la liste des joueurs
        /// </summary>
        /// <param name="joueur1"></param>
        /// <param name="joueur2"></param>
        /// <param name="joueur3"></param>
        /// <param name="joueur4"></param>
        public void AddJoueurs(string joueur1, string joueur2, string joueur3, string joueur4, int nbrJ,
            Rectangle pion1, Rectangle pion2, Rectangle pion3, Rectangle pion4, ComboBox ComboIcones1, ComboBox ComboIcones2,
            ComboBox ComboIcones3, ComboBox ComboIcones4)
        {
            nbrJoueurs = nbrJ;

            switch(nbrJ)
            {
                case (2):
                    for (int i = 1; i <= 2; i++)
                    {
                        if (i == 1)
                            listeJoueurs.Add(new Joueur(i, joueur1, 0, 1500, pion1, ComboIcones1, this));
                        if (i == 2)
                            listeJoueurs.Add(new Joueur(i, joueur2, 0, 1500, pion2, ComboIcones2, this));
                    }
                    break;
                case (3):
                    for (int i = 1; i <= 3; i++)
                    {
                        if (i == 1)
                            listeJoueurs.Add(new Joueur(i, joueur1, 0, 1500, pion1, ComboIcones1, this));
                        if (i == 2)
                            listeJoueurs.Add(new Joueur(i, joueur2, 0, 1500, pion2, ComboIcones2, this));
                        if (i == 3)
                            listeJoueurs.Add(new Joueur(i, joueur3, 0, 1500, pion3, ComboIcones3, this));
                    }
                    break;
                case (4):
                    for (int i = 1; i <= 4; i++)
                    {
                        if (i == 1)
                            listeJoueurs.Add(new Joueur(i, joueur1, 0, 1500, pion1, ComboIcones1, this));
                        if (i == 2)
                            listeJoueurs.Add(new Joueur(i, joueur2, 0, 1500, pion2, ComboIcones2, this));
                        if (i == 3)
                            listeJoueurs.Add(new Joueur(i, joueur3, 0, 1500, pion3, ComboIcones3, this));
                        if (i == 4)
                            listeJoueurs.Add(new Joueur(i, joueur4, 0, 1500, pion4, ComboIcones4, this));
                    }
                    break;
            }
        }

        /// <summary>
        /// Affiche le Pion dans le pré-menu, au choix d'une classe
        /// </summary>
        public void choixPion(ComboBox ComboIcones, Rectangle ImageIcone)
        {
            switch (ComboIcones.SelectedIndex)
            {
                //CASE DeathKnight
                case 0:
                    ImageIcone.Fill = new ImageBrush(new BitmapImage(new Uri(@"../../Images/39px-ClassIcon_deathknight.png", UriKind.Relative)));
                    break;
                //CASE DemonHunter
                case 1:
                    ImageIcone.Fill = new ImageBrush(new BitmapImage(new Uri(@"../../Images/39px-ClassIcon_demon_hunter.png", UriKind.Relative)));
                    break;
                //CASE Druid
                case 2:
                    ImageIcone.Fill = new ImageBrush(new BitmapImage(new Uri(@"../../Images/39px-ClassIcon_druid.png", UriKind.Relative)));
                    break;
                //CASE Hunter
                case 3:
                    ImageIcone.Fill = new ImageBrush(new BitmapImage(new Uri(@"../../Images/39px-ClassIcon_hunter.png", UriKind.Relative)));
                    break;
                //CASE Mage
                case 4:
                    ImageIcone.Fill = new ImageBrush(new BitmapImage(new Uri(@"../../Images/39px-ClassIcon_mage.png", UriKind.Relative)));
                    break;
                //CASE Monk
                case 5:
                    ImageIcone.Fill = new ImageBrush(new BitmapImage(new Uri(@"../../Images/39px-ClassIcon_monk.png", UriKind.Relative)));
                    break;
                //CASE Paladin
                case 6:
                    ImageIcone.Fill = new ImageBrush(new BitmapImage(new Uri(@"../../Images/39px-ClassIcon_paladin.png", UriKind.Relative)));
                    break;
                //CASE Priest
                case 7:
                    ImageIcone.Fill = new ImageBrush(new BitmapImage(new Uri(@"../../Images/39px-ClassIcon_priest.png", UriKind.Relative)));
                    break;
                //CASE Rogue
                case 8:
                    ImageIcone.Fill = new ImageBrush(new BitmapImage(new Uri(@"../../Images/39px-ClassIcon_rogue.png", UriKind.Relative)));
                    break;
                //CASE Shaman
                case 9:
                    ImageIcone.Fill = new ImageBrush(new BitmapImage(new Uri(@"../../Images/39px-ClassIcon_shaman.png", UriKind.Relative)));
                    break;
                //CASE Warlock
                case 10:
                    ImageIcone.Fill = new ImageBrush(new BitmapImage(new Uri(@"../../Images/39px-ClassIcon_warlock.png", UriKind.Relative)));
                    break;
                //CASE Warrior
                case 11:
                    ImageIcone.Fill = new ImageBrush(new BitmapImage(new Uri(@"../../Images/39px-ClassIcon_warrior.png", UriKind.Relative)));
                    break;
                default:
                    ImageIcone.Fill = new ImageBrush(new BitmapImage(new Uri(@"../../Images/vide.png", UriKind.Relative)));
                    break;
            }
        }

        /// <summary>
        /// Initialise l'application
        /// </summary>
        public void initAppli(Label lblTour, Label lblNomJoueur, Label lblPion, 
            Button btnLanceDes, Label lblArgent, Label lblArgentJoueur, Button btnListe1, Button btnListe2, 
            Button btnListe3, Button btnListe4, Label lblWin, Rectangle pionWin, Button btnFinPartie)
        {
            lblTour.Visibility = Visibility.Hidden;
            lblNomJoueur.Visibility = Visibility.Hidden;
            lblPion.Visibility = Visibility.Hidden;
            btnLanceDes.Visibility = Visibility.Hidden;
            lblArgent.Visibility = Visibility.Hidden;
            lblArgentJoueur.Visibility = Visibility.Hidden;
            btnListe1.Visibility = Visibility.Hidden;
            btnListe2.Visibility = Visibility.Hidden;
            btnListe3.Visibility = Visibility.Hidden;
            btnListe4.Visibility = Visibility.Hidden;
            pionWin.Visibility = Visibility.Hidden;
            lblWin.Visibility = Visibility.Hidden;
            btnFinPartie.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Affiche la liste de propriété du Joueur 1
        /// </summary>
        public void clicListe1(ListBox listboxBien)
        {
            Joueur j = listeJoueurs[0];
            j.afficheProp(listboxBien);
            patriJoueurAff = 0;
        }

        /// <summary>
        /// Affiche la liste de propriété du Joueur 2
        /// </summary>
        public void clicListe2(ListBox listboxBien)
        {
            Joueur j = listeJoueurs[1];
            j.afficheProp(listboxBien);
            patriJoueurAff = 1;
        }

        /// <summary>
        /// Affiche la liste de propriété du Joueur 3
        /// </summary>
        public void clicListe3(ListBox listboxBien)
        {
            Joueur j = listeJoueurs[2];
            j.afficheProp(listboxBien);
            patriJoueurAff = 2;
        }

        /// <summary>
        /// Affiche la liste de propriété du Joueur 4
        /// </summary>
        public void clicListe4(ListBox listboxBien)
        {
            Joueur j = listeJoueurs[3];
            j.afficheProp(listboxBien);
            patriJoueurAff = 3;
        }

        /// <summary>
        /// Termine la partie et ferme la fenêtre
        /// </summary>
        public void clicFinPartie()
        {
            Application.Current.Shutdown();
        }

        /// <summary>
        /// Affichage de l'écran d'accueil (avant l'affichage du plateau)
        /// </summary>
        /// <param name="m">Fenêtre du plateau</param>
        /// <param name="pion1">Pion 1 sur plateau</param>
        /// <param name="pion2">Pion 2 sur plateau</param>
        /// <param name="pion3">Pion 3 sur plateau</param>
        /// <param name="pion4">Pion 4 sur plateau</param>
        public void afficheFormulaire(MainWindow m, Rectangle pion1, Rectangle pion2, Rectangle pion3, Rectangle pion4)
        {
            FormulaireJoueur Menu = new FormulaireJoueur(m, this, pion1, pion2, pion3, pion4);

            m.Visibility = Visibility.Hidden;
            Menu.Show();
        }
        
        /// <summary>
        /// Evénement lors du clic sur btnTour
        /// </summary>
        public void clicbtnTour(Button btnTour, Label lblTour, Label lblNomJoueur, Label lblPion, 
            Label lblArgentJoueur, Button btnListe1, Button btnListe2, Button btnListe3, Button btnListe4, Image imgSortie, 
            Rectangle pion1, Rectangle pion2, Rectangle pion3, Rectangle pion4, Button btnLanceDes, Label lblArgent, System.Windows.Controls.Button btnFinPartie,
            Rectangle pionWin, Label lblWin)
        {
            //Initialisation des Joueurs et des Propriétés
            initPropriete();
            initCarte();

            int i = 1;
            List<Joueur> listeJoueursTampon = new List<Joueur>();
            listeJoueursTampon = listeJoueurs;
            Dictionary<Joueur, int> mapJoueurs = new Dictionary<Joueur, int>();

            foreach (Joueur j in listeJoueursTampon)
            {
                mapJoueurs.Add(j, Des.Lancer());
                C.ResultatLance(j.Nom, Des.Resultat);
            }

            var sortedMap = from entry in mapJoueurs orderby entry.Value descending select entry;

            foreach (KeyValuePair<Joueur, int> entry in sortedMap)
            {
                entry.Key.Numero = i;
                i++;

                C.OrdreJoueurs(entry.Key.Nom, entry.Key.Numero);
            }

            foreach(Joueur j in listeJoueurs)
            {
                if(j.Numero == 1)
                    j.changeTour(listeJoueurs, 0, lblNomJoueur, lblArgentJoueur, imgSortie, this, btnLanceDes, btnFinPartie, pionWin, lblWin, 
                        lblPion, btnListe1, btnListe2);
            }

            foreach(Joueur j in listeJoueurs)
            {
                if (j.Numero == 1)
                {
                    j.Pion = pion1;
                    j.affichePion(j.NumClasse);
                }
                else if (j.Numero == 2)
                {
                    j.Pion = pion2;
                    j.affichePion(j.NumClasse);
                }
                else if (j.Numero == 3)
                {
                    j.Pion = pion3;
                    j.affichePion(j.NumClasse);
                }
                else if (j.Numero == 4)
                {
                    j.Pion = pion4;
                    j.affichePion(j.NumClasse);
                }
            }

            listeVisibility(btnLanceDes, lblArgent, lblArgentJoueur, btnListe1, btnListe2, btnListe3, btnListe4, lblPion, btnTour, lblTour,
                lblNomJoueur);
            nomBtnListe(listeJoueurs, btnListe1, btnListe2, btnListe3, btnListe4);
            C.SautLigne();
        }

        /// <summary>
        /// Nom des boutonsListe et rend visible certain control
        /// </summary>
        public void listeVisibility(Button btnLanceDes, Label lblArgent, Label lblArgentJoueur, Button btnListe1, Button btnListe2
            , Button btnListe3, Button btnListe4, Label lblPion, Button btnTour, Label lblTour, Label lblNomJoueur)
        {
            btnLanceDes.Visibility = Visibility.Visible;
            lblArgent.Visibility = Visibility.Visible;
            lblPion.Visibility = Visibility.Visible;
            lblArgentJoueur.Visibility = Visibility.Visible;
            btnTour.Visibility = Visibility.Hidden;
            lblTour.Visibility = Visibility.Visible;
            lblNomJoueur.Visibility = Visibility.Visible;
            if (nbrJoueurs >= 1)
            {
                btnListe1.Visibility = Visibility.Visible;
                btnListe2.Visibility = Visibility.Hidden;
                btnListe3.Visibility = Visibility.Hidden;
                btnListe4.Visibility = Visibility.Hidden;
            }
            if (nbrJoueurs >= 2)
            {
                btnListe1.Visibility = Visibility.Visible;
                btnListe2.Visibility = Visibility.Visible;
                btnListe3.Visibility = Visibility.Hidden;
                btnListe4.Visibility = Visibility.Hidden;
            }
            if (nbrJoueurs >= 3)
            {
                btnListe1.Visibility = Visibility.Visible;
                btnListe2.Visibility = Visibility.Visible;
                btnListe3.Visibility = Visibility.Visible;
                btnListe4.Visibility = Visibility.Hidden;
            }
            if (nbrJoueurs >= 4)
            {
                btnListe1.Visibility = Visibility.Visible;
                btnListe2.Visibility = Visibility.Visible;
                btnListe3.Visibility = Visibility.Visible;
                btnListe4.Visibility = Visibility.Visible;
            }
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
                if(j.Numero == 1)
                    btnListe1.Content = "Liste de " + jo.Nom;
                if (j.Numero == 2)
                    btnListe2.Content = "Liste de " + jo.Nom;
                if (j.Numero == 3)
                    btnListe3.Content = "Liste de " + jo.Nom;
                if (j.Numero == 4)
                    btnListe4.Content = "Liste de " + jo.Nom;
            }
        }

        /// <summary>
        /// Evénement lors du clic sur le btnLanceDes
        /// </summary>
        /// <param name="txtboxConsole"></param>
        public void clicBtnLanceDes(Rectangle pion1, Rectangle pion2, Label lblNomJoueur, 
            Label lblArgentJoueur, List<Case> lCases, Image imgSortie, Button btnListe1, Button btnListe2, Button btnListe3, Button btnListe4, Button btnLanceDes,
            Label lblArgent, Label lblPion, Button btnTour, Label lblTour, Button btnFinPartie, Rectangle pionWin, Label lblWin)
        {
            this.listeCases = lCases;
            int resultat = 0;
            int position = 0;

            listeVisibility(btnLanceDes, lblArgent, lblArgentJoueur, btnListe1, btnListe2, btnListe3, btnListe4, lblPion, btnTour, lblTour, lblNomJoueur);
            nomBtnListe(listeJoueurs, btnListe1, btnListe2, btnListe3, btnListe4);

            foreach (Joueur j in listeJoueurs)
            {
                if(j.sonTour == true)
                {
                    Des.Lancer();
                    resultat = Des.Resultat;

                    //Affichage à la suite du résultat du lancé et affiche si le lanceur fait un doublé
                    C.AfficheDe(Des.Premier, Des.Deuxieme);
                    if (!j.EstEnPrison)
                        C.JoueurAvance(j.Nom, resultat);

                    if (Des.EstDouble() && j.EstEnPrison)
                    {
                        C.SortieChampBataille(j.Nom, true, false, false);
                        C.JoueurAvance(j.Nom, resultat);
                        j.estDouble = true;
                        j.nbrDouble++;
                    }
                    else if(Des.EstDouble())
                    {
                        C.Double();
                        j.estDouble = true;
                        j.nbrDouble++;
                    }
                    else if(j.EstEnPrison)
                    {
                        C.TenteDouble();
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
                                C.SortieChampBataille(j.Nom, false, true, false);
                                C.JoueurAvance(j.Nom, resultat);
                                j.estDouble = true;
                                j.nbrDouble++;
                                j.Sortie--;
                            }
                            else if (dialogResult == System.Windows.Forms.DialogResult.No)
                            {
                                C.ResterChampBataille(j.Nom);
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
                                C.SortieChampBataille(j.Nom, false, false, true);
                                C.JoueurAvance(j.Nom, resultat);
                                j.estDouble = true;
                                j.nbrDouble++;
                                j.Argent -= 50;
                            }
                            else if (dialogResult == System.Windows.Forms.DialogResult.No)
                            {
                                C.ResterChampBataille(j.Nom);
                                resultat = 0;
                            }
                        }
                    }
                    else
                    {
                        j.estDouble = false;
                        j.nbrDouble = 0;
                    }

                    j.Position = Move(position, j, resultat);
                    position = j.Position;
                    j.Placement(position, j, pion1, pion2, listePropriete, lCases, listeChance, imgSortie, listeCaisse);

                    lblArgentJoueur.Content = j.Argent;

                    if (j.estDouble)
                        break;
                    else
                    {
                        j.finTour(listeJoueurs, nbrJoueurs, lblNomJoueur, lblArgentJoueur, imgSortie, this, btnLanceDes, btnFinPartie, pionWin, lblWin, 
                            lblPion, btnListe1, btnListe2);
                        break;
                    }
                }
            }
            C.SautLigne();
        }

        /// <summary>
        /// Change la position en fonction de plusieurs facteurs
        /// </summary>
        /// <param name="position"></param>
        public int Move(int position, Joueur j, int resultat)
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
                C.TripleDouble(j.Nom);
                position = 40;
                j.EstEnPrison = true;
                j.nbrDouble = 0;
                j.estDouble = false;
            }
            else if(position > 39 && j.EstEnPrison == false)
            {
                C.Gain(j.Nom, 200);
                position -= 40;
                j.Argent += 200;
            }

            return position;
        }

        public void afficheAppartenance(List<Case> aAfficher, List<Case> surPlateau)
        {
            surPlateau = aAfficher;
        }

        /// <summary>
        /// Lance la procedure d'opération sur une propriété
        /// </summary>
        /// <param name="propriete">Propriété selectionnée dans la listBox</param>
        public void debuterOperation(object propriete)
        {
            Joueur proprietaire = listeJoueurs[patriJoueurAff];
            Propriete AOperer = new Propriete();
            foreach (Propriete prop in proprietaire.Patrimoine)
            {
                if(prop.Nom == propriete.ToString())
                {
                    AOperer = prop;
                }
            }
            banque.initOperation(AOperer, proprietaire, listeJoueurs, this);
            //banque.initVendPropriete(AOperer, proprietaire, listeJoueurs, this);
        }

        /// <summary>
        /// Verifie si un objet fait bien référence à une propriété
        /// </summary>
        /// <param name="aVerifier">Objet à vérifier</param>
        /// <returns></returns>
        public bool CheckPropriete(object aVerifier)
        {
            bool resultat = false;
            foreach (Propriete prop in listePropriete)
            {
                if (aVerifier != null)
                {
                    if (prop.Nom == aVerifier.ToString())
                        resultat = true;
                }
            }

            return resultat;
        }

        /// <summary>
        /// Verrouille ou dévérouille la fenêtre du plateau
        /// </summary>
        public void SwitchVerrouFenetre()
        {
            if (Plateau.IsEnabled == true)
                Plateau.IsEnabled = false;
            else Plateau.IsEnabled = true;
        }
        #endregion
    }
}
