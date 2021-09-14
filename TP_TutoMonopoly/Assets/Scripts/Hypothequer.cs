using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Hypothequer : MonoBehaviour
{

    //référence au gameController
    public GameObject gameController;
    //référence au nombre de maison de la propriété
    public GameObject nombreDeMaison;
    //référence au panel d'hypothèque
    public GameObject panelHypothequer;

    // Start appeller à l'instantiation
    void Start()
    {
        //ajout de la fonction appeller par le bouton
        this.gameObject.GetComponent<Button>().onClick.AddListener(HypothequerPropriete);
    }

    //fonction appeller par le bouton
    private void HypothequerPropriete()
    {
        //modification du nombre de maison de la propriété par H comme hypothéquée
        nombreDeMaison.GetComponent<TextMeshProUGUI>().text = "H";
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
        //lancement de la prochaine action du gameController
        gameController.GetComponent<TutoController>().Action();
        //désactivation du panel d'hypothèque
        panelHypothequer.SetActive(false);
    }
}
