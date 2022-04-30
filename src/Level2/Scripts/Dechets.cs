using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Script du ramassage des déchets
public class Dechets : MonoBehaviour
{
    //Si on est dans la zone
    private bool InWaste;

    //Le déchet en question
    public GameObject Dechet;
    //Text qui explique comment ramasser le déchet
    public Text DechetText;
    // Start is called before the first frame update
    void Start()
    {
        //Au début on est pas dans la zone donc on désactive le texte
        InWaste = false;
        DechetText.gameObject.SetActive(false);   
    }

    void OnTriggerEnter(Collider zone){
        if(zone.gameObject.tag == "Player"){
            //Si un joueur rentre dans la zone d'un déchets on affiche le texte
            InWaste = true;
            DechetText.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit(Collider zone){
        if(zone.gameObject.tag == "Player"){
            //Si le joueur sort de la zone on enléve le texte
            InWaste = false;
            DechetText.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(InWaste){
            if (Input.GetKeyUp(KeyCode.E))
            {         
                //Si il est dans la zone d'un déchet et qu'il appuie sur E on supprime le déchets, on incrémente 1 au compteur
                //et on désactive le texte       
                SendMessageUpwards("signalReceived",true);
                Destroy(Dechet);
                DechetText.gameObject.SetActive(false);
            }
        }
    }
}
