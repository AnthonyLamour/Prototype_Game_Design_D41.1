using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class SetUpPropriete : MonoBehaviour
{

    //référence à la carte
    public GameObject card;
    //référence au nom de la carte
    public GameObject nameCard;
    //référence à la description de la carte
    public GameObject description;
    //liste des fonds de cartes possibles
    public Sprite[] fondCartes;

    //contenu du fichier txt
    private string txtContent;
    //contenu du fichier txt diviser en ligne
    private string[] splitText;
    //numéro de la ligne
    private int ligne;
    //contenu de la ligne divisé en plusieurs parties
    private string[] ligneContenu;

    //set up de la propriété
   public void SetUp(int numPropiete)
   {
        //initialisation du chemin d'accès du fichier txt
        string path = "Text/ListeCarte";
        //chargement du fichier txt
        TextAsset txtAsset = (TextAsset)Resources.Load(path);
        //récupération du contenu du fichier txt
        txtContent = txtAsset.text;
        //division du contenu du fichier en ligne
        splitText = txtContent.Split("\n"[0]);
        //définition d'un séparateur
        string[] separator = new string[1];
        separator[0] = "\\#";
        //séparation de la ligne en plusieurs parties
        ligneContenu = splitText[numPropiete].Split(separator, StringSplitOptions.None);
        //set de la carte en fonction du nombre de partie de la ligne
        switch (ligneContenu.Length)
        {
            case 10:
                //carte de propriété
                nameCard.GetComponent<TextMeshProUGUI>().text = ligneContenu[0];
                switch (ligneContenu[1])
                {
                    case "MARRON":
                        card.GetComponent<Image>().sprite = fondCartes[0];
                        break;
                    case "CYAN":
                        card.GetComponent<Image>().sprite = fondCartes[1];
                        break;
                    case "ROSE":
                        card.GetComponent<Image>().sprite = fondCartes[2];
                        break;
                    case "ORANGE":
                        card.GetComponent<Image>().sprite = fondCartes[3];
                        break;
                    case "ROUGE":
                        card.GetComponent<Image>().sprite = fondCartes[4];
                        break;
                    case "JAUNE":
                        card.GetComponent<Image>().sprite = fondCartes[5];
                        break;
                    case "VERT":
                        card.GetComponent<Image>().sprite = fondCartes[6];
                        break;
                    case "BLEU":
                        card.GetComponent<Image>().sprite = fondCartes[7];
                        break;
                }
                description.GetComponent<TextMeshProUGUI>().lineSpacing = 50;
                if (GlobalSetUp.langage == "français")
                {
                    description.GetComponent<TextMeshProUGUI>().text = "LOYER - Terrain nu M" + ligneContenu[2] + "\n" +
                                                                       "        1 maison   M" + ligneContenu[3] + "\n" +
                                                                       "        2 maisons  M" + ligneContenu[4] + "\n" +
                                                                       "        3 maisons  M" + ligneContenu[5] + "\n" +
                                                                       "        4 maisons  M" + ligneContenu[6] + "\n" +
                                                                       "        1 hôtel    M" + ligneContenu[7] + "\n" +
                                                                       "Prix d'une maison/hôtel M" + ligneContenu[8] + "\n" +
                                                                       "Prix d'hypothèque M" + ligneContenu[9] + "\n";
                }
                else
                {
                    description.GetComponent<TextMeshProUGUI>().text = "RENT - nothing M" + ligneContenu[2] + "\n" +
                                                                       "       1 house   M" + ligneContenu[3] + "\n" +
                                                                       "       2 houses  M" + ligneContenu[4] + "\n" +
                                                                       "       3 houses  M" + ligneContenu[5] + "\n" +
                                                                       "       4 houses  M" + ligneContenu[6] + "\n" +
                                                                       "       1 hotel   M" + ligneContenu[7] + "\n" +
                                                                       "House/hotel price M" + ligneContenu[8] + "\n" +
                                                                       "Mortgage price M" + ligneContenu[9] + "\n";
                }
                break;
            case 6:
                //carte de gare
                nameCard.GetComponent<TextMeshProUGUI>().text = ligneContenu[0];
                card.GetComponent<Image>().sprite = fondCartes[8];
                description.GetComponent<TextMeshProUGUI>().lineSpacing = 100;
                if (GlobalSetUp.langage == "français")
                {
                    description.GetComponent<TextMeshProUGUI>().text = "LOYER - si 1 gare   M" + ligneContenu[1] + "\n" +
                                                                       "        si 2 gares  M" + ligneContenu[2] + "\n" +
                                                                       "        si 3 gares  M" + ligneContenu[3] + "\n" +
                                                                       "        si 4 gares  M" + ligneContenu[4] + "\n" +
                                                                       "Prix d'hypothèque M" + ligneContenu[5] + "\n";
                }
                else
                {
                    description.GetComponent<TextMeshProUGUI>().text = "RENT -1 trainstation   M" + ligneContenu[1] + "\n" +
                                                                       "      2 trainstations  M" + ligneContenu[2] + "\n" +
                                                                       "      3 trainstations  M" + ligneContenu[3] + "\n" +
                                                                       "      4 trainstations  M" + ligneContenu[4] + "\n" +
                                                                       "Mortgage price M" + ligneContenu[5] + "\n";
                }
                break;
            case 4:
                //carte de compagnie
                nameCard.GetComponent<TextMeshProUGUI>().text = ligneContenu[0];
                card.GetComponent<Image>().sprite = fondCartes[8];
                description.GetComponent<TextMeshProUGUI>().paragraphSpacing = 50;
                if (GlobalSetUp.langage == "français")
                {
                    description.GetComponent<TextMeshProUGUI>().text = "LOYER - si 1 compagnie  " + ligneContenu[1] + " fois jet de dés\n" +
                                                                       "LOYER - si 2 compagnies " + ligneContenu[2] + " fois jet de dés\n" +
                                                                       "Prix d'hypothèque M" + ligneContenu[3] + "\n";
                }
                else
                {
                    description.GetComponent<TextMeshProUGUI>().text = "RENT - 1 company   " + ligneContenu[1] + " times dice score\n" +
                                                                       "RENT - 2 companies " + ligneContenu[2] + " times dice score\n" +
                                                                       "Mortgage price M" + ligneContenu[3] + "\n";
                }
                
                break;
        }

   }
}
