using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script qui gère la montée des eaux
public class RisingWaters : MonoBehaviour
{
    //L'eau
    public GameObject waterlv2;

    //Boolean pour savoir si c'est de l'eau
    private bool isWater = false;

    //Vecteur du déplacement de l'eau
    private Vector3 vectorWater;


    // Start is called before the first frame update
    void Start()
    {
        vectorWater = waterlv2.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
         if(CountdownDechet.water && !isWater){
            //Si le joueur a ses 10 déchets, on lance la montée des eaux
            isWater = true;
            StartCoroutine(createWater()); 
        }
    }


    IEnumerator createWater(){
        //boucle infinie
        while(true){
            //Chaque seconde on incrémente la position en Y de l'eau pour la faire montée petit à petit
            vectorWater.y+=0.1f;
            
            
            gameObject.transform.position =  new Vector3(gameObject.transform.position.x, gameObject.transform.position.y+0.1f, gameObject.transform.position.z);
            waterlv2.transform.localScale = vectorWater;

            //le nouveau clonage débutera dans 2 seconde
            yield return new WaitForSeconds(2);
            
        }
        
        
           
        
    }
}
