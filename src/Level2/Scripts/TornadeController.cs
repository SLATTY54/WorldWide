using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script qui gère le déplacement des tornades et les dégats aux joueurs
public class TornadeController : MonoBehaviour
{
    //Boolean si le joueur est dans une tornade
    public static bool InTornade = false;

    //Audio des dégats
    public AudioSource audio;
    //Vitesse de la tornade
    private float speed = 5;
    // Start is called before the first frame update

    public void Start()
    {
        //Toutes les 1-2 secondes on lance la méthode CauseDamage
       InvokeRepeating("CauseDamage", 0.1f, 1.5f);
    }

    // Update is called once per frame
    public void Update()
    {
        //On fait bouger notre tornade vers la gauche à l'infini
        gameObject.transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player")){
            //Si la tornade rencontre un joueur
            InTornade = true;

        }
    }

    void OnTriggerExit(Collider other){
       if(other.CompareTag("Player")){
           //Si le joueur sort de la tornade
           InTornade = false;
       }
    }

    public void CauseDamage(){
        if(InTornade){
            //Toutes les deux secondes dans la tornade, le joueur reçoit des dêgats et on joue un son
            Health.GetDamage(25);
            audio.Play();
            
        }
    }


}
