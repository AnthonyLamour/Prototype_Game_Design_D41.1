using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RembourserHypotheque : MonoBehaviour
{
    //référence au gameController de la scène
    public GameObject gameController;
    //référence au nombre de maison de la propriété
    public GameObject nombreDeMaison;
    //référence au panel de remboursement d'hypothèque
    public GameObject panelRembourserHypotheque;

    // Start appeller à l'instantiation
    void Start()
    {
        //ajout de la fonction appeller par le bouton
        this.gameObject.GetComponent<Button>().onClick.AddListener(Rembourser);
    }

    //fonction appeller par le bouton
    private void Rembourser()
    {
        //set du nombe de maison de la propriété
        nombreDeMaison.GetComponent<TextMeshProUGUI>().text = "x0";
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
        //désactivation du panel de remboursement d'hypothèque
        panelRembourserHypotheque.SetActive(false);
    }
}
