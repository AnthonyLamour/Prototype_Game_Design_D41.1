using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TXMPFRUS : MonoBehaviour
{
    //texte en français
    public string frenchTxt;
    //texte en anglais
    public string usaTxt;

    // Update appeller toutes les frames
    void Update()
    {
        //initialisation du texte en fonction de la langue choisi
        if (GlobalSetUp.langage == "français")
        {
            this.GetComponent<TextMeshProUGUI>().text = frenchTxt;
        }
        else
        {
            this.GetComponent<TextMeshProUGUI>().text = usaTxt;
        }
    }
}
