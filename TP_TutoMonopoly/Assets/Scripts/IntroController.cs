using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IntroController : MonoBehaviour
{

    //référence au texte de dialogue
    public GameObject textButton;
    //référence au background de la scène
    public GameObject background;
    //référence au background de load de la scène
    public GameObject loadBackground;

    //contenu du fichier txt
    private string txtContent;
    //contenu du fichier txt diviser en ligne
    private string[] splitText;
    //numéro de la ligne actuelle
    private int ligne;

    // Start appeller à l'instantiation
    void Start()
    {
        //initialisation du chemin d'accès du fichier txt
        string path = "";
        //ajout de la fonction apppeller par le bouton
        this.gameObject.GetComponent<Button>().onClick.AddListener(Dialogue);
        //set du chemin d'accès du fichier txt en fonction de la langue choisi
        if (GlobalSetUp.langage == "français")
        {
            path = "Text/IntroDialogueFR";
        }
        else
        {
            path = "Text/IntroDialogueUS";
        }
        //chargement du fichier txt
        TextAsset txtAsset = (TextAsset)Resources.Load(path);
        //récupération du contenu du fichier txt
        txtContent = txtAsset.text;
        //division du contenu du fichier en ligne
        splitText = txtContent.Split("\n"[0]);
        //set du texte à la première ligne du fichier txt
        textButton.GetComponent<TextMeshProUGUI>().text = splitText[0];
        //initialisation du numéro de ligne
        ligne = 0;
    }

    //fonction appeller par le bouton
    private void Dialogue()
    {
        //incrémentation de la ligne
        ligne++;
        //si ça n'est pas la dernière ligne
        if (ligne < splitText.Length)
        {
            //set du text à la ligne voulue
            textButton.GetComponent<TextMeshProUGUI>().text = splitText[ligne];
            //si la ligne est 5
            if (ligne == 5)
            {
                //changement du background de la scène
                background.GetComponent<Animator>().SetBool("IsGif",true);
                //lancement du son
                this.gameObject.GetComponent<AudioSource>().Play();
            }
            //si la ligne est 6
            else if (ligne == 6)
            {
                //changement du background de la scène
                background.GetComponent<Animator>().SetBool("IsGif", false);
            }
            //si la ligne est 7
            else if (ligne == 7)
            {
                //changement du background de la scène
                background.GetComponent<Animator>().SetBool("IsFaillite", true);
            }
            //si la ligne est 8
            else if (ligne == 8)
            {
                //changement du background de la scène
                background.GetComponent<Animator>().SetBool("IsFaillite", false);
            }
        }
        //si c'est la dernière ligne
        else
        {
            //activation du background de load de la scène
            loadBackground.SetActive(true);
        }
        

    }

}
