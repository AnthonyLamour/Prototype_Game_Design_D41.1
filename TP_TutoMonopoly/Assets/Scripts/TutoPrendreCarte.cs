using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutoPrendreCarte : MonoBehaviour
{
    //référnce au gameController de la scène
    public GameObject gameController;

    // Start appeller à l'instantiation
    void Start()
    {
        //ajout de la fonction appeller par le bouton
        this.gameObject.GetComponent<Button>().onClick.AddListener(Prendre);
    }

    //fonction appeller par le bouton
    private void Prendre()
    {
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
        //appelle de la prochaine action du gameController
        gameController.GetComponent<TutoController>().Action();
    }
}
