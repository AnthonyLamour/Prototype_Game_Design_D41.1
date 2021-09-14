using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutoDialogueController : MonoBehaviour
{
    //référence au texte de  dialogue
    public GameObject textButton;
    //référence au gameController de la scène
    public GameObject gameController;
    //référence au background de load de la scène
    public GameObject loadBackground;

    //contenu du fichier txt
    private string txtContent;
    //contenu du fichier txt diviser en ligne
    private string[] splitText;
    //numéro de la ligne actuelle
    private int ligne;
    //liste des lignes déclanchant une action
    private List<int> ligneTrigger;

    // Start appeller à l'instantiation
    void Start()
    {
        //initialisation de la liste des lignes d'actions 
        ligneTrigger = new List<int> { 8, 11, 15, 20, 24, 27,28,31,39,49,52,55,65,66,68,71,79,80,81,84,87,95,99,102,104,108,109,112,114,119,125,132,133,134,142,144,146,157 };
        //initialisation du chemin d'accès du fichier txt
        string path = "";
        //ajout de la fonction appeller par le bouton
        this.gameObject.GetComponent<Button>().onClick.AddListener(Dialogue);
        //set du chemin d'accès du fichier txt en fonction de la langue choisi
        if (GlobalSetUp.langage == "français")
        {
            path = "Text/TutoDialogueFR";
        }
        else
        {
            path = "Text/TutoDialogueUS";
        }
        //chargement du fichier txt
        TextAsset txtAsset = (TextAsset)Resources.Load(path);
        //récupération du contenu du fichier txt
        txtContent = txtAsset.text;
        //division du contnu du fichier txt en ligne
        splitText = txtContent.Split("\n"[0]);
        //initialisation de la ligne en fonction de la ligne de départ du chapitre
        if (GlobalSetUp.ligneDeDepart == 0)
        {
            ligne = 0;
        }
        else
        {
            ligne = GlobalSetUp.ligneDeDepart;
        }
        //set du texte de dialogue
        textButton.GetComponent<TextMeshProUGUI>().text = splitText[ligne];
    }

    //appelle à l'activation
    private void OnEnable()
    {
        //fin du chapitre
        if (ligne > GlobalSetUp.ligneDeFin && GlobalSetUp.needActionToEnd)
        {
            loadBackground.SetActive(true);
        }
    }

    //fonction appeller par le bouton
    private void Dialogue()
    {
        //incrémentation de la ligne
        ligne++;
        //fin du chapitre
        if (ligne == GlobalSetUp.ligneDeFin + 1 && GlobalSetUp.ligneDeFin!=0 && !GlobalSetUp.needActionToEnd)
        {
            loadBackground.SetActive(true);
        }
        //si ça n'est pas la dernière ligne
        else if (ligne < splitText.Length)
        {
            //si la ligne déclanche une action
            if (ligneTrigger.Contains(ligne))
            {
                //déclenchement de l'action
                if (ligne == 39)
                {
                    ligne = 45;
                }
                gameController.GetComponent<TutoController>().Action();
                
            }
            //si on change de joueur
            if (splitText[ligne].IndexOf("\\#") != -1)
            {
                //incrémentation de la ligne
                ligne++;
            }
            //set du texte de dialogue
            textButton.GetComponent<TextMeshProUGUI>().text = splitText[ligne];  
        }
        //sinon
        else
        {
            //activation du background de load de scène
            loadBackground.SetActive(true);
        }

        
    }
}
