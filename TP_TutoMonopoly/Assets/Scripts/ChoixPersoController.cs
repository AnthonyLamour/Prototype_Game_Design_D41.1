using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChoixPersoController : MonoBehaviour
{
    //référence au text du bouton de dialogue
    public GameObject textButton;
    //référence au background de la scène
    public GameObject background;
    //référence au panel de dialogue
    public GameObject dialoguePanel;
    //référence au panel de tirage
    public GameObject tiragePanel;
    //référence au backgroun de load de scène
    public GameObject loadBackground;

    //contenu du fichier txt
    private string txtContent;
    //contenu diviser en ligne du fichier txt
    private string[] splitText;
    //numéro de la ligne actuelle
    private int ligne;

    // Start appeller à l'instantiation
    void Start()
    {
        //initialisation du chemin d'accès du fichier txt
        string path = "";
        //ajout de la fonction appeller par le bouton
        this.gameObject.GetComponent<Button>().onClick.AddListener(Dialogue);
        //set du chemin d'accès du fichier txt en fonction de la langue sélectionnée
        if (GlobalSetUp.langage == "français")
        {
            path = "Text/ChoixPersoDialogueFR";
        }
        else
        {
            path = "Text/ChoixPersoDialogueUS";
        }
        //chargement du fichier txt
        TextAsset txtAsset = (TextAsset)Resources.Load(path);
        //récupération du contenu du fichier
        txtContent = txtAsset.text;
        //division du contenu du fichier par ligne
        splitText = txtContent.Split("\n"[0]);
        //set du text de dialogue à la première ligne de texte
        textButton.GetComponent<TextMeshProUGUI>().text = splitText[0];
        //initialisation du numéro de ligne
        ligne = 0;
    }

    //fonction appeller par le bouton
    private void Dialogue()
    {
        //incrémentation du numéro de ligne
        ligne++;
        //si la ligne est la ligne 4
        if (ligne == 4)
        {
            //set du texte du dialogue 
            textButton.GetComponent<TextMeshProUGUI>().text = splitText[ligne];
            //activation du panel de tirage
            tiragePanel.SetActive(true);
            //désactivation du panel de dialogue
            dialoguePanel.SetActive(false);
        }
        //si le texte n'est pas fini
        else if (ligne < splitText.Length)
        {
            //set du texte du dialogue
            textButton.GetComponent<TextMeshProUGUI>().text = splitText[ligne];
            //si la ligne est la 20ième
            if (ligne == 20)
            {
                //lancement du son
                this.gameObject.GetComponent<AudioSource>().Play();
            }
        }
        //si le texte est fini
        else
        {
            //activation du background de load de scène
            loadBackground.SetActive(true);
        }


    }
}
