using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FrancaisAnglais : MonoBehaviour
{

    //liste des drapeaux
    public Sprite[] logosFRUS;

    // Start appeller à l'instantiation
    void Start()
    {
        //set du drapeau en fonction de la langue choisi
        if (GlobalSetUp.langage == "français")
        {
            transform.GetChild(0).GetComponent<Image>().sprite = logosFRUS[0];
        }
        else
        {
            transform.GetChild(0).GetComponent<Image>().sprite = logosFRUS[1];
        }
        //ajout de la fonction appeller par le bouton
        this.gameObject.GetComponent<Button>().onClick.AddListener(ChangeFRUS);
    }

    //fonction appeller par le bouton
    private void ChangeFRUS()
    {
        //set du langage par rapport à la langue choisi précédemment
        if (GlobalSetUp.langage=="français")
        {
            GlobalSetUp.langage ="anglais" ;
            transform.GetChild(0).GetComponent<Image>().sprite = logosFRUS[1];
        }
        else
        {
            GlobalSetUp.langage = "français";
            transform.GetChild(0).GetComponent<Image>().sprite = logosFRUS[0];
        }
    }
}
