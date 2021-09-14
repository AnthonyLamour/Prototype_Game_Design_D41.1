using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetGlobalSetUp : MonoBehaviour
{
    // Start appeller à l'instantiation
    void Start()
    {
        //reset des variables globales
        GlobalSetUp.cptDepart = 0;
        GlobalSetUp.ligneDeDepart = 0;
        GlobalSetUp.ligneDeFin = 0;
        GlobalSetUp.argentDuJoueur = 0;
    }
}
