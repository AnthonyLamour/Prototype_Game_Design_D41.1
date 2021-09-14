using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundSetUp : MonoBehaviour
{

    //liste des sprites servant de fonds
    public Sprite[] fonds;

    //fonction permettant de setter le fond en fonction du personnage
    public void SetTheFond(GameObject personnage)
    {
        //si le personnage est un personnage de persona 3
        if (personnage.GetComponent<Image>().sprite.name == "blanc" || personnage.GetComponent<Image>().sprite.name == "violet")
        {
            //set du sprite de persona 3
            this.GetComponent<Image>().sprite = fonds[0];
        }
        //si le personnage est un personnage de persona 4
        else if (personnage.GetComponent<Image>().sprite.name == "marron" || personnage.GetComponent<Image>().sprite.name == "rouge" || personnage.GetComponent<Image>().sprite.name == "vert")
        {
            //set du sprite de persona 4
            this.GetComponent<Image>().sprite = fonds[1];
        }
        //si le personnage est un personnage de persona 5
        else if (personnage.GetComponent<Image>().sprite.name == "bleu" || personnage.GetComponent<Image>().sprite.name == "gris" || personnage.GetComponent<Image>().sprite.name == "orange")
        {
            //set du sprite de persona 5
            this.GetComponent<Image>().sprite = fonds[2];
        }
    }
}
