using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicOnOff : MonoBehaviour
{
    //logo de musique active ou non
    public Sprite[] logos;

    // Start appeller à l'instantiation
    void Start()
    {
        //modification du logo en fonction des paramètres
        if (GlobalSetUp.musicon)
        {
            transform.GetChild(0).GetComponent<Image>().sprite = logos[0];
        }
        else
        {
            transform.GetChild(0).GetComponent<Image>().sprite = logos[1];
        }
        //ajout de la fonction appeller par le bouton
        this.gameObject.GetComponent<Button>().onClick.AddListener(ChangeMusicOnOff);
    }

    //fonction appeller par le bouton
    private void ChangeMusicOnOff()
    {
        //modification des paramètres en fonction des précédents
        if (GlobalSetUp.musicon)
        {
            GlobalSetUp.musicon = false;
            transform.GetChild(0).GetComponent<Image>().sprite = logos[1];
        }
        else
        {
            GlobalSetUp.musicon = true;
            transform.GetChild(0).GetComponent<Image>().sprite = logos[0];
        }
    }

}
