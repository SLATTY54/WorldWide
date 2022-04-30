using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Script qui permet au joueur de boire à la fontaine du niveau 1
public class Drink : MonoBehaviour
{
    //Attribut qui correspond au texte (Appuie sur E pour boire)
    public Text TextDrink;
    //Attribut qui indique si on se trouve proche de la fontaine
    private static bool inZone;

    // Start is called before the first frame update
    void Start()
    {
        //Au début du jeu, le joueur n'est pas dans la zone
        inZone = false;
        //On cache donc le texte
        TextDrink.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Si le joueur appuie sur E
        if(Input.GetKeyUp (KeyCode.E)){
            //Et qu'il est dans la Zone
            if(inZone){
                //On appelle la méthode qui remet au MAX sa barre d'eau
                FontainWater.FullBar();
                
            }
        }
    }

    void OnTriggerEnter(Collider other){
         //On regarde si l'élement est bien le joueur
        if(other.gameObject.tag == "Player"){
            //Si c'est le cas on affiche le texte
            TextDrink.gameObject.SetActive(true);
            //Et on indique qu'il est dans la zone
            inZone = true;
        }
    }

    void OnTriggerExit(Collider other){
        //On regarde si l'élement est bien le joueur
        if(other.gameObject.tag == "Player"){
            //Si c'est le cas on cache le texte
            TextDrink.gameObject.SetActive(false);
            //Et on indique qu'il n'est plus dans la zone
            inZone = false;
        }
    }
}
