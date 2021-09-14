using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetTitreChoixPerso : MonoBehaviour
{

    //référence à la liste des joueur
    public GameObject listJoueur;

    // Update appeller toutes les frames
    void Update()
    {
        //si il y a plus d'un joueur
        if (listJoueur.GetComponent<ListDeJoueur>().GetListeDeJoueur().Count >= 1)
        {
            //set du texte
            this.GetComponent<TextMeshProUGUI>().text = listJoueur.GetComponent<ListDeJoueur>().GetListeDeJoueur()[listJoueur.GetComponent<ListDeJoueur>().GetListeDeJoueur().Count-1].Key;
        }
    }
}
