using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetImagePerso : MonoBehaviour
{

    //sprite des personnages
    public Sprite[] imagePerso;

    // Start appeller à l'instantiation
    void Start()
    {
        //initisalisation de cpt
        int cpt = 0;
        //set du sprite du personnage en fonction de son nom
        switch (this.name)
        {
            case "J1":
                while(cpt<imagePerso.Length && ListeDesJoueursEtCouleur.couleurJ1 != imagePerso[cpt].name)
                {
                    cpt++;
                }
                break;
            case "J2":
                while (cpt < imagePerso.Length && ListeDesJoueursEtCouleur.couleurJ2 != imagePerso[cpt].name)
                {
                    cpt++;
                }
                break;
            case "J3":
                while (cpt < imagePerso.Length && ListeDesJoueursEtCouleur.couleurJ3 != imagePerso[cpt].name)
                {
                    cpt++;
                }
                break;
            case "J4":
                while (cpt < imagePerso.Length && ListeDesJoueursEtCouleur.couleurJ4 != imagePerso[cpt].name)
                {
                    cpt++;
                }
                break;
            case "J5":
                while (cpt < imagePerso.Length && ListeDesJoueursEtCouleur.couleurJ5 != imagePerso[cpt].name)
                {
                    cpt++;
                }
                break;
            case "J6":
                while (cpt < imagePerso.Length && ListeDesJoueursEtCouleur.couleurJ6 != imagePerso[cpt].name)
                {
                    cpt++;
                }
                break;
            case "J7":
                while (cpt < imagePerso.Length && ListeDesJoueursEtCouleur.couleurJ7 != imagePerso[cpt].name)
                {
                    cpt++;
                }
                break;
            case "J8":
                while (cpt < imagePerso.Length && ListeDesJoueursEtCouleur.couleurJ8 != imagePerso[cpt].name)
                {
                    cpt++;
                }
                break;
        }
        transform.GetChild(0).GetComponent<Image>().sprite = imagePerso[cpt];
    }

}
