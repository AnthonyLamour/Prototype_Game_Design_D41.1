using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LancerChoixPerso : MonoBehaviour
{
    //text contenant les résultats des jets de dés
    public GameObject[] J;
    //référence au dés 1
    public GameObject desNumero1;
    //référence au dés 2
    public GameObject desNumero2;
    //sprites des faces de dés
    public Sprite[] desFaces;
    //référence au panel de tirage
    public GameObject panelTirage;
    //référence au panel de choix de personnages
    public GameObject panelChoix;
    //référence à l'objet permettant d'enrigistrer l'ordre
    public GameObject saveList;

    //résultat des lancer
    private List<KeyValuePair<string, int>> res;
    //numéro du lancé actuel
    private int numeroLancer;

    // Start appeller à l'instantiation
    void Start()
    {
        //ajout de la fonction appeller par le bouton
        this.gameObject.GetComponent<Button>().onClick.AddListener(Lancer);
        //initialisation du numéro de lancer
        numeroLancer = 0;
        //initialisation des résultats
        res = new List<KeyValuePair<string, int>>();
    }

    //fonction appeller par le bouton
    private void Lancer()
    {
        //désactivation temporaire du bouton
        this.GetComponent<Button>().interactable = false;
        //incrémentation du numéro de lancer
        numeroLancer++;
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
        //lancement de dés
        int des1 = Random.Range(1, 7);
        int des2 = Random.Range(1, 7);
        //set du résultat
        int resultat = des1 + des2;
        //modification des dés
        desNumero1.GetComponent<Image>().sprite = desFaces[des1 - 1];
        desNumero2.GetComponent<Image>().sprite = desFaces[des2 - 1];
        //ajout du lancer en fonction de la langue choisi
        if (GlobalSetUp.langage == "français")
        {
            res.Add(new KeyValuePair<string, int>("Jet " + numeroLancer.ToString() + " : ", resultat));
        }
        else
        {
            res.Add(new KeyValuePair<string, int>("Roll " + numeroLancer.ToString() + " : ", resultat));
        }
        //si il y a au moins un lancer
        if (res.Count >= 1)
        {
            //trie des lancers
            res.Sort((x, y) => x.Value.CompareTo(y.Value));
            //initialisation de index
            var index = 0;
            //poour chaque lancer
            foreach (KeyValuePair<string, int> item in res)
            {
                //incrémentaiton de l'index
                index++;
                //set de j avec les résultats de tirage
                J[res.Count - index].GetComponent<TextMeshProUGUI>().text = item.Key + item.Value.ToString();
            }
        }
        //si c'est le dernier lancer
        if (res.Count == 8)
        {
            //enregistremnet de la liste
            saveList.GetComponent<ListDeJoueur>().SetListeDeJoueur(res);
            //activation du panel de choix de personnage
            panelChoix.SetActive(true);
            //désactivation du panel de tirage
            panelTirage.SetActive(false);
        }
        //réactivation du bouton
        this.GetComponent<Button>().interactable = true;
    }
}
