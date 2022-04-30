using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script qui inflige des dégats quand un joueur rentre dans le feu
public class FireCollider : MonoBehaviour
{

    //Boolean pour savoir si le joueur est dans le feu
    public static bool onFire = false;
    //L'audio du bruit lorsqu'on prend des dégats
    public AudioSource audio;

    public void Start(){
        //Toutes les 2 secondes on execute la fonction Damage
        InvokeRepeating("Damage", 0, 2000);
    }
    
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")){
            //Si le feu rentre en collision avec le joueur, on met l'attribut à vrai
            onFire = true;
        }   
    }

    void OnTriggerExit(Collider other){
        if(other.CompareTag("Player")){
            //Si le feu sort de la collision avec le joueur, on met l'attribut à faux
            onFire = false;
            
        }  
    }

    public void Damage(){
        if(onFire){
            //Si le joueur est actuellement dans le feu, on joue le son, et on divise sa barre de soif de moitié
            audio.Play();
            FontainWater.waterAmount = FontainWater.waterAmount/2;
        }
    }

    
}
