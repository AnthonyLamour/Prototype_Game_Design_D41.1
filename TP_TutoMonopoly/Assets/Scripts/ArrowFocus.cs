using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowFocus : MonoBehaviour
{

    //taille maximum de la flèche
    public int widthMax;
    //bool permettant de savoir si la flèche grandit ou rétrécie
    private bool smallOrBig;

    // Start appeller à l'instantiation
    void Start()
    {
        //set de smallOrBig à faux
        smallOrBig = false;
    }

    // Update appeller toutes les frames
    void Update()
    {
        //si la taille de la flèche est plus grande que 0 et que la flèche doit rétrécir
        if (this.GetComponent<RectTransform>().rect.width > 0 && !smallOrBig)
        {
            //diminution de la taille de la flèche
            this.GetComponent<RectTransform>().sizeDelta = new Vector2(this.GetComponent<RectTransform>().rect.width - 1, this.GetComponent<RectTransform>().rect.height - 1);
        }
        //si la taille de la flèche est 0 et qu'elle doit rétrécir
        else if(this.GetComponent<RectTransform>().rect.width == 0 && !smallOrBig)
        {
            //set de smallOrBig à vrai
            smallOrBig = true;
        }
        //si la taille de la flèche est inférieur à sa taille max et qu'elle doit grandire
        else if(this.GetComponent<RectTransform>().rect.width < widthMax && smallOrBig)
        {
            //augmentation de la taille de la flèche
            this.GetComponent<RectTransform>().sizeDelta = new Vector2(this.GetComponent<RectTransform>().rect.width + 1, this.GetComponent<RectTransform>().rect.height + 1);
        }
        //si la taille de la flèche est égale à sa taille max et qu'elle doit grandire
        else if (this.GetComponent<RectTransform>().rect.width == widthMax && smallOrBig)
        {
            //set de smallOrBig à faux
            smallOrBig = false;
        }
    }

    //fonction permettant de récupérer widthMax
    public int GetWitdhMax()
    {
        return widthMax;
    }
}
