using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{

    //numéro du joueur
    public int numero;
    //liste des couleurs de joueurs
    public Dictionary<string,Color32> listeDeCouleurs;
    //référence au plateau de jeu
    public GameObject plateau;
    //référence au bouton de lancement de dés
    public GameObject buttonLancerDeDes;
    //référence au gameController de la scène
    public GameObject gameController;
    //référence au panel de tirage de dés
    public GameObject panelDes;

    //couleur du joueur
    private Color couleur;
    //position du joueur
    private int position;
    //argent du joueur
    private int argent;
    //nouvelle position du joueur
    private int newPos;

    // appeller à l'eveil de l'objet
    void Awake()
    {
        //initialisation de l'argent du joueur
        argent = 0;
        //initialisation de la position du joueur
        position = int.Parse(transform.parent.name)-1;
        //initialisation de la liste des couleurs de joueur
        listeDeCouleurs = new Dictionary<string, Color32>();
        listeDeCouleurs.Add("blanc", new Color32(255, 255, 255,255));
        listeDeCouleurs.Add("bleu", new Color32(0, 125, 255,255));
        listeDeCouleurs.Add("gris", new Color32(125, 125, 125, 255));
        listeDeCouleurs.Add("marron", new Color32(125, 50, 50, 255));
        listeDeCouleurs.Add("orange", new Color32(255, 125, 0, 255));
        listeDeCouleurs.Add("rouge", new Color32(255, 0, 0, 255));
        listeDeCouleurs.Add("vert", new Color32(0, 255, 0, 255));
        listeDeCouleurs.Add("violet", new Color32(125, 0, 255, 255));
        //initialisation de la couleur du joueur en fonction de son numéro
        switch (numero)
        {
            case 1:
                couleur = listeDeCouleurs[ListeDesJoueursEtCouleur.couleurJ1];
                break;
            case 2:
                couleur = listeDeCouleurs[ListeDesJoueursEtCouleur.couleurJ2];
                break;
            case 3:
                couleur = listeDeCouleurs[ListeDesJoueursEtCouleur.couleurJ3];
                break;
            case 4:
                couleur = listeDeCouleurs[ListeDesJoueursEtCouleur.couleurJ4];
                break;
            case 5:
                couleur = listeDeCouleurs[ListeDesJoueursEtCouleur.couleurJ5];
                break;
            case 6:
                couleur = listeDeCouleurs[ListeDesJoueursEtCouleur.couleurJ6];
                break;
            case 7:
                couleur = listeDeCouleurs[ListeDesJoueursEtCouleur.couleurJ7];
                break;
            case 8:
                couleur = listeDeCouleurs[ListeDesJoueursEtCouleur.couleurJ8];
                break;
        }
    }

    //envoie la couleur du joueur
    public Color GetCouleur()
    {
        return couleur;
    }

    //envoie la position du joueur
    public int GetPosition()
    {
        return position;
    }

    //set la position du joueur
    public void SetPosition(int newPosition)
    {
        position = newPosition;
        transform.parent = plateau.transform.GetChild(newPosition);
    }

    //set l'argent du joueur
    public void SetArgent(int newArgent)
    {
        argent = newArgent;
    }

    //envoie l'argent du joueur
    public int GetArgent()
    {
        return argent;
    }

    //permet de déplacer le joueur
    public void Move(int scoreDes)
    {
        //désactivation du bouton de lancer de dés
        buttonLancerDeDes.GetComponent<Button>().interactable = false;
        //set de la nouvelle position du joueur
        if (position + scoreDes < plateau.transform.childCount)
        {
            newPos = position + scoreDes;
        }
        else
        {
            newPos = (position + scoreDes) - plateau.transform.childCount;
        }
        //début de la Coroutine de déplacement
        StartCoroutine(MoveCoroutine());
    }

    //fonction permettant de TP le joueur
    public void TP(int caseCible)
    {
        //set de la position du joueur
        position = caseCible;
        //changement du parent du joueur
        this.transform.SetParent(plateau.transform.GetChild(position).transform);
        //resize du joueur en fonction de la case
        if ((position > 0 && position < 10) || (position > 20 && position < 30))
        {
            this.GetComponent<RectTransform>().anchorMin = new Vector2(0.1f, 0.2f);
            this.GetComponent<RectTransform>().anchorMax = new Vector2(0.9f, 0.8f);
        }
        else if ((position > 10 && position < 20) || (position > 30 && position < 40))
        {
            this.GetComponent<RectTransform>().anchorMin = new Vector2(0.2f, 0.1f);
            this.GetComponent<RectTransform>().anchorMax = new Vector2(0.8f, 0.9f);
        }
        else
        {
            this.GetComponent<RectTransform>().anchorMin = new Vector2(0.2f, 0.2f);
            this.GetComponent<RectTransform>().anchorMax = new Vector2(0.8f, 0.8f);
        }

        this.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
        this.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
    }

    //Coroutine de déplacement
    IEnumerator MoveCoroutine()
    {
        //temps que la position est différente de la nouvelle position
        while (position != newPos)
        {
            //set de la position du joueur
            if (position + 1 < plateau.transform.childCount)
            {
                this.transform.SetParent(plateau.transform.GetChild(position + 1).transform);
                position++;
            }
            else
            {
                this.transform.SetParent(plateau.transform.GetChild(0).transform);
                position=0;
            }

            //resize du joueur en fonction de la case
            if ((position>0 && position<10) || (position>20 && position<30))
            {
                this.GetComponent<RectTransform>().anchorMin = new Vector2(0.1f, 0.2f);
                this.GetComponent<RectTransform>().anchorMax = new Vector2(0.9f, 0.8f);
            }
            else if((position >10 && position < 20) || (position > 30 && position < 40))
            {
                this.GetComponent<RectTransform>().anchorMin = new Vector2(0.2f, 0.1f);
                this.GetComponent<RectTransform>().anchorMax = new Vector2(0.8f, 0.9f);
            }
            else
            {
                this.GetComponent<RectTransform>().anchorMin = new Vector2(0.2f, 0.2f);
                this.GetComponent<RectTransform>().anchorMax = new Vector2(0.8f, 0.8f);
            }
            
            this.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
            this.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);

            //attente de 0.5 secondes
            yield return new WaitForSeconds(0.5f);
        }
        //réactivation du bouton de lancer de dés
        buttonLancerDeDes.GetComponent<Button>().interactable = true;
        //appelle de la prochaine action du gameController
        gameController.GetComponent<TutoController>().Action();
        //désactivation du panel de tirage
        panelDes.SetActive(false);
    }
}
