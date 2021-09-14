using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListDeJoueur : MonoBehaviour
{

    //liste des joueurs
    private List<KeyValuePair<string, int>> listeDeJoueur;

    // Start appeller à l'instantiation
    void Start()
    {
        //initialisation de la liste des joueur
        listeDeJoueur = new List<KeyValuePair<string, int>>();
    }

    //suppression d'un joueur de la liste
    public void DeleteJoueur(int key)
    {
        listeDeJoueur.Remove(listeDeJoueur[key]);
    }

    //enregistrement d'une liste
    public void SetListeDeJoueur(List<KeyValuePair<string,int>> newList)
    {
        listeDeJoueur = newList;
    }

    //envoie de la liste
    public List<KeyValuePair<string,int>> GetListeDeJoueur()
    {
        return listeDeJoueur;
    }
}
