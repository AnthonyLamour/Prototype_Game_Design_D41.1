using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetArrowOnObject : MonoBehaviour
{
    //référence à la flèche
    public GameObject arrow;

    //appeller à l'activation
    void OnEnable()
    {
        //set la flèche sur l'objet
        arrow.GetComponent<RectTransform>().position = new Vector2(this.GetComponent<RectTransform>().position.x + (this.GetComponent<RectTransform>().rect.width/2) + (arrow.GetComponent<ArrowFocus>().GetWitdhMax()/2), this.GetComponent<RectTransform>().position.y);
    }
}
