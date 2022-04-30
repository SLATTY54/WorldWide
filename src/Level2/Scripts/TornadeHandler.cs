using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script qui permet aux tornades de ne pas sortir de la map du niveua 2
public class TornadeHandler : MonoBehaviour
{

   void OnTriggerExit(Collider other){
       if(other.CompareTag("Tornade")){
           //Si la tornade sort du dome qui entoure l'île, on lui fait faire demi-tour
           other.transform.Rotate(0, 0, 135);
       }
   }
}
