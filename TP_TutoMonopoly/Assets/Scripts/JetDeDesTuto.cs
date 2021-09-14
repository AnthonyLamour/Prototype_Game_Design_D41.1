using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JetDeDesTuto : MonoBehaviour
{

    //référence au premier dés
    public GameObject des1;
    //référence au deuxième dés
    public GameObject des2;
    //sprite de faces des dés
    public Sprite[] faceDeDes;
    //référence au gameController de la scène
    public GameObject gameController;

    //score désiré pour le lancer de dés
    private int scoreDesireTotal;
    //score désiré pour le dés 1
    private int scoreDesireDes1;
    //score désiré pour le dés 2
    private int scoreDesireDes2;
    //résultat du dés 1
    private int resDes1;
    //résultat du dés 2
    private int resDes2;
    //résultat total
    private int resTotal;
    //joueur a bouger
    private GameObject playerToMove;

    // Start appeller à l'instantiation
    void Start()
    {
        //ajout de la fonction appeller par le bouton
        this.gameObject.GetComponent<Button>().onClick.AddListener(Jet);
    }

    //fonction permettant de setter le score désiré
    public void SetScoreDesire(int newScoreDesireTotal,int newScoreDesireDes1, int newScoreDesireDes2)
    {
        scoreDesireTotal = newScoreDesireTotal;
        scoreDesireDes1 = newScoreDesireDes1;
        scoreDesireDes2 = newScoreDesireDes2;
    }

    //fonction permettant de setter le joueur à bouger
    public void SetPlayerToMove(GameObject newPlayerToMove)
    {
        playerToMove = newPlayerToMove;
    }

    //fonction appeller par le bouton
    void Jet()
    {
        //initialisation du restotal
        resTotal = 0;
        //si il n'y  a pas de score désiré pour les dés 1 et 2
        if(scoreDesireDes1==0 && scoreDesireDes2 == 0)
        {
            //temps que le score désiré n'est pas atteint ou qu'il y a un double
            while (resTotal != scoreDesireTotal || resDes1==resDes2)
            {
                //jet de dés 1
                resDes1 = Random.Range(1, 6);
                //jet de dés 2
                resDes2 = Random.Range(1, 6);
                //set de resTotal
                resTotal = resDes1 + resDes2;
            }
        }
        //sinon
        else
        {
            //set du score de dés au score désiré
            resDes1 = scoreDesireDes1;
            resDes2 = scoreDesireDes2;
            resTotal = resDes1 + resDes2;
        }
        //modification des faces des dés
        des1.GetComponent<Image>().sprite = faceDeDes[resDes1 - 1];
        des2.GetComponent<Image>().sprite = faceDeDes[resDes2 - 1];
        //si double 6
        if (scoreDesireDes1 == 6 && scoreDesireDes2 == 6)
        {
            //appelle de la prochaine action du gameController
            gameController.GetComponent<TutoController>().Action();
            return;
        }
        //mouvement du joueur
        playerToMove.GetComponent<PlayerScript>().Move(resTotal);
        //désactivation du bouton
        this.GetComponent<Button>().interactable = false;
    }
}
