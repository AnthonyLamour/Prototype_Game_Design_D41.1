using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AffichePanel : MonoBehaviour
{

    //référence au panel à afficher
    public GameObject panelAAfficher;
    //référence aux panels à masquer
    public GameObject[] autrePanel;

    // Start appeller à l'instantiation
    void Start()
    {
        //ajout de la fonction appeller par le bouton
        this.gameObject.GetComponent<Button>().onClick.AddListener(Affiche);
    }

    //fonction appeller par le bouton
    private void Affiche()
    {
        //lancement du son
        this.GetComponent<AudioSource>().Play();
        //affichage du panel cible
        panelAAfficher.SetActive(true);
        //masquage des autres panels
        for(var i = 0; i < autrePanel.Length; i++)
        {
            autrePanel[i].SetActive(false);
        }
    }
}
