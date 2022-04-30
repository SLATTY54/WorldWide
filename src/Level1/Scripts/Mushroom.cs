using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Script permettant le ramassage des champignons
public class Mushroom : MonoBehaviour
{
    //Permet de savoir si le joueur est dans la zone pour ramasser un champignon
    private bool Inzone;
    //Champignon a côter du joueur
    public GameObject mush;
    //Text pour expliquer comment ramasser le champignon
    public Text MushroomText;

    // Start is called before the first frame update
    void Start()
    {
        //Au debut, le joueur n'est pas dans la zone, on affiche donc pas le texte
        Inzone = false;
        MushroomText.gameObject.SetActive(false);
    }


    void OnTriggerEnter(Collider zone){
        if(zone.gameObject.tag == "Player"){
            //Si le joueur rentre en collision avec le "dome" d'un champignon, on affiche le texte et met le boolean a vrai
            Inzone = true;
            MushroomText.gameObject.SetActive(true);
        }
    }


    void OnTriggerExit(Collider zone){
        if(zone.gameObject.tag == "Player"){
            //Si le joueur sort de la collision avec le "dome" d'un champignon, on retire le texte et met le boolean a faux
            Inzone = false;
            MushroomText.gameObject.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(Inzone){
            if (Input.GetKeyUp(KeyCode.E))
            {                
                //Si le joueur est dans la zone d'un champi et qu'il appuie sur E
                //On ramasse le champignon, le détruit et enleve le texte
                SendMessageUpwards("signalReceived",true);
                Destroy(mush);
                MushroomText.gameObject.SetActive(false);
            }
        }
    }
}


