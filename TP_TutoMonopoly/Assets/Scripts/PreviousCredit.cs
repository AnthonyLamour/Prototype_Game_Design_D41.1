using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PreviousCredit : MonoBehaviour
{

    //référence au text de crédit
    public GameObject creditText;

    // Start appeller à l'instantiation
    void Start()
    {
        //ajout de la fonction appeller par le bouton
        this.gameObject.GetComponent<Button>().onClick.AddListener(SetPreviousCredit);
    }

    //fonction appeller par le bouton
    private void SetPreviousCredit()
    {
        //appelle de la fonction previous du texte
        creditText.GetComponent<CreditController>().Previous();
    }
}
