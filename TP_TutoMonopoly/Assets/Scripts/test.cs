using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class test : MonoBehaviour
{

    public GameObject gameController;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<Button>().onClick.AddListener(Next);
    }

    // Update is called once per frame
    void Next()
    {
        gameController.GetComponent<TutoController>().NextPlayer();
    }
}
