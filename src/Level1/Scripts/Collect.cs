using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Script qui permet de gérer le compteur en haut à droite de l'écran durant le niveau 1
public class Collect : MonoBehaviour
{
    
    //Attribut du texte en haut à droite de l'écran (champignons)
    public Text compteurT; 

    //Attribut qui stock la valeur en entier
    private static int compteur;
    
    void Start()
    {
        //Au début le compteur est mis à 0
        compteur=0;
    }
 

    void signalReceived(bool collect){
        //Si on ramasse un champignon on incrémente le compteur de 1
        compteur++;
        //On update le Text
        compteurT.text = compteur.ToString();
        if(compteur >= 20){
            //Si on a les 20 champignons demandés. On lance la cinématique de fin de niveau.
            SceneManager.LoadScene("Cinematic-1");
        }
    }

    
}
