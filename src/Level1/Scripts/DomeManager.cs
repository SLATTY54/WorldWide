using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DomeManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool sortie;
    

    void Start()
    {
        sortie = false;
        Debug.Log("le Dome Manager est en cours de traitement");
    }
    void OnTriggerExit(Collider other){
      
        if(other.CompareTag("Fire")){
            sortie = true;
            Debug.Log("Feu sortie de la zone");
        }
    }

    void OnTriggerEnter(Collider other){
      
        if(other.CompareTag("Fire")){
            sortie = false;
            Debug.Log("Feu dans la zone");
        }
    }
}
