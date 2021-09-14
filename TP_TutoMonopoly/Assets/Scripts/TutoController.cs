using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutoController : MonoBehaviour
{
    //référence au joueurs
    public GameObject[] players;
    //référence au sprite des joueurs
    public Sprite[] playersSprites;
    //référence au dés 1
    public GameObject dice1;
    //référence au dés 2
    public GameObject dice2;
    //référence aux différents boutons
    public GameObject buttonDes;
    public GameObject buttonAcheterMaison;
    public GameObject buttonVendreMaison;
    public GameObject buttonHypotheque;
    public GameObject buttonRembouserHypotheque;
    public GameObject buttonEchanger;
    public GameObject buttonEnd;
    public GameObject buttonSortieDePrison;
    //référence au nom du joueur
    public GameObject nomDuJoueur;
    //référence à l'argent du joueur
    public GameObject argentDuJoueur;
    //référence au panel de dialogue
    public GameObject dialoguePanel;
    //référence à la flèche
    public GameObject arrow;
    //référence aux différents panels
    public GameObject lancerDeDes;
    public GameObject panelChance;
    public GameObject panelCommunaute;
    public GameObject panelPropriete;
    public GameObject panelLoyer;
    public GameObject panelPrix;
    public GameObject panelNom;
    public GameObject panelCouleur;
    public GameObject panelPrixMaison;
    public GameObject panelPrixHypotheque;
    public GameObject panelEchange;
    public GameObject panelPayerLoyer;
    public GameObject panelPayerTaxe;
    public GameObject panelPerso;
    //référence aux cases à modifier
    public GameObject case1;
    public GameObject case3;
    public GameObject case5;
    public GameObject case6;
    public GameObject case10;
    public GameObject case11;
    public GameObject case12;
    public GameObject case13;
    public GameObject case14;
    public GameObject case15;
    public GameObject case23;
    public GameObject case25;
    public GameObject case28;
    //référence à la musique
    public GameObject music;
    //référence au background
    public GameObject background;
    //référence au joueur en cours
    public GameObject currentPlayerSprite;

    //numéro du joueur actuel
    private int currentPlayer;
    //position du joueur actuel
    private int currentPosition;
    //couleur du joueur actuel
    private Color32 currentColor;
    //compteur d'action
    private int cptAction;

    // Start appeller à l'instantiation
    void Start()
    {
        //initialisation des variables
        currentPlayer = 1;
        currentPosition = players[currentPlayer - 1].GetComponent<PlayerScript>().GetPosition();
        currentColor = players[currentPlayer - 1].GetComponent<PlayerScript>().GetCouleur();
        players[currentPlayer - 1].GetComponent<PlayerScript>().SetArgent(150);
        dice1.GetComponent<Image>().color = currentColor;
        dice2.GetComponent<Image>().color = currentColor;
        argentDuJoueur.GetComponent<TextMeshProUGUI>().text = "M" + players[currentPlayer - 1].GetComponent<PlayerScript>().GetArgent().ToString();
        if (GlobalSetUp.langage == "français")
        {
            nomDuJoueur.GetComponent<TextMeshProUGUI>().text = "Joueur " + currentPlayer.ToString() + " :";
        }
        else
        {
            nomDuJoueur.GetComponent<TextMeshProUGUI>().text = "Player " + currentPlayer.ToString() + " :";
        }

        //mise en place des cases
        Color32 initCol;
        initCol = players[3].GetComponent<PlayerScript>().GetCouleur();
        case25.GetComponent<Image>().color = new Color32(initCol.r, initCol.g, initCol.b, 100);
        initCol = players[2].GetComponent<PlayerScript>().GetCouleur();
        case12.GetComponent<Image>().color = new Color32(initCol.r, initCol.g, initCol.b, 100);
        initCol = players[5].GetComponent<PlayerScript>().GetCouleur();
        case23.GetComponent<Image>().color = new Color32(initCol.r, initCol.g, initCol.b, 100);
        initCol = players[6].GetComponent<PlayerScript>().GetCouleur();
        case11.GetComponent<Image>().color = new Color32(initCol.r, initCol.g, initCol.b, 100);
        initCol = players[6].GetComponent<PlayerScript>().GetCouleur();
        case14.GetComponent<Image>().color = new Color32(initCol.r, initCol.g, initCol.b, 100);
        initCol = players[6].GetComponent<PlayerScript>().GetCouleur();
        case6.GetComponent<Image>().color = new Color32(initCol.r, initCol.g, initCol.b, 100);

        //set up de la scène en fonction du joueur
        SetPlayerSprites();
        music.GetComponent<SetUpMusic>().SetTheMusic(players[currentPlayer - 1]);
        background.GetComponent<BackgroundSetUp>().SetTheFond(players[currentPlayer - 1]);
        currentPlayerSprite.GetComponent<Image>().sprite = players[currentPlayer - 1].GetComponent<Image>().sprite;

        //si ça n'est pas un chapitre
        if (GlobalSetUp.cptDepart == 0)
        {
            //initialisation de cptAction
            cptAction = 0;
        }
        //si on lance un chapitre
        else
        {
            //désactivation du panel de dialogue
            dialoguePanel.SetActive(false);
            //initialisation de cptAction
            cptAction = GlobalSetUp.cptDepart;
            //initialisation du joueur
            if (cptAction>=13 && cptAction < 34)
            {
                currentPlayer = 2;
            }
            else if(cptAction>=34 && cptAction <44)
            {
                currentPlayer = 3;
            }
            else if(cptAction>=44 && cptAction <52)
            {
                currentPlayer = 4;
            }
            else if(cptAction>=52 && cptAction <60)
            {
                currentPlayer = 5;
            }
            else if(cptAction>=60 && cptAction <67)
            {
                currentPlayer = 6;
            }
            else if(cptAction>=60 && cptAction <77)
            {
                currentPlayer = 7;
            }
            else if (cptAction >= 77)
            {
                currentPlayer = 8;
            }
            //initialisation des cases
            Color32 tmpcol;
            if (cptAction >=24)
            {
                tmpcol= players[1].GetComponent<PlayerScript>().GetCouleur();
                case1.GetComponent<Image>().color = new Color32(tmpcol.r, tmpcol.g, tmpcol.b, 100);
            }
            if (cptAction >=28)
            {
                tmpcol = players[1].GetComponent<PlayerScript>().GetCouleur();
                case3.GetComponent<Image>().color = new Color32(tmpcol.r, tmpcol.g, tmpcol.b, 100);
            }
            if (cptAction >=38)
            {
                tmpcol = players[2].GetComponent<PlayerScript>().GetCouleur();
                case5.GetComponent<Image>().color = new Color32(tmpcol.r, tmpcol.g, tmpcol.b, 100);
            }
            if (cptAction>=42)
            {
                tmpcol = players[2].GetComponent<PlayerScript>().GetCouleur();
                case15.GetComponent<Image>().color = new Color32(tmpcol.r, tmpcol.g, tmpcol.b, 100);
            }
            if (cptAction >=48)
            {
                tmpcol = players[3].GetComponent<PlayerScript>().GetCouleur();
                case28.GetComponent<Image>().color = new Color32(tmpcol.r, tmpcol.g, tmpcol.b, 100);
            }
            if (cptAction >=50)
            {
                tmpcol = players[3].GetComponent<PlayerScript>().GetCouleur();
                case12.GetComponent<Image>().color = new Color32(tmpcol.r, tmpcol.g, tmpcol.b, 100);
                tmpcol = players[2].GetComponent<PlayerScript>().GetCouleur();
                case25.GetComponent<Image>().color = new Color32(tmpcol.r, tmpcol.g, tmpcol.b, 100);
            }
            if (cptAction >=73)
            {
                tmpcol = players[6].GetComponent<PlayerScript>().GetCouleur();
                case13.GetComponent<Image>().color = new Color32(tmpcol.r, tmpcol.g, tmpcol.b, 100);
            }
            //initialisaiton de la position des joueurs
            if (cptAction == 1)
            {
                players[currentPlayer - 1].GetComponent<PlayerScript>().TP(7);
            }
            else if (cptAction==5 || cptAction==7)
            {
                players[currentPlayer - 1].GetComponent<PlayerScript>().TP(17);
            }
            else if (cptAction ==15)
            {
                players[currentPlayer - 1].GetComponent<PlayerScript>().TP(1);
            }
            else if (cptAction ==26 || cptAction==30)
            {
                players[currentPlayer - 1].GetComponent<PlayerScript>().TP(3);
            }
            else if (cptAction ==36)
            {
                players[currentPlayer - 1].GetComponent<PlayerScript>().TP(5);
            }
            else if (cptAction == 46 || cptAction == 48)
            {
                players[currentPlayer - 1].GetComponent<PlayerScript>().TP(28);
            }
            else if (cptAction == 58)
            {
                players[currentPlayer - 1].GetComponent<PlayerScript>().TP(20);
            }
            else if (cptAction == 62)
            {
                players[currentPlayer - 1].GetComponent<PlayerScript>().TP(38);
            }
            else if (cptAction == 71 || cptAction==73)
            {
                players[currentPlayer - 1].GetComponent<PlayerScript>().TP(13);
            }
            //initialisation des varibales
            players[currentPlayer - 1].GetComponent<PlayerScript>().SetArgent(GlobalSetUp.argentDuJoueur);
            argentDuJoueur.GetComponent<TextMeshProUGUI>().text = "M" + players[currentPlayer - 1].GetComponent<PlayerScript>().GetArgent().ToString();
            currentPosition = players[currentPlayer - 1].GetComponent<PlayerScript>().GetPosition();
            currentColor = players[currentPlayer - 1].GetComponent<PlayerScript>().GetCouleur();
            dice1.GetComponent<Image>().color = currentColor;
            dice2.GetComponent<Image>().color = currentColor;
            currentPlayerSprite.GetComponent<Image>().sprite = players[currentPlayer - 1].GetComponent<Image>().sprite;
            music.GetComponent<SetUpMusic>().SetTheMusic(players[currentPlayer - 1]);
            background.GetComponent<BackgroundSetUp>().SetTheFond(players[currentPlayer - 1]);
            //lancement de la première action du chapitre
            Action();
        }
       
    }

    //fonction permettant de setter les sprites des joueurs
    private void SetPlayerSprites()
    {
        switch (ListeDesJoueursEtCouleur.couleurJ1)
        {
            case "blanc":
                players[0].GetComponent<Image>().sprite = playersSprites[0];
                break;
            case "bleu":
                players[0].GetComponent<Image>().sprite = playersSprites[1];
                break;
            case "gris":
                players[0].GetComponent<Image>().sprite = playersSprites[2];
                break;
            case "marron":
                players[0].GetComponent<Image>().sprite = playersSprites[3];
                break;
            case "orange":
                players[0].GetComponent<Image>().sprite = playersSprites[4];
                break;
            case "rouge":
                players[0].GetComponent<Image>().sprite = playersSprites[5];
                break;
            case "vert":
                players[0].GetComponent<Image>().sprite = playersSprites[6];
                break;
            case "violet":
                players[0].GetComponent<Image>().sprite = playersSprites[7];
                break;
        }
        switch (ListeDesJoueursEtCouleur.couleurJ2)
        {
            case "blanc":
                players[1].GetComponent<Image>().sprite = playersSprites[0];
                break;
            case "bleu":
                players[1].GetComponent<Image>().sprite = playersSprites[1];
                break;
            case "gris":
                players[1].GetComponent<Image>().sprite = playersSprites[2];
                break;
            case "marron":
                players[1].GetComponent<Image>().sprite = playersSprites[3];
                break;
            case "orange":
                players[1].GetComponent<Image>().sprite = playersSprites[4];
                break;
            case "rouge":
                players[1].GetComponent<Image>().sprite = playersSprites[5];
                break;
            case "vert":
                players[1].GetComponent<Image>().sprite = playersSprites[6];
                break;
            case "violet":
                players[1].GetComponent<Image>().sprite = playersSprites[7];
                break;
        }
        switch (ListeDesJoueursEtCouleur.couleurJ3)
        {
            case "blanc":
                players[2].GetComponent<Image>().sprite = playersSprites[0];
                break;
            case "bleu":
                players[2].GetComponent<Image>().sprite = playersSprites[1];
                break;
            case "gris":
                players[2].GetComponent<Image>().sprite = playersSprites[2];
                break;
            case "marron":
                players[2].GetComponent<Image>().sprite = playersSprites[3];
                break;
            case "orange":
                players[2].GetComponent<Image>().sprite = playersSprites[4];
                break;
            case "rouge":
                players[2].GetComponent<Image>().sprite = playersSprites[5];
                break;
            case "vert":
                players[2].GetComponent<Image>().sprite = playersSprites[6];
                break;
            case "violet":
                players[2].GetComponent<Image>().sprite = playersSprites[7];
                break;
        }
        switch (ListeDesJoueursEtCouleur.couleurJ4)
        {
            case "blanc":
                players[3].GetComponent<Image>().sprite = playersSprites[0];
                break;
            case "bleu":
                players[3].GetComponent<Image>().sprite = playersSprites[1];
                break;
            case "gris":
                players[3].GetComponent<Image>().sprite = playersSprites[2];
                break;
            case "marron":
                players[3].GetComponent<Image>().sprite = playersSprites[3];
                break;
            case "orange":
                players[3].GetComponent<Image>().sprite = playersSprites[4];
                break;
            case "rouge":
                players[3].GetComponent<Image>().sprite = playersSprites[5];
                break;
            case "vert":
                players[3].GetComponent<Image>().sprite = playersSprites[6];
                break;
            case "violet":
                players[3].GetComponent<Image>().sprite = playersSprites[7];
                break;
        }
        switch (ListeDesJoueursEtCouleur.couleurJ5)
        {
            case "blanc":
                players[4].GetComponent<Image>().sprite = playersSprites[0];
                break;
            case "bleu":
                players[4].GetComponent<Image>().sprite = playersSprites[1];
                break;
            case "gris":
                players[4].GetComponent<Image>().sprite = playersSprites[2];
                break;
            case "marron":
                players[4].GetComponent<Image>().sprite = playersSprites[3];
                break;
            case "orange":
                players[4].GetComponent<Image>().sprite = playersSprites[4];
                break;
            case "rouge":
                players[4].GetComponent<Image>().sprite = playersSprites[5];
                break;
            case "vert":
                players[4].GetComponent<Image>().sprite = playersSprites[6];
                break;
            case "violet":
                players[4].GetComponent<Image>().sprite = playersSprites[7];
                break;
        }
        switch (ListeDesJoueursEtCouleur.couleurJ6)
        {
            case "blanc":
                players[5].GetComponent<Image>().sprite = playersSprites[0];
                break;
            case "bleu":
                players[5].GetComponent<Image>().sprite = playersSprites[1];
                break;
            case "gris":
                players[5].GetComponent<Image>().sprite = playersSprites[2];
                break;
            case "marron":
                players[5].GetComponent<Image>().sprite = playersSprites[3];
                break;
            case "orange":
                players[5].GetComponent<Image>().sprite = playersSprites[4];
                break;
            case "rouge":
                players[5].GetComponent<Image>().sprite = playersSprites[5];
                break;
            case "vert":
                players[5].GetComponent<Image>().sprite = playersSprites[6];
                break;
            case "violet":
                players[5].GetComponent<Image>().sprite = playersSprites[7];
                break;
        }
        switch (ListeDesJoueursEtCouleur.couleurJ7)
        {
            case "blanc":
                players[6].GetComponent<Image>().sprite = playersSprites[0];
                break;
            case "bleu":
                players[6].GetComponent<Image>().sprite = playersSprites[1];
                break;
            case "gris":
                players[6].GetComponent<Image>().sprite = playersSprites[2];
                break;
            case "marron":
                players[6].GetComponent<Image>().sprite = playersSprites[3];
                break;
            case "orange":
                players[6].GetComponent<Image>().sprite = playersSprites[4];
                break;
            case "rouge":
                players[6].GetComponent<Image>().sprite = playersSprites[5];
                break;
            case "vert":
                players[6].GetComponent<Image>().sprite = playersSprites[6];
                break;
            case "violet":
                players[6].GetComponent<Image>().sprite = playersSprites[7];
                break;
        }
        switch (ListeDesJoueursEtCouleur.couleurJ8)
        {
            case "blanc":
                players[7].GetComponent<Image>().sprite = playersSprites[0];
                break;
            case "bleu":
                players[7].GetComponent<Image>().sprite = playersSprites[1];
                break;
            case "gris":
                players[7].GetComponent<Image>().sprite = playersSprites[2];
                break;
            case "marron":
                players[7].GetComponent<Image>().sprite = playersSprites[3];
                break;
            case "orange":
                players[7].GetComponent<Image>().sprite = playersSprites[4];
                break;
            case "rouge":
                players[7].GetComponent<Image>().sprite = playersSprites[5];
                break;
            case "vert":
                players[7].GetComponent<Image>().sprite = playersSprites[6];
                break;
            case "violet":
                players[7].GetComponent<Image>().sprite = playersSprites[7];
                break;
        }
    }

    //fonction permettant de passer au joueur suivant
    public void NextPlayer()
    {
        if (currentPlayer+1 <= 8)
        {
            currentPlayer++;
            currentPosition = players[currentPlayer - 1].GetComponent<PlayerScript>().GetPosition();
            currentColor = players[currentPlayer - 1].GetComponent<PlayerScript>().GetCouleur();
            dice1.GetComponent<Image>().color = currentColor;
            dice2.GetComponent<Image>().color = currentColor;
            argentDuJoueur.GetComponent<TextMeshProUGUI>().text = "M" + players[currentPlayer - 1].GetComponent<PlayerScript>().GetArgent().ToString();
            if (GlobalSetUp.langage == "français")
            {
                nomDuJoueur.GetComponent<TextMeshProUGUI>().text = "Joueur " + currentPlayer.ToString() + " :";
            }
            else
            {
                nomDuJoueur.GetComponent<TextMeshProUGUI>().text = "Player " + currentPlayer.ToString() + " :";
            }
            currentPlayerSprite.GetComponent<Image>().sprite = players[currentPlayer - 1].GetComponent<Image>().sprite;
            Action();
        }
        else
        {
            currentPlayer = 1;
            currentPosition = players[currentPlayer - 1].GetComponent<PlayerScript>().GetPosition();
            currentColor = players[currentPlayer - 1].GetComponent<PlayerScript>().GetCouleur();
            dice1.GetComponent<Image>().color = currentColor;
            dice2.GetComponent<Image>().color = currentColor;
            argentDuJoueur.GetComponent<TextMeshProUGUI>().text = "M" + players[currentPlayer - 1].GetComponent<PlayerScript>().GetArgent().ToString();
            if (GlobalSetUp.langage == "français")
            {
                nomDuJoueur.GetComponent<TextMeshProUGUI>().text = "Joueur " + currentPlayer.ToString() + " :";
            }
            else
            {
                nomDuJoueur.GetComponent<TextMeshProUGUI>().text = "Player " + currentPlayer.ToString() + " :";
            }
            currentPlayerSprite.GetComponent<Image>().sprite = players[currentPlayer - 1].GetComponent<Image>().sprite;
            Action();
        }        
    }

    //fonction permettant de gérer les actions de la scène
    public void Action()
    {
        switch (cptAction)
        {
            case 0:
                //permier lancer de dés
                dialoguePanel.SetActive(false);
                buttonAcheterMaison.SetActive(false);
                buttonVendreMaison.SetActive(false);
                buttonHypotheque.SetActive(false);
                buttonRembouserHypotheque.SetActive(false);
                buttonEchanger.SetActive(false);
                buttonEnd.SetActive(false);
                panelPerso.SetActive(true);
                panelPerso.GetComponent<SetUpPanelPerso>().SetUpPerso(players[currentPlayer - 1]);
                arrow.GetComponent<RectTransform>().position = new Vector2(buttonDes.GetComponent<RectTransform>().position.x + (buttonDes.GetComponent<RectTransform>().rect.width / 2) + (arrow.GetComponent<ArrowFocus>().GetWitdhMax() / 2), buttonDes.GetComponent<RectTransform>().position.y);
                lancerDeDes.GetComponent<JetDeDesTuto>().SetScoreDesire(4, 2, 2);
                lancerDeDes.GetComponent<JetDeDesTuto>().SetPlayerToMove(players[currentPlayer - 1]);
                break;
            case 1:
                //affichage dialogue case chance
                arrow.SetActive(false);
                buttonAcheterMaison.SetActive(true);
                buttonVendreMaison.SetActive(true);
                buttonHypotheque.SetActive(true);
                buttonRembouserHypotheque.SetActive(true);
                buttonEchanger.SetActive(true);
                buttonEnd.SetActive(true);
                dialoguePanel.SetActive(true);
                break;
            case 2:
                //affichage carte chance
                dialoguePanel.SetActive(false);
                panelChance.SetActive(true);
                arrow.SetActive(true);
                break;
            case 3:
                //affichage dialogue sortie de prison
                panelChance.SetActive(false);
                arrow.SetActive(false);
                buttonSortieDePrison.SetActive(true);
                dialoguePanel.SetActive(true);
                break;
            case 4:
                //affichage lancer de des carte commu
                dialoguePanel.SetActive(false);
                buttonAcheterMaison.SetActive(false);
                buttonVendreMaison.SetActive(false);
                buttonHypotheque.SetActive(false);
                buttonRembouserHypotheque.SetActive(false);
                buttonEchanger.SetActive(false);
                buttonEnd.SetActive(false);
                buttonSortieDePrison.SetActive(false);
                arrow.GetComponent<RectTransform>().position = new Vector2(buttonDes.GetComponent<RectTransform>().position.x + (buttonDes.GetComponent<RectTransform>().rect.width/2) + (arrow.GetComponent<ArrowFocus>().GetWitdhMax()/2), buttonDes.GetComponent<RectTransform>().position.y);
                arrow.SetActive(true);
                lancerDeDes.GetComponent<JetDeDesTuto>().SetScoreDesire(10, 5, 5);
                lancerDeDes.GetComponent<JetDeDesTuto>().SetPlayerToMove(players[currentPlayer - 1]);
                break;
            case 5:
                //affichage explication commu
                arrow.SetActive(false);
                buttonAcheterMaison.SetActive(true);
                buttonVendreMaison.SetActive(true);
                buttonHypotheque.SetActive(true);
                buttonRembouserHypotheque.SetActive(true);
                buttonEchanger.SetActive(true);
                buttonEnd.SetActive(true);
                buttonSortieDePrison.SetActive(true);
                dialoguePanel.SetActive(true);
                break;
            case 6:
                //affichage carte de communauté
                dialoguePanel.SetActive(false);
                panelCommunaute.SetActive(true);
                arrow.SetActive(true);
                break;
            case 7:
                //payage de la commu + relance de dés dialogue pour 3 doubles
                players[currentPlayer - 1].GetComponent<PlayerScript>().SetArgent(100);
                argentDuJoueur.GetComponent<TextMeshProUGUI>().text = "M" + players[currentPlayer - 1].GetComponent<PlayerScript>().GetArgent().ToString();
                panelCommunaute.SetActive(false);
                arrow.SetActive(false);
                dialoguePanel.SetActive(true);
                break;
            case 8:
                //lancer de dés pour 3 doubles
                dialoguePanel.SetActive(false);
                buttonAcheterMaison.SetActive(false);
                buttonVendreMaison.SetActive(false);
                buttonHypotheque.SetActive(false);
                buttonRembouserHypotheque.SetActive(false);
                buttonEchanger.SetActive(false);
                buttonEnd.SetActive(false);
                buttonSortieDePrison.SetActive(false);
                arrow.GetComponent<RectTransform>().position = new Vector2(buttonDes.GetComponent<RectTransform>().position.x + (buttonDes.GetComponent<RectTransform>().rect.width / 2) + (arrow.GetComponent<ArrowFocus>().GetWitdhMax() / 2), buttonDes.GetComponent<RectTransform>().position.y);
                arrow.SetActive(true);
                lancerDeDes.GetComponent<JetDeDesTuto>().SetScoreDesire(12, 6, 6);
                lancerDeDes.GetComponent<JetDeDesTuto>().SetPlayerToMove(players[currentPlayer - 1]);
                break;
            case 9:
                //affichage dialogue 3 double de dés
                arrow.SetActive(false);
                buttonAcheterMaison.SetActive(true);
                buttonVendreMaison.SetActive(true);
                buttonHypotheque.SetActive(true);
                buttonRembouserHypotheque.SetActive(true);
                buttonEchanger.SetActive(true);
                buttonEnd.SetActive(true);
                buttonSortieDePrison.SetActive(true);
                dialoguePanel.SetActive(true);
                break;
            case 10:
                //aller en prison
                dialoguePanel.SetActive(false);
                players[currentPlayer - 1].GetComponent<PlayerScript>().Move(33);
                break;
            case 11:
                //affichage dialogue fin de tour joueur 1
                dialoguePanel.SetActive(true);
                break;
            case 12:
                //fin de tour joueur 1
                dialoguePanel.SetActive(false);
                buttonAcheterMaison.SetActive(false);
                buttonVendreMaison.SetActive(false);
                buttonHypotheque.SetActive(false);
                buttonRembouserHypotheque.SetActive(false);
                buttonEchanger.SetActive(false);
                buttonDes.SetActive(false);
                buttonSortieDePrison.SetActive(false);
                arrow.GetComponent<RectTransform>().position = new Vector2(buttonEnd.GetComponent<RectTransform>().position.x + (buttonEnd.GetComponent<RectTransform>().rect.width / 2) + (arrow.GetComponent<ArrowFocus>().GetWitdhMax() / 2), buttonEnd.GetComponent<RectTransform>().position.y);
                arrow.SetActive(true);
                break;
            case 13:
                //début tour joueur 2 
                arrow.SetActive(false);
                buttonAcheterMaison.SetActive(true);
                buttonVendreMaison.SetActive(true);
                buttonHypotheque.SetActive(true);
                buttonRembouserHypotheque.SetActive(true);
                buttonEchanger.SetActive(true);
                buttonEnd.SetActive(true);
                buttonDes.SetActive(true);
                panelPerso.SetActive(true);
                panelPerso.GetComponent<SetUpPanelPerso>().SetUpPerso(players[currentPlayer - 1]);
                music.GetComponent<SetUpMusic>().SetTheMusic(players[currentPlayer - 1]);
                background.GetComponent<BackgroundSetUp>().SetTheFond(players[currentPlayer - 1]);
                break;
            case 14:
                //lancer de dés joueur 2
                dialoguePanel.SetActive(false);
                buttonAcheterMaison.SetActive(false);
                buttonVendreMaison.SetActive(false);
                buttonHypotheque.SetActive(false);
                buttonRembouserHypotheque.SetActive(false);
                buttonEchanger.SetActive(false);
                buttonEnd.SetActive(false);
                arrow.GetComponent<RectTransform>().position = new Vector2(buttonDes.GetComponent<RectTransform>().position.x + (buttonDes.GetComponent<RectTransform>().rect.width / 2) + (arrow.GetComponent<ArrowFocus>().GetWitdhMax() / 2), buttonDes.GetComponent<RectTransform>().position.y);
                arrow.SetActive(true);
                lancerDeDes.GetComponent<JetDeDesTuto>().SetScoreDesire(2, 1, 1);
                lancerDeDes.GetComponent<JetDeDesTuto>().SetPlayerToMove(players[currentPlayer - 1]);
                break;
            case 15:
                //passage sur case départ + dialogue propriété
                arrow.SetActive(false);
                buttonAcheterMaison.SetActive(true);
                buttonVendreMaison.SetActive(true);
                buttonHypotheque.SetActive(true);
                buttonRembouserHypotheque.SetActive(true);
                buttonEchanger.SetActive(true);
                buttonEnd.SetActive(true);
                buttonDes.SetActive(true);
                dialoguePanel.SetActive(true);
                players[currentPlayer - 1].GetComponent<PlayerScript>().SetArgent(200);
                argentDuJoueur.GetComponent<TextMeshProUGUI>().text = "M" + players[currentPlayer - 1].GetComponent<PlayerScript>().GetArgent().ToString();
                break;
            case 16:
                //affichage panel de propriété avec loyer
                dialoguePanel.SetActive(false);
                panelPropriete.SetActive(true);
                panelPropriete.GetComponent<SetUpPropriete>().SetUp(1);
                panelLoyer.SetActive(true);
                break;
            case 17:
                //affichage de prix propriété
                panelLoyer.SetActive(false);
                panelPrix.SetActive(true);
                break;
            case 18:
                //affichage du nom de propriété
                panelPrix.SetActive(false);
                panelNom.SetActive(true);
                break;
            case 19:
                //affichage de la couleur de propriété
                panelNom.SetActive(false);
                panelCouleur.SetActive(true);
                break;
            case 20:
                //affichage du prix de maison de propriété
                panelCouleur.SetActive(false);
                panelPrixMaison.SetActive(true);
                break;
            case 21:
                //affichage de prix d'hypohèque de propriété
                panelPrixMaison.SetActive(false);
                panelPrixHypotheque.SetActive(true);
                break;
            case 22:
                //fin du tour de car propriété
                panelPrixHypotheque.SetActive(false);
                dialoguePanel.SetActive(true);
                break;
            case 23:
                //achat de propriété
                dialoguePanel.SetActive(false);
                arrow.SetActive(true);
                break;
            case 24:
                //affichage de dialogue de propriété fin + relance de dés joueur 2
                panelPropriete.SetActive(false);
                dialoguePanel.SetActive(true);
                arrow.SetActive(false);
                case1.GetComponent<Image>().color = new Color32(currentColor.r, currentColor.g, currentColor.b,100);
                players[currentPlayer - 1].GetComponent<PlayerScript>().SetArgent(140);
                argentDuJoueur.GetComponent<TextMeshProUGUI>().text = "M" + players[currentPlayer - 1].GetComponent<PlayerScript>().GetArgent().ToString();
                break;
            case 25:
                //relance de dés joueurs 2
                dialoguePanel.SetActive(false);
                buttonAcheterMaison.SetActive(false);
                buttonVendreMaison.SetActive(false);
                buttonHypotheque.SetActive(false);
                buttonRembouserHypotheque.SetActive(false);
                buttonEchanger.SetActive(false);
                buttonEnd.SetActive(false);
                arrow.GetComponent<RectTransform>().position = new Vector2(buttonDes.GetComponent<RectTransform>().position.x + (buttonDes.GetComponent<RectTransform>().rect.width / 2) + (arrow.GetComponent<ArrowFocus>().GetWitdhMax() / 2), buttonDes.GetComponent<RectTransform>().position.y);
                arrow.SetActive(true);
                lancerDeDes.GetComponent<JetDeDesTuto>().SetScoreDesire(2, 1, 1);
                lancerDeDes.GetComponent<JetDeDesTuto>().SetPlayerToMove(players[currentPlayer - 1]);
                break;
            case 26:
                //dialogue deuxième prop marron
                arrow.SetActive(false);
                buttonAcheterMaison.SetActive(true);
                buttonVendreMaison.SetActive(true);
                buttonHypotheque.SetActive(true);
                buttonRembouserHypotheque.SetActive(true);
                buttonEchanger.SetActive(true);
                buttonEnd.SetActive(true);
                buttonDes.SetActive(true);
                dialoguePanel.SetActive(true);
                break;
            case 27:
                //achat 2ième prop marron
                dialoguePanel.SetActive(false);
                panelPropriete.SetActive(true);
                panelPropriete.GetComponent<SetUpPropriete>().SetUp(2);
                arrow.SetActive(true);
                break;
            case 28:
                //dialogue de construction de maison
                panelPropriete.SetActive(false);
                arrow.SetActive(false);
                dialoguePanel.SetActive(true);
                case3.GetComponent<Image>().color = new Color32(currentColor.r, currentColor.g, currentColor.b, 100);
                players[currentPlayer - 1].GetComponent<PlayerScript>().SetArgent(80);
                argentDuJoueur.GetComponent<TextMeshProUGUI>().text = "M" + players[currentPlayer - 1].GetComponent<PlayerScript>().GetArgent().ToString();
                break;
            case 29:
                //achat de maison
                dialoguePanel.SetActive(false);
                buttonDes.SetActive(false);
                buttonVendreMaison.SetActive(false);
                buttonHypotheque.SetActive(false);
                buttonRembouserHypotheque.SetActive(false);
                buttonEchanger.SetActive(false);
                buttonEnd.SetActive(false);
                arrow.GetComponent<RectTransform>().position = new Vector2(buttonAcheterMaison.GetComponent<RectTransform>().position.x + (buttonAcheterMaison.GetComponent<RectTransform>().rect.width / 2) + (arrow.GetComponent<ArrowFocus>().GetWitdhMax() / 2), buttonAcheterMaison.GetComponent<RectTransform>().position.y);
                arrow.SetActive(true);
                break;
            case 30:
                //achat de maison dialogue fin + relance de dés joueur 2
                arrow.SetActive(false);
                buttonAcheterMaison.SetActive(true);
                buttonVendreMaison.SetActive(true);
                buttonHypotheque.SetActive(true);
                buttonRembouserHypotheque.SetActive(true);
                buttonEchanger.SetActive(true);
                buttonEnd.SetActive(true);
                buttonDes.SetActive(true);
                dialoguePanel.SetActive(true);
                players[currentPlayer - 1].GetComponent<PlayerScript>().SetArgent(30);
                argentDuJoueur.GetComponent<TextMeshProUGUI>().text = "M" + players[currentPlayer - 1].GetComponent<PlayerScript>().GetArgent().ToString();
                break;
            case 31:
                //relance de dés joueur 2
                dialoguePanel.SetActive(false);
                buttonAcheterMaison.SetActive(false);
                buttonVendreMaison.SetActive(false);
                buttonHypotheque.SetActive(false);
                buttonRembouserHypotheque.SetActive(false);
                buttonEchanger.SetActive(false);
                buttonEnd.SetActive(false);
                arrow.GetComponent<RectTransform>().position = new Vector2(buttonDes.GetComponent<RectTransform>().position.x + (buttonDes.GetComponent<RectTransform>().rect.width / 2) + (arrow.GetComponent<ArrowFocus>().GetWitdhMax() / 2), buttonDes.GetComponent<RectTransform>().position.y);
                arrow.SetActive(true);
                lancerDeDes.GetComponent<JetDeDesTuto>().SetScoreDesire(7, 0, 0);
                lancerDeDes.GetComponent<JetDeDesTuto>().SetPlayerToMove(players[currentPlayer - 1]);
                break;
            case 32:
                //explication case prison + fin de tour j2
                arrow.SetActive(false);
                buttonAcheterMaison.SetActive(true);
                buttonVendreMaison.SetActive(true);
                buttonHypotheque.SetActive(true);
                buttonRembouserHypotheque.SetActive(true);
                buttonEchanger.SetActive(true);
                buttonEnd.SetActive(true);
                buttonDes.SetActive(true);
                dialoguePanel.SetActive(true);
                break;
            case 33:
                //fin de tour de j2
                dialoguePanel.SetActive(false);
                buttonAcheterMaison.SetActive(false);
                buttonVendreMaison.SetActive(false);
                buttonHypotheque.SetActive(false);
                buttonRembouserHypotheque.SetActive(false);
                buttonEchanger.SetActive(false);
                buttonDes.SetActive(false);
                arrow.GetComponent<RectTransform>().position = new Vector2(buttonEnd.GetComponent<RectTransform>().position.x + (buttonEnd.GetComponent<RectTransform>().rect.width / 2) + (arrow.GetComponent<ArrowFocus>().GetWitdhMax() / 2), buttonEnd.GetComponent<RectTransform>().position.y);
                arrow.SetActive(true);
                break;
            case 34:
                //début de tour de joueur 3
                arrow.SetActive(false);
                players[currentPlayer - 1].GetComponent<PlayerScript>().SetArgent(600);
                argentDuJoueur.GetComponent<TextMeshProUGUI>().text = "M" + players[currentPlayer - 1].GetComponent<PlayerScript>().GetArgent().ToString();
                buttonAcheterMaison.SetActive(true);
                buttonVendreMaison.SetActive(true);
                buttonHypotheque.SetActive(true);
                buttonRembouserHypotheque.SetActive(true);
                buttonEchanger.SetActive(true);
                buttonEnd.SetActive(true);
                buttonDes.SetActive(true);
                panelPerso.SetActive(true);
                panelPerso.GetComponent<SetUpPanelPerso>().SetUpPerso(players[currentPlayer - 1]);
                music.GetComponent<SetUpMusic>().SetTheMusic(players[currentPlayer - 1]);
                background.GetComponent<BackgroundSetUp>().SetTheFond(players[currentPlayer - 1]);
                break;
            case 35:
                //lancer de dés joueur 3
                dialoguePanel.SetActive(false);
                buttonAcheterMaison.SetActive(false);
                buttonVendreMaison.SetActive(false);
                buttonHypotheque.SetActive(false);
                buttonRembouserHypotheque.SetActive(false);
                buttonEchanger.SetActive(false);
                buttonEnd.SetActive(false);
                arrow.GetComponent<RectTransform>().position = new Vector2(buttonDes.GetComponent<RectTransform>().position.x + (buttonDes.GetComponent<RectTransform>().rect.width / 2) + (arrow.GetComponent<ArrowFocus>().GetWitdhMax() / 2), buttonDes.GetComponent<RectTransform>().position.y);
                arrow.SetActive(true);
                lancerDeDes.GetComponent<JetDeDesTuto>().SetScoreDesire(4, 2, 2);
                lancerDeDes.GetComponent<JetDeDesTuto>().SetPlayerToMove(players[currentPlayer - 1]);
                break;
            case 36:
                //achat de gare dialogue
                buttonAcheterMaison.SetActive(true);
                buttonVendreMaison.SetActive(true);
                buttonHypotheque.SetActive(true);
                buttonRembouserHypotheque.SetActive(true);
                buttonEchanger.SetActive(true);
                buttonEnd.SetActive(true);
                buttonDes.SetActive(true);
                dialoguePanel.SetActive(true);
                panelPropriete.SetActive(true);
                arrow.SetActive(false);
                panelPropriete.GetComponent<SetUpPropriete>().SetUp(25);
                break;
            case 37:
                //achat de gare
                dialoguePanel.SetActive(false);
                arrow.SetActive(true);
                break;
            case 38:
                //achat gare dialogue fin + relance de dés j3
                players[currentPlayer - 1].GetComponent<PlayerScript>().SetArgent(400);
                argentDuJoueur.GetComponent<TextMeshProUGUI>().text = "M" + players[currentPlayer - 1].GetComponent<PlayerScript>().GetArgent().ToString();
                case5.GetComponent<Image>().color = new Color32(currentColor.r, currentColor.g, currentColor.b, 100);
                dialoguePanel.SetActive(true);
                panelPropriete.SetActive(false);
                arrow.SetActive(false);
                break;
            case 39:
                //relance de dés j3
                dialoguePanel.SetActive(false);
                buttonAcheterMaison.SetActive(false);
                buttonVendreMaison.SetActive(false);
                buttonHypotheque.SetActive(false);
                buttonRembouserHypotheque.SetActive(false);
                buttonEchanger.SetActive(false);
                buttonEnd.SetActive(false);
                arrow.GetComponent<RectTransform>().position = new Vector2(buttonDes.GetComponent<RectTransform>().position.x + (buttonDes.GetComponent<RectTransform>().rect.width / 2) + (arrow.GetComponent<ArrowFocus>().GetWitdhMax() / 2), buttonDes.GetComponent<RectTransform>().position.y);
                arrow.SetActive(true);
                lancerDeDes.GetComponent<JetDeDesTuto>().SetScoreDesire(10, 6, 4);
                lancerDeDes.GetComponent<JetDeDesTuto>().SetPlayerToMove(players[currentPlayer - 1]);
                break;
            case 40:
                //achat gare 2 dialogue
                buttonAcheterMaison.SetActive(true);
                buttonVendreMaison.SetActive(true);
                buttonHypotheque.SetActive(true);
                buttonRembouserHypotheque.SetActive(true);
                buttonEchanger.SetActive(true);
                buttonEnd.SetActive(true);
                buttonDes.SetActive(true);
                dialoguePanel.SetActive(true);
                panelPropriete.SetActive(true);
                arrow.SetActive(false);
                panelPropriete.GetComponent<SetUpPropriete>().SetUp(26);
                break;
            case 41:
                //achat gare 2
                dialoguePanel.SetActive(false);
                arrow.SetActive(true);
                break;
            case 42:
                //fin tour j3 dialogue
                players[currentPlayer - 1].GetComponent<PlayerScript>().SetArgent(200);
                argentDuJoueur.GetComponent<TextMeshProUGUI>().text = "M" + players[currentPlayer - 1].GetComponent<PlayerScript>().GetArgent().ToString();
                case15.GetComponent<Image>().color = new Color32(currentColor.r, currentColor.g, currentColor.b, 100);
                dialoguePanel.SetActive(true);
                panelPropriete.SetActive(false);
                arrow.SetActive(false);
                break;
            case 43:
                //fin tour j3
                dialoguePanel.SetActive(false);
                buttonAcheterMaison.SetActive(false);
                buttonVendreMaison.SetActive(false);
                buttonHypotheque.SetActive(false);
                buttonRembouserHypotheque.SetActive(false);
                buttonEchanger.SetActive(false);
                buttonDes.SetActive(false);
                arrow.GetComponent<RectTransform>().position = new Vector2(buttonEnd.GetComponent<RectTransform>().position.x + (buttonEnd.GetComponent<RectTransform>().rect.width / 2) + (arrow.GetComponent<ArrowFocus>().GetWitdhMax() / 2), buttonEnd.GetComponent<RectTransform>().position.y);
                arrow.SetActive(true);
                break;
            case 44:
                //début tour j4 + lancer de dés
                arrow.SetActive(false);
                players[currentPlayer - 1].GetComponent<PlayerScript>().SetArgent(200);
                argentDuJoueur.GetComponent<TextMeshProUGUI>().text = "M" + players[currentPlayer - 1].GetComponent<PlayerScript>().GetArgent().ToString();
                buttonAcheterMaison.SetActive(true);
                buttonVendreMaison.SetActive(true);
                buttonHypotheque.SetActive(true);
                buttonRembouserHypotheque.SetActive(true);
                buttonEchanger.SetActive(true);
                buttonEnd.SetActive(true);
                buttonDes.SetActive(true);
                panelPerso.SetActive(true);
                panelPerso.GetComponent<SetUpPanelPerso>().SetUpPerso(players[currentPlayer - 1]);
                music.GetComponent<SetUpMusic>().SetTheMusic(players[currentPlayer - 1]);
                background.GetComponent<BackgroundSetUp>().SetTheFond(players[currentPlayer - 1]);
                break;
            case 45:
                //lancer de dés j4
                dialoguePanel.SetActive(false);
                buttonAcheterMaison.SetActive(false);
                buttonVendreMaison.SetActive(false);
                buttonHypotheque.SetActive(false);
                buttonRembouserHypotheque.SetActive(false);
                buttonEchanger.SetActive(false);
                buttonEnd.SetActive(false);
                arrow.GetComponent<RectTransform>().position = new Vector2(buttonDes.GetComponent<RectTransform>().position.x + (buttonDes.GetComponent<RectTransform>().rect.width / 2) + (arrow.GetComponent<ArrowFocus>().GetWitdhMax() / 2), buttonDes.GetComponent<RectTransform>().position.y);
                arrow.SetActive(true);
                lancerDeDes.GetComponent<JetDeDesTuto>().SetScoreDesire(7, 0, 0);
                lancerDeDes.GetComponent<JetDeDesTuto>().SetPlayerToMove(players[currentPlayer - 1]);
                break;
            case 46:
                //achat de compagnie dialogue
                buttonAcheterMaison.SetActive(true);
                buttonVendreMaison.SetActive(true);
                buttonHypotheque.SetActive(true);
                buttonRembouserHypotheque.SetActive(true);
                buttonEchanger.SetActive(true);
                buttonEnd.SetActive(true);
                buttonDes.SetActive(true);
                dialoguePanel.SetActive(true);
                panelPropriete.SetActive(true);
                arrow.SetActive(false);
                panelPropriete.GetComponent<SetUpPropriete>().SetUp(32);
                break;
            case 47:
                //achat de compagnie
                dialoguePanel.SetActive(false);
                arrow.SetActive(true);
                break;
            case 48:
                //dialogue échange
                players[currentPlayer - 1].GetComponent<PlayerScript>().SetArgent(50);
                argentDuJoueur.GetComponent<TextMeshProUGUI>().text = "M" + players[currentPlayer - 1].GetComponent<PlayerScript>().GetArgent().ToString();
                case28.GetComponent<Image>().color = new Color32(currentColor.r, currentColor.g, currentColor.b, 100);
                dialoguePanel.SetActive(true);
                panelPropriete.SetActive(false);
                arrow.SetActive(false);
                break;
            case 49:
                //échange
                dialoguePanel.SetActive(false);
                buttonAcheterMaison.SetActive(false);
                buttonVendreMaison.SetActive(false);
                buttonHypotheque.SetActive(false);
                buttonRembouserHypotheque.SetActive(false);
                buttonDes.SetActive(false);
                buttonEnd.SetActive(false);
                arrow.GetComponent<RectTransform>().position = new Vector2(buttonEchanger.GetComponent<RectTransform>().position.x + (buttonEchanger.GetComponent<RectTransform>().rect.width / 2) + (arrow.GetComponent<ArrowFocus>().GetWitdhMax() / 2), buttonEchanger.GetComponent<RectTransform>().position.y);
                arrow.SetActive(true);
                break;
            case 50:
                //fin explication échange + fin tour j4
                buttonAcheterMaison.SetActive(true);
                buttonVendreMaison.SetActive(true);
                buttonHypotheque.SetActive(true);
                buttonRembouserHypotheque.SetActive(true);
                buttonEchanger.SetActive(true);
                buttonEnd.SetActive(true);
                buttonDes.SetActive(true);
                dialoguePanel.SetActive(true);
                arrow.SetActive(false);
                panelEchange.SetActive(false);
                case12.GetComponent<Image>().color = new Color32(currentColor.r, currentColor.g, currentColor.b, 100);
                Color32 tmpcol= players[currentPlayer - 2].GetComponent<PlayerScript>().GetCouleur();
                case25.GetComponent<Image>().color = new Color32(tmpcol.r, tmpcol.g, tmpcol.b, 100);
                break;
            case 51:
                //fin du tour de j4
                dialoguePanel.SetActive(false);
                buttonAcheterMaison.SetActive(false);
                buttonVendreMaison.SetActive(false);
                buttonHypotheque.SetActive(false);
                buttonRembouserHypotheque.SetActive(false);
                buttonEchanger.SetActive(false);
                buttonDes.SetActive(false);
                arrow.GetComponent<RectTransform>().position = new Vector2(buttonEnd.GetComponent<RectTransform>().position.x + (buttonEnd.GetComponent<RectTransform>().rect.width / 2) + (arrow.GetComponent<ArrowFocus>().GetWitdhMax() / 2), buttonEnd.GetComponent<RectTransform>().position.y);
                arrow.SetActive(true);
                break;
            case 52:
                //début tour de j5 +lancer de dés
                arrow.SetActive(false);
                players[currentPlayer - 1].GetComponent<PlayerScript>().SetArgent(200);
                argentDuJoueur.GetComponent<TextMeshProUGUI>().text = "M" + players[currentPlayer - 1].GetComponent<PlayerScript>().GetArgent().ToString();
                buttonAcheterMaison.SetActive(true);
                buttonVendreMaison.SetActive(true);
                buttonHypotheque.SetActive(true);
                buttonRembouserHypotheque.SetActive(true);
                buttonEchanger.SetActive(true);
                buttonEnd.SetActive(true);
                buttonDes.SetActive(true);
                panelPerso.SetActive(true);
                panelPerso.GetComponent<SetUpPanelPerso>().SetUpPerso(players[currentPlayer - 1]);
                music.GetComponent<SetUpMusic>().SetTheMusic(players[currentPlayer - 1]);
                background.GetComponent<BackgroundSetUp>().SetTheFond(players[currentPlayer - 1]);
                break;
            case 53:
                //lancer de dés j5
                dialoguePanel.SetActive(false);
                buttonAcheterMaison.SetActive(false);
                buttonVendreMaison.SetActive(false);
                buttonHypotheque.SetActive(false);
                buttonRembouserHypotheque.SetActive(false);
                buttonEchanger.SetActive(false);
                buttonEnd.SetActive(false);
                arrow.GetComponent<RectTransform>().position = new Vector2(buttonDes.GetComponent<RectTransform>().position.x + (buttonDes.GetComponent<RectTransform>().rect.width / 2) + (arrow.GetComponent<ArrowFocus>().GetWitdhMax() / 2), buttonDes.GetComponent<RectTransform>().position.y);
                arrow.SetActive(true);
                lancerDeDes.GetComponent<JetDeDesTuto>().SetScoreDesire(10, 5, 5);
                lancerDeDes.GetComponent<JetDeDesTuto>().SetPlayerToMove(players[currentPlayer - 1]);
                break;
            case 54:
                //dialogue loyer
                buttonAcheterMaison.SetActive(true);
                buttonVendreMaison.SetActive(true);
                buttonHypotheque.SetActive(true);
                buttonRembouserHypotheque.SetActive(true);
                buttonEchanger.SetActive(true);
                buttonEnd.SetActive(true);
                buttonDes.SetActive(true);
                dialoguePanel.SetActive(true);
                panelPayerLoyer.SetActive(true);
                arrow.SetActive(false);
                break;
            case 55:
                //payer loyer
                dialoguePanel.SetActive(false);
                arrow.SetActive(true);
                break;
            case 56:
                //fin explication loyer + relance de dés
                players[currentPlayer - 1].GetComponent<PlayerScript>().SetArgent(100);
                argentDuJoueur.GetComponent<TextMeshProUGUI>().text = "M" + players[currentPlayer - 1].GetComponent<PlayerScript>().GetArgent().ToString();
                dialoguePanel.SetActive(true);
                panelPayerLoyer.SetActive(false);
                arrow.SetActive(false);
                break;
            case 57:
                //relance de dés j5
                dialoguePanel.SetActive(false);
                buttonAcheterMaison.SetActive(false);
                buttonVendreMaison.SetActive(false);
                buttonHypotheque.SetActive(false);
                buttonRembouserHypotheque.SetActive(false);
                buttonEchanger.SetActive(false);
                buttonEnd.SetActive(false);
                arrow.GetComponent<RectTransform>().position = new Vector2(buttonDes.GetComponent<RectTransform>().position.x + (buttonDes.GetComponent<RectTransform>().rect.width / 2) + (arrow.GetComponent<ArrowFocus>().GetWitdhMax() / 2), buttonDes.GetComponent<RectTransform>().position.y);
                arrow.SetActive(true);
                lancerDeDes.GetComponent<JetDeDesTuto>().SetScoreDesire(5, 0, 0);
                lancerDeDes.GetComponent<JetDeDesTuto>().SetPlayerToMove(players[currentPlayer - 1]);
                break;
            case 58:
                //explication parc gratuit +fin de tour j5
                buttonAcheterMaison.SetActive(true);
                buttonVendreMaison.SetActive(true);
                buttonHypotheque.SetActive(true);
                buttonRembouserHypotheque.SetActive(true);
                buttonEchanger.SetActive(true);
                buttonEnd.SetActive(true);
                buttonDes.SetActive(true);
                dialoguePanel.SetActive(true);
                arrow.SetActive(false);
                break;
            case 59:
                //fin de tour j5
                dialoguePanel.SetActive(false);
                buttonAcheterMaison.SetActive(false);
                buttonVendreMaison.SetActive(false);
                buttonHypotheque.SetActive(false);
                buttonRembouserHypotheque.SetActive(false);
                buttonEchanger.SetActive(false);
                buttonDes.SetActive(false);
                arrow.GetComponent<RectTransform>().position = new Vector2(buttonEnd.GetComponent<RectTransform>().position.x + (buttonEnd.GetComponent<RectTransform>().rect.width / 2) + (arrow.GetComponent<ArrowFocus>().GetWitdhMax() / 2), buttonEnd.GetComponent<RectTransform>().position.y);
                arrow.SetActive(true);
                break;
            case 60:
                //début de tour j6
                arrow.SetActive(false);
                players[currentPlayer - 1].GetComponent<PlayerScript>().SetArgent(0);
                argentDuJoueur.GetComponent<TextMeshProUGUI>().text = "M" + players[currentPlayer - 1].GetComponent<PlayerScript>().GetArgent().ToString();
                buttonAcheterMaison.SetActive(true);
                buttonVendreMaison.SetActive(true);
                buttonHypotheque.SetActive(true);
                buttonRembouserHypotheque.SetActive(true);
                buttonEchanger.SetActive(true);
                buttonEnd.SetActive(true);
                buttonDes.SetActive(true);
                panelPerso.SetActive(true);
                panelPerso.GetComponent<SetUpPanelPerso>().SetUpPerso(players[currentPlayer - 1]);
                music.GetComponent<SetUpMusic>().SetTheMusic(players[currentPlayer - 1]);
                background.GetComponent<BackgroundSetUp>().SetTheFond(players[currentPlayer - 1]);
                break;
            case 61:
                //lancer de dés j6
                dialoguePanel.SetActive(false);
                buttonAcheterMaison.SetActive(false);
                buttonVendreMaison.SetActive(false);
                buttonHypotheque.SetActive(false);
                buttonRembouserHypotheque.SetActive(false);
                buttonEchanger.SetActive(false);
                buttonEnd.SetActive(false);
                arrow.GetComponent<RectTransform>().position = new Vector2(buttonDes.GetComponent<RectTransform>().position.x + (buttonDes.GetComponent<RectTransform>().rect.width / 2) + (arrow.GetComponent<ArrowFocus>().GetWitdhMax() / 2), buttonDes.GetComponent<RectTransform>().position.y);
                arrow.SetActive(true);
                lancerDeDes.GetComponent<JetDeDesTuto>().SetScoreDesire(7, 0, 0);
                lancerDeDes.GetComponent<JetDeDesTuto>().SetPlayerToMove(players[currentPlayer - 1]);
                break;
            case 62:
                //explication de taxes +hypothèque
                buttonAcheterMaison.SetActive(true);
                buttonVendreMaison.SetActive(true);
                buttonHypotheque.SetActive(true);
                buttonRembouserHypotheque.SetActive(true);
                buttonEchanger.SetActive(true);
                buttonEnd.SetActive(true);
                buttonDes.SetActive(true);
                dialoguePanel.SetActive(true);
                panelPayerTaxe.SetActive(true);
                arrow.SetActive(false);
                break;
            case 63:
                //hypothèquer +payement de taxe
                dialoguePanel.SetActive(false);
                buttonAcheterMaison.SetActive(false);
                buttonVendreMaison.SetActive(false);
                buttonDes.SetActive(false);
                buttonRembouserHypotheque.SetActive(false);
                buttonEchanger.SetActive(false);
                buttonEnd.SetActive(false);
                panelPayerTaxe.SetActive(false);
                arrow.GetComponent<RectTransform>().position = new Vector2(buttonHypotheque.GetComponent<RectTransform>().position.x + (buttonHypotheque.GetComponent<RectTransform>().rect.width / 2) + (arrow.GetComponent<ArrowFocus>().GetWitdhMax() / 2), buttonHypotheque.GetComponent<RectTransform>().position.y);
                arrow.SetActive(true);
                break;
            case 64:
                //fin explication hypothèque
                buttonAcheterMaison.SetActive(true);
                buttonVendreMaison.SetActive(true);
                buttonHypotheque.SetActive(true);
                buttonRembouserHypotheque.SetActive(true);
                buttonEchanger.SetActive(true);
                buttonEnd.SetActive(true);
                buttonDes.SetActive(true);
                dialoguePanel.SetActive(true);
                panelPayerTaxe.SetActive(true);
                arrow.SetActive(false);
                players[currentPlayer - 1].GetComponent<PlayerScript>().SetArgent(110);
                argentDuJoueur.GetComponent<TextMeshProUGUI>().text = "M" + players[currentPlayer - 1].GetComponent<PlayerScript>().GetArgent().ToString();
                break;
            case 65:
                //payement de taxe
                dialoguePanel.SetActive(false);
                arrow.SetActive(true);
                break;
            case 66:
                //fin de tour j6
                players[currentPlayer - 1].GetComponent<PlayerScript>().SetArgent(10);
                argentDuJoueur.GetComponent<TextMeshProUGUI>().text = "M" + players[currentPlayer - 1].GetComponent<PlayerScript>().GetArgent().ToString();
                buttonAcheterMaison.SetActive(false);
                buttonVendreMaison.SetActive(false);
                buttonHypotheque.SetActive(false);
                buttonRembouserHypotheque.SetActive(false);
                buttonEchanger.SetActive(false);
                buttonDes.SetActive(false);
                panelPayerTaxe.SetActive(false);
                arrow.GetComponent<RectTransform>().position = new Vector2(buttonEnd.GetComponent<RectTransform>().position.x + (buttonEnd.GetComponent<RectTransform>().rect.width / 2) + (arrow.GetComponent<ArrowFocus>().GetWitdhMax() / 2), buttonEnd.GetComponent<RectTransform>().position.y);
                arrow.SetActive(true);
                break;
            case 67:
                //début de tour j7 + explication sortie de prison
                players[currentPlayer - 1].GetComponent<Transform>().SetParent(null);
                players[currentPlayer - 1].GetComponent<Transform>().SetParent(case10.transform);
                arrow.SetActive(false);
                players[currentPlayer - 1].GetComponent<PlayerScript>().SetArgent(200);
                argentDuJoueur.GetComponent<TextMeshProUGUI>().text = "M" + players[currentPlayer - 1].GetComponent<PlayerScript>().GetArgent().ToString();
                buttonAcheterMaison.SetActive(true);
                buttonVendreMaison.SetActive(true);
                buttonHypotheque.SetActive(true);
                buttonRembouserHypotheque.SetActive(true);
                buttonEchanger.SetActive(true);
                buttonEnd.SetActive(true);
                buttonDes.SetActive(true);
                buttonSortieDePrison.SetActive(true);
                panelPerso.SetActive(true);
                panelPerso.GetComponent<SetUpPanelPerso>().SetUpPerso(players[currentPlayer - 1]);
                music.GetComponent<SetUpMusic>().SetTheMusic(players[currentPlayer - 1]);
                background.GetComponent<BackgroundSetUp>().SetTheFond(players[currentPlayer - 1]);
                break;
            case 68:
                //utilisation de carte sortie de prison
                dialoguePanel.SetActive(false);
                buttonAcheterMaison.SetActive(false);
                buttonVendreMaison.SetActive(false);
                buttonHypotheque.SetActive(false);
                buttonRembouserHypotheque.SetActive(false);
                buttonEchanger.SetActive(false);
                buttonDes.SetActive(false);
                buttonEnd.SetActive(false);
                arrow.GetComponent<RectTransform>().position = new Vector2(buttonSortieDePrison.GetComponent<RectTransform>().position.x + (buttonSortieDePrison.GetComponent<RectTransform>().rect.width / 2) + (arrow.GetComponent<ArrowFocus>().GetWitdhMax() / 2), buttonSortieDePrison.GetComponent<RectTransform>().position.y);
                arrow.SetActive(true);
                break;
            case 69:
                //dialogue lancer de dés j7
                buttonAcheterMaison.SetActive(true);
                buttonVendreMaison.SetActive(true);
                buttonHypotheque.SetActive(true);
                buttonRembouserHypotheque.SetActive(true);
                buttonEchanger.SetActive(true);
                buttonEnd.SetActive(true);
                buttonDes.SetActive(true);
                buttonSortieDePrison.SetActive(false);
                arrow.SetActive(false);
                dialoguePanel.SetActive(true);
                break;
            case 70:
                //lancer de dés j7
                dialoguePanel.SetActive(false);
                buttonAcheterMaison.SetActive(false);
                buttonVendreMaison.SetActive(false);
                buttonHypotheque.SetActive(false);
                buttonRembouserHypotheque.SetActive(false);
                buttonEchanger.SetActive(false);
                buttonEnd.SetActive(false);
                arrow.GetComponent<RectTransform>().position = new Vector2(buttonDes.GetComponent<RectTransform>().position.x + (buttonDes.GetComponent<RectTransform>().rect.width / 2) + (arrow.GetComponent<ArrowFocus>().GetWitdhMax() / 2), buttonDes.GetComponent<RectTransform>().position.y);
                arrow.SetActive(true);
                lancerDeDes.GetComponent<JetDeDesTuto>().SetScoreDesire(3, 2, 1);
                lancerDeDes.GetComponent<JetDeDesTuto>().SetPlayerToMove(players[currentPlayer - 1]);
                break;
            case 71:
                //achat de propriété loyer double dialogue
                buttonAcheterMaison.SetActive(true);
                buttonVendreMaison.SetActive(true);
                buttonHypotheque.SetActive(true);
                buttonRembouserHypotheque.SetActive(true);
                buttonEchanger.SetActive(true);
                buttonEnd.SetActive(true);
                buttonDes.SetActive(true);
                dialoguePanel.SetActive(true);
                panelPropriete.SetActive(true);
                arrow.SetActive(false);
                panelPropriete.GetComponent<SetUpPropriete>().SetUp(7);
                break;
            case 72:
                //achat proprété loyer double
                dialoguePanel.SetActive(false);
                arrow.SetActive(true);
                break;
            case 73:
                //explication loyer doublé + remboursement d'hypothèque
                players[currentPlayer - 1].GetComponent<PlayerScript>().SetArgent(60);
                argentDuJoueur.GetComponent<TextMeshProUGUI>().text = "M" + players[currentPlayer - 1].GetComponent<PlayerScript>().GetArgent().ToString();
                case13.GetComponent<Image>().color = new Color32(currentColor.r, currentColor.g, currentColor.b, 100);
                dialoguePanel.SetActive(true);
                panelPropriete.SetActive(false);
                arrow.SetActive(false);
                break;
            case 74:
                //remboursement d'hypothèque
                dialoguePanel.SetActive(false);
                buttonAcheterMaison.SetActive(false);
                buttonVendreMaison.SetActive(false);
                buttonHypotheque.SetActive(false);
                buttonDes.SetActive(false);
                buttonEchanger.SetActive(false);
                buttonEnd.SetActive(false);
                arrow.GetComponent<RectTransform>().position = new Vector2(buttonRembouserHypotheque.GetComponent<RectTransform>().position.x + (buttonRembouserHypotheque.GetComponent<RectTransform>().rect.width / 2) + (arrow.GetComponent<ArrowFocus>().GetWitdhMax() / 2), buttonRembouserHypotheque.GetComponent<RectTransform>().position.y);
                arrow.SetActive(true);
                break;
            case 75:
                //fin explication remboursement d'hypothèque+ fin de tour j7
                buttonAcheterMaison.SetActive(true);
                buttonVendreMaison.SetActive(true);
                buttonHypotheque.SetActive(true);
                buttonRembouserHypotheque.SetActive(true);
                buttonEchanger.SetActive(true);
                buttonEnd.SetActive(true);
                buttonDes.SetActive(true);
                dialoguePanel.SetActive(true);
                arrow.SetActive(false);
                players[currentPlayer - 1].GetComponent<PlayerScript>().SetArgent(5);
                argentDuJoueur.GetComponent<TextMeshProUGUI>().text = "M" + players[currentPlayer - 1].GetComponent<PlayerScript>().GetArgent().ToString();
                break;
            case 76:
                //fin de tour j7
                dialoguePanel.SetActive(false);
                buttonAcheterMaison.SetActive(false);
                buttonVendreMaison.SetActive(false);
                buttonHypotheque.SetActive(false);
                buttonRembouserHypotheque.SetActive(false);
                buttonEchanger.SetActive(false);
                buttonDes.SetActive(false);
                panelPayerTaxe.SetActive(false);
                arrow.GetComponent<RectTransform>().position = new Vector2(buttonEnd.GetComponent<RectTransform>().position.x + (buttonEnd.GetComponent<RectTransform>().rect.width / 2) + (arrow.GetComponent<ArrowFocus>().GetWitdhMax() / 2), buttonEnd.GetComponent<RectTransform>().position.y);
                arrow.SetActive(true);
                break;
            case 77:
                //début de tour j8 +lancer de dés j8
                arrow.SetActive(false);
                players[currentPlayer - 1].GetComponent<PlayerScript>().SetArgent(0);
                argentDuJoueur.GetComponent<TextMeshProUGUI>().text = "M" + players[currentPlayer - 1].GetComponent<PlayerScript>().GetArgent().ToString();
                buttonAcheterMaison.SetActive(true);
                buttonVendreMaison.SetActive(true);
                buttonHypotheque.SetActive(true);
                buttonRembouserHypotheque.SetActive(true);
                buttonEchanger.SetActive(true);
                buttonEnd.SetActive(true);
                buttonDes.SetActive(true);
                buttonSortieDePrison.SetActive(true);
                panelPerso.SetActive(true);
                panelPerso.GetComponent<SetUpPanelPerso>().SetUpPerso(players[currentPlayer - 1]);
                music.GetComponent<SetUpMusic>().SetTheMusic(players[currentPlayer - 1]);
                background.GetComponent<BackgroundSetUp>().SetTheFond(players[currentPlayer - 1]);
                break;
            case 78:
                //lancer de dés j8
                dialoguePanel.SetActive(false);
                buttonAcheterMaison.SetActive(false);
                buttonVendreMaison.SetActive(false);
                buttonHypotheque.SetActive(false);
                buttonRembouserHypotheque.SetActive(false);
                buttonEchanger.SetActive(false);
                buttonEnd.SetActive(false);
                arrow.GetComponent<RectTransform>().position = new Vector2(buttonDes.GetComponent<RectTransform>().position.x + (buttonDes.GetComponent<RectTransform>().rect.width / 2) + (arrow.GetComponent<ArrowFocus>().GetWitdhMax() / 2), buttonDes.GetComponent<RectTransform>().position.y);
                arrow.SetActive(true);
                lancerDeDes.GetComponent<JetDeDesTuto>().SetScoreDesire(7, 0, 0);
                lancerDeDes.GetComponent<JetDeDesTuto>().SetPlayerToMove(players[currentPlayer - 1]);
                break;
            case 79:
                //explication ruine
                buttonAcheterMaison.SetActive(true);
                buttonVendreMaison.SetActive(true);
                buttonHypotheque.SetActive(true);
                buttonRembouserHypotheque.SetActive(true);
                buttonEchanger.SetActive(true);
                buttonEnd.SetActive(true);
                buttonDes.SetActive(true);
                arrow.SetActive(false);
                dialoguePanel.SetActive(true);
                break;
            case 80:
                //destruction de j8
                Destroy(players[currentPlayer - 1].gameObject);
                break;

        }
        //incrémentation du compteur
        cptAction++;
    }
}
