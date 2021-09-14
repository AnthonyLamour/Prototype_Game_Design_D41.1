using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{

    // Update appeller à toutes les frames
    void Update()
    {
        //activation/désactivation de la musique en fonction des paramètres
        if (GlobalSetUp.musicon && !this.GetComponent<AudioSource>().isPlaying)
        {
            this.GetComponent<AudioSource>().Play();
        }
        else if(!GlobalSetUp.musicon && this.GetComponent<AudioSource>().isPlaying)
        {
            this.GetComponent<AudioSource>().Stop();
        }
    }
}
