using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseAChapter : MonoBehaviour
{

    //ligne de départ du chapitre
    public int newLigneDeDepart;
    //cpt de départ du chapitre
    public int newCptDepart;
    //ligne de fin du chapitre
    public int newLigneDeFin;
    //argent du joueur au début du chapitre
    public int newArgentDuJoueur;
    //fin du chapitre par une action ou un dialogue
    public bool newNeedActionToEnd;
    //référence au background de load de scène
    public GameObject loadBackground;

    // Start appeller à l'instantiaion
    void Start()
    {
        //ajout de la fonction appeller par le bouton
        this.gameObject.GetComponent<Button>().onClick.AddListener(ChoixChapitre);
    }

    //fonction appeller par le bouton
    void ChoixChapitre()
    {
        //changement des set up de la scène 
        GlobalSetUp.ligneDeDepart = newLigneDeDepart;
        GlobalSetUp.cptDepart = newCptDepart;
        GlobalSetUp.ligneDeFin = newLigneDeFin;
        GlobalSetUp.argentDuJoueur = newArgentDuJoueur;
        GlobalSetUp.needActionToEnd = newNeedActionToEnd;
        //activation du background de load de scène
        loadBackground.SetActive(true);
        
    }
}
