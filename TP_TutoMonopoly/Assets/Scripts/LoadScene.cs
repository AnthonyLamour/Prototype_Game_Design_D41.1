using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{
    //nom de la scène à charger
    public string SceneName;
    //référence au background de load de la scène
    public GameObject loadingBackground;

    // Start appeller à l'instantiation
    void Start()
    {
        //ajout de la fonction appeller par le bouton
        this.gameObject.GetComponent<Button>().onClick.AddListener(LoadMyScene);
    }

    //fonction appeller par le bouton
    private void LoadMyScene()
    {
        //envoi du nom de la scène à charger
        loadingBackground.GetComponent<LoadAnime>().SceneName = SceneName;
        //activation du background de load de la scène
        loadingBackground.SetActive(true);

    }
}
