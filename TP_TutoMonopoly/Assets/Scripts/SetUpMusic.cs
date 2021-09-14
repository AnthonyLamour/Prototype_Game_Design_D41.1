using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetUpMusic : MonoBehaviour
{
    //liste des musiques possible
    public AudioClip[] musics;

    //permet de setter la musique en fonction du personnage
    public void SetTheMusic(GameObject personnage)
    {
        //si c'est un personnage de persona 3
        if(personnage.GetComponent<Image>().sprite.name=="blanc" || personnage.GetComponent<Image>().sprite.name == "violet")
        {
            //set de la musique mass destruction
            this.GetComponent<AudioSource>().clip = musics[0];
        }
        //si c'est un personnage de persona 4
        else if (personnage.GetComponent<Image>().sprite.name == "marron" || personnage.GetComponent<Image>().sprite.name == "rouge" || personnage.GetComponent<Image>().sprite.name == "vert")
        {
            //set de la musique reach out the truth
            this.GetComponent<AudioSource>().clip = musics[1];
        }
        //si c'est un personnage de persona 5
        else if (personnage.GetComponent<Image>().sprite.name == "bleu" || personnage.GetComponent<Image>().sprite.name == "gris" || personnage.GetComponent<Image>().sprite.name == "orange")
        {
            //set de la musique last surprise
            this.GetComponent<AudioSource>().clip = musics[2];
        }
        //lancement de la musique
        this.GetComponent<AudioSource>().Play();
    }
}
