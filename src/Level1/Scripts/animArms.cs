using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class animArms : MonoBehaviour
{
    //Attribut de l'animation des bras
    Animator anim;

    void Start()
    {
        //L'animation correspond à l'animation attaché à GameObject contenant ce script 
        //Dans notre cas ce sont les bras
        anim = GetComponent<Animator>();
        //Idle est l'animation lorsque le personne ne bouge pas
        anim.Play("Idle");
        
    }

    

    // Update is called once per frame
    void Update()
    {
        //Si le joueur appuie sur les fléches directionnels
        if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)
            || Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)){
            //On l'ance l'animation comme quoi il bouge
            anim.Play("Run");
        //Sinon on regarde si il a appuyer sur E
        }else if(Input.GetKeyUp(KeyCode.E)){
            //On lance l'animation du rammasage
                anim.Play("PunchRight");
        //Sinon
        }else{
            //On lance l'animation de base
            anim.Play("Idle");
        }
    }
}
