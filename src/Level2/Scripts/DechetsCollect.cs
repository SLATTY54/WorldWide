using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Script qui compte les nombres de déchets en haut à droite de l'écran du niveau 2
public class DechetsCollect : MonoBehaviour
{
    //Text du compteur
    public Text compteurDechets; 
    //Valeur du compteur
    private static int compteurD;
    
    void Start()
    {
        compteurD=0;
    }
 

    void signalReceived(bool collect){
        //Si on ramasse un déchets on rajoute 1 au compteur et on update le texte
        compteurD++;
        compteurDechets.text = compteurD.ToString();
        if(compteurD >= 20){
            //Si on a ramassé les 20 déchets, on lance la cinématique de fin du niveau 2
            SceneManager.LoadScene("Cinematic-2");
        }
    }
}
