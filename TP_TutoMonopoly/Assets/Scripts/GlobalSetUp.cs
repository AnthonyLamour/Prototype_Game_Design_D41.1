using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalSetUp : MonoBehaviour
{
    //corespond à si la musique est active ou non
    public static bool musicon = true;

    //corespond à la langue choisi
    public static string langage = "français";

    //corespond à la ligne de départ du chapitre
    public static int ligneDeDepart = 0;

    //corespond au compteur de départ du chapitre
    public static int cptDepart = 0;

    //corespond à la ligne de fin du chapitre
    public static int ligneDeFin = 0;

    //corespond à l'argent du joueur au début du chapitre
    public static int argentDuJoueur = 0;

    //corespond à si le chapitre se fini par une action ou un dialogue
    public static bool needActionToEnd = false;
}
