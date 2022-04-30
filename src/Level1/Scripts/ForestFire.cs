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

    //coordonnée x 
    //private float x = 3f;

    //coordonnée z 
    private float z;
    public GameObject fireContainer;
    // Start is called before the first frame update
    void Start()
    {
        //la position du capteur sera positionner a la meme position que le feu 
        capteurZone.transform.position = fire.transform.position;
        
        z= fire.transform.position.z;

        
        
        
    }

    //méthode appeler a chaque frame
    void Update()
    {   

        if(CountdownFire.fire && !isFire){
            audio.Play();
            isFire = true;
            StartCoroutine(createFire()); 
        }
    }
    
    IEnumerator createFire(){
        //boucle infinie
        while(true){
                GameObject fireClone = Instantiate(fire,new Vector3(Random.Range(-73.58f, 74.21f),fire.transform.position.y,Random.Range(21f, 150f)),fire.transform.rotation);
                capteurZone.transform.position = fireClone.transform.position;
                fireClone.transform.parent = fireContainer.transform;
                fire.transform.name = "FireClone"+(nbFire+1);
                nbFire++;

            yield return new WaitForSeconds(1);
            
        }
        
        
           
        
    }

    
}
