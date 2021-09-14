using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPerso : MonoBehaviour
{

    //référence à la liste des joueur
    public GameObject listJoueur;
    //référence aux textes des joueur
    public GameObject[] textJoueur;
    //référence au panel de choix de personnage
    public GameObject panelChoixPerso;
    //référence au panel d'ordre de jeux
    public GameObject panelOrdre;
    //référence au panel de dialogue
    public GameObject panelDialogue;
    //référence au penel d'ordre de jeu finale
    public GameObject panelOrdreAvecImage;
    //référence aux autres boutons de personnages
    public GameObject[] buttonList;

    // Start appeller à l'instantiation
    void Start()
    {
        //ajout de la fonction appeller par le bouton
        this.gameObject.GetComponent<Button>().onClick.AddListener(Selection);
    }

    //fonction appeller par le bouton
    private void Selection()
    {
        //désactivation temporaire de tous les autres boutons
        for(var i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponent<Button>().interactable = false;
        }
        //set de la couleur du bouton en semi-transparent
        this.GetComponent<Image>().color = new Color(this.GetComponent<Image>().color.r, this.GetComponent<Image>().color.g,this.GetComponent<Image>().color.b,0.5f);
        //set de la couleur du joueur en fonction du joueur ayant choisi et du tag du bouton
        switch (8 - (listJoueur.GetComponent<ListDeJoueur>().GetListeDeJoueur().Count - 1))
        {
            case 1:
                ListeDesJoueursEtCouleur.couleurJ1 = this.gameObject.tag;
                break;
            case 2:
                ListeDesJoueursEtCouleur.couleurJ2 = this.gameObject.tag;
                break;
            case 3:
                ListeDesJoueursEtCouleur.couleurJ3 = this.gameObject.tag;
                break;
            case 4:
                ListeDesJoueursEtCouleur.couleurJ4 = this.gameObject.tag;
                break;
            case 5:
                ListeDesJoueursEtCouleur.couleurJ5 = this.gameObject.tag;
                break;
            case 6:
                ListeDesJoueursEtCouleur.couleurJ6 = this.gameObject.tag;
                break;
            case 7:
                ListeDesJoueursEtCouleur.couleurJ7 = this.gameObject.tag;
                break;
            case 8:
                ListeDesJoueursEtCouleur.couleurJ8 = this.gameObject.tag;
                break;
        }
        //début de la Coroutine gérant le son
        StartCoroutine(WaitForEndOfSound());
        
    }

    //Coroutine gérant le son
    IEnumerator WaitForEndOfSound()
    {
        //lancement du son
        this.GetComponent<AudioSource>().Play();
        //attente de la fin du son
        yield return new WaitWhile(() => this.GetComponent<AudioSource>().isPlaying);
        //suppression du joueur ayant choisi
        listJoueur.GetComponent<ListDeJoueur>().DeleteJoueur(listJoueur.GetComponent<ListDeJoueur>().GetListeDeJoueur().Count - 1);
        //initialisation de cpt
        int cpt = 0;
        //incrémentation du cpt jusqu'a ce qu'un joueur soit trouvé
        while (textJoueur[cpt] == null)
        {
            cpt++;
        }
        //destruction du text du joueur
        Destroy(textJoueur[cpt]);
        //si c'est le dernier joueur
        if (cpt == 7)
        {
            //activation du panel de dialogue
            panelDialogue.SetActive(true);
            //activattion du panel d'ordre de jeu final
            panelOrdreAvecImage.SetActive(true);
            //désactivation du panel d'ordre de jeu
            panelOrdre.SetActive(false);
            //désactivation du panel de choix de perso
            panelChoixPerso.SetActive(false);
        }
        //désactivation du bouton
        this.GetComponent<Button>().enabled = false;
        //réactivation des autres boutons
        for (var i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponent<Button>().interactable = true;
        }
    }
}
