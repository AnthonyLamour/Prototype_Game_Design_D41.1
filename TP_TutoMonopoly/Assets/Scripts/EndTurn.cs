using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndTurn : MonoBehaviour
{

    //référence au gameController de la scène
    public GameObject gameController;

    // Start appeller à l'instantiation
    void Start()
    {
        //ajout de la fonction appeller par le bouton
        this.gameObject.GetComponent<Button>().onClick.AddListener(End);
    }

    //fonction appeller par le bouton
    private void End()
    {
        //passe au joueur suivant du gameController
        gameController.GetComponent<TutoController>().NextPlayer();        
    }
}
