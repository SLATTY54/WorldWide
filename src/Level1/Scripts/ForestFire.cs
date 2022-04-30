using System.Collections;
using UnityEngine;

//Script qui gère l'apparition du feu
public class ForestFire : MonoBehaviour
{

    //Son des branches qui brûlent
    public AudioSource audio;
    
    //le feu principal
    public GameObject fire;

    //Compteur de feu
    private int nbFire;

    public GameObject capteurZone;

    //booleen permettant exécuter qu'une fois la methode createFire
    private bool isFire = false;

    

    //dossier dans lequel on voudra mettre les feux 
    public GameObject fireContainer;
    // Start is called before the first frame update
    void Start()
    {
        //la position du capteur sera positionner a la meme position que le feu 
        capteurZone.transform.position = fire.transform.position;
        
        

        
        
        
    }

    //méthode appeler a chaque frame
    void Update()
    {   
        //Condition qui permet de verifier si le countDown est a 0 
        if(CountdownFire.fire && !isFire){
            //on active l'audio du feu
            audio.Play();
            //on passe le booleen en true pour éviter de revenir sur cette condition a chaque frame 
            isFire = true;
            //On appel la coroutine 
            StartCoroutine(createFire()); 
        }
    }
    
    //Methode qui creer plusieurs feu aleatoirement dans la map chaques secondes 
    IEnumerator createFire(){
        //boucle infinie
        while(true){
            //on creer un clone du feu principal a une position aleatoire sur la carte 
            GameObject fireClone = Instantiate(fire,new Vector3(Random.Range(-73.58f, 74.21f),fire.transform.position.y,Random.Range(21f, 150f)),fire.transform.rotation);
            //un game object va suivre chaque feu qui permettra de voir si il est dans la zone 
            capteurZone.transform.position = fireClone.transform.position;
            //le clone sera mis dans le dossier "fire Container"
            fireClone.transform.parent = fireContainer.transform;
            //le clone aura comme nom :  FireClone + son numéro 
            fire.transform.name = "FireClone"+(nbFire+1);
            //on rajoute 1 au compteur de feu 
            nbFire++;

            //Creation d'un nouveau feu dans 1 seconde
            yield return new WaitForSeconds(1);
            
        }
        
        
           
        
    }

    
}
