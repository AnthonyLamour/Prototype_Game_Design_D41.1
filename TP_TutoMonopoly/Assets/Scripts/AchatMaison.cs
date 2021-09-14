using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AchatMaison : MonoBehaviour
{

    //référence au gameController de la scène
    public GameObject gameController;
    //référence au nombre de maison de la propriété
    public GameObject nombreDeMaison;
    //référence au panel d'achat de maison
    public GameObject panelAcheterMaison;

    // Start à l'instantiation
    void Start()
    {
        //ajout de la fonction sur le bouton
        this.gameObject.GetComponent<Button>().onClick.AddListener(Acheter);
    }

    //fonction appeller par le bouton
    private void Acheter()
    {
        //modification du nombre de maison de la propriété
        nombreDeMaison.GetComponent<TextMeshProUGUI>().text = "x1";
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
        //désactivation du panel d'achat de maison
        panelAcheterMaison.SetActive(false);
    }
}
