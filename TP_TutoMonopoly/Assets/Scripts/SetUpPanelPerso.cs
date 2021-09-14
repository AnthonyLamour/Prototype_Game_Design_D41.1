using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetUpPanelPerso : MonoBehaviour
{
    //liste des couleurs des personages
    public Color32[] couleurs;
    //liste des fonds des personnages
    public Sprite[] fonds;
    //référence au panel de dialogue
    public GameObject panelDialogue;
    //référence à la flèche
    public GameObject arrow;

    //permet de savoir si c'est le premier joueur
    private bool first;

    //Start appeller à l'instantiation
    private void Start()
    {
        //set de first en fonction du joueur
        if (GlobalSetUp.ligneDeDepart < 29)
        {
            first = true;
        }
        else
        {
            first = false;
        }
    }

    //permet de set up le fond du personnage
    public void SetUpPerso(GameObject personnage)
    {
        //set up du fond en fonction du personnage
        switch (personnage.GetComponent<Image>().sprite.name)
        {
            case "blanc":
                this.GetComponent<Image>().color = couleurs[0];
                transform.GetChild(0).GetComponent<Image>().sprite = fonds[0];
                break;
            case "bleu":
                this.GetComponent<Image>().color = couleurs[1];
                transform.GetChild(0).GetComponent<Image>().sprite = fonds[1];
                break;
            case "gris":
                this.GetComponent<Image>().color = couleurs[2];
                transform.GetChild(0).GetComponent<Image>().sprite = fonds[2];
                break;
            case "marron":
                this.GetComponent<Image>().color = couleurs[3];
                transform.GetChild(0).GetComponent<Image>().sprite = fonds[3];
                break;
            case "orange":
                this.GetComponent<Image>().color = couleurs[4];
                transform.GetChild(0).GetComponent<Image>().sprite = fonds[4];
                break;
            case "rouge":
                this.GetComponent<Image>().color = couleurs[5];
                transform.GetChild(0).GetComponent<Image>().sprite = fonds[5];
                break;
            case "vert":
                this.GetComponent<Image>().color = couleurs[6];
                transform.GetChild(0).GetComponent<Image>().sprite = fonds[6];
                break;
            case "violet":
                this.GetComponent<Image>().color = couleurs[7];
                transform.GetChild(0).GetComponent<Image>().sprite = fonds[7];
                break;
        }
        //début de la Coroutine de fondu
        StartCoroutine(FonduCoroutine());
    }

    //Coroutine de fondu
    IEnumerator FonduCoroutine()
    {
        //temps que le fond n'a pas atteint une certaine transparence
        while (this.GetComponent<Image>().color.a<0.78f)
        {
            //modification de la transparence des images
            Color tmpColorFond = this.GetComponent<Image>().color;
            Color tmpColorPerso = transform.GetChild(0).GetComponent<Image>().color;
            tmpColorFond.a=tmpColorFond.a+0.05f;
            tmpColorPerso.a=tmpColorPerso.a+0.05f;
            this.GetComponent<Image>().color = tmpColorFond;
            transform.GetChild(0).GetComponent<Image>().color = tmpColorPerso;

            //attente de 0.1 seconde
            yield return new WaitForSeconds(0.1f);
        }
        //attente de 1 seconde
        yield return new WaitForSeconds(1f);

        //si ça n'est pas le premier joueur
        if (!first)
        {
            //activation du panel de dialogue
            panelDialogue.SetActive(true);
        }
        //sinon
        else
        {
            //activation de la flèche 
            arrow.SetActive(true);
            //set de first à faux
            first = false;
        }
        
        //désactivation du fond
        this.gameObject.SetActive(false);
    }
}
