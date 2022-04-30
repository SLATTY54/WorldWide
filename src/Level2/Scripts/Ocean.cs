using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script Permettant de savoir quand la tête du joueur se trouve sous l'eau
public class Ocean : MonoBehaviour
{
    //Permet de savoir si il est sous l'eau
    public static bool InWater = false;
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Head")){
            //Si la tête du joueur est sous l'eau
            InWater = true;
        }
    }


    void OnTriggerExit(Collider other){
        if(other.CompareTag("Head")){
            //Si la tête du joueur sors de l'eau (logiquement cela n'arrivera jamais, car il coûle une fois la tête sous l'eau)
            InWater = false;
        }
    }

}
