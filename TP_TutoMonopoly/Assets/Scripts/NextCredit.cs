using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextCredit : MonoBehaviour
{
    //référence au texte de crédit
    public GameObject creditText;

    // Start appeller à l'instantiation
    void Start()
    {
        //ajout de la fonction appeller par le bouton
        this.gameObject.GetComponent<Button>().onClick.AddListener(SetNextCredit);
    }

    //fonction appeller par le bouton
    private void SetNextCredit()
    {
        //appeller de la fonction next du texte
        creditText.GetComponent<CreditController>().Next();
    }
}
