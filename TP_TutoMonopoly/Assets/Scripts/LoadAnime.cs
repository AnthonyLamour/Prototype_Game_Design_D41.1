using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadAnime : MonoBehaviour
{
    //nom de la scène à charger
    public string SceneName;

    // à l'éveil de l'objet
    void Awake()
    {
        //chargement de la scène
        SceneManager.LoadScene(SceneName);
    }

}
