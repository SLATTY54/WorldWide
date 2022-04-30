using UnityEngine;

//Script qui gère les dépalcement aléatoire des lapins
public class RabbitController : MonoBehaviour
{

    //La vitesse du lapin
    private float speed=3 ;
  

    void Update() 
    {
        //On fait avancer notre petit lapin
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward) , 1))
        {
            //Si en avançant encore de 1, le lapin serait amené à rencontrer un object. Il fait demi tour d'une manière alétoire 
            transform.Rotate(Vector3.up * Random.Range(90, 180));
        }
    }
}
