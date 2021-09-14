using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class CreditController : MonoBehaviour
{

    //contenu du fichier txt
    private string txtContent;
    //contenu du fichier txt diviser page
    private string[] splitText;
    //numéro de la page actuelle
    private int page;

    // Start appeller à l'instantiation
    void Start()
    {
        //initialisation du chemin d'accès du fichier txt
        string path = "";
        //set du chemin d'accès du fichier txt en fonction de la langue sélectionnée
        if (GlobalSetUp.langage == "français")
        {
            path = "Text/CreditsFR";
        }
        else
        {
            path = "Text/CreditsUS";
        }
        //chargement du fichier txt
        TextAsset txtAsset = (TextAsset)Resources.Load(path);
        //récupération du contenu du fichier txt
        txtContent = txtAsset.text;
        //set du séparateur pour le fichier txt
        string[] separator =new string[1];
        separator[0] = "\\#";
        //séparation du fichier txt en différentes pages
        splitText = txtContent.Split(separator, StringSplitOptions.None);
        //set du text avec la première page
        this.GetComponent<TextMeshProUGUI>().text = splitText[0];
        //initialisation du numéro de page
        page = 0;
    }

    //page suivante
    public void Next()
    {
        //set du numéro de page
        page++;
        //si ça n'est pas la dernière page
        if (page < splitText.Length)
        {
            //set du text à la page suivante
            this.GetComponent<TextMeshProUGUI>().text = splitText[page];
        }
        //sinon
        else
        {
            //décrémentation de la page
            page--;
        }
    }

    //page précédente
    public void Previous()
    {
        //décrémentation de la page
        page--;
        //si la page est valide
        if (page >= 0)
        {
            //set du text à la page précédente
            this.GetComponent<TextMeshProUGUI>().text = splitText[page];
        }
        //sinon
        else
        {
            //incrémentation de la page
            page++;
        }
    }

}
