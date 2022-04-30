using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Script qui gère lorsqu'on tombe dans l'eau
public class waterDetection : MonoBehaviour
{
    //L'affichage des bulles
    public GameObject Bubble;
    //Les mouvements du personnage
    private FirstPersonMovement fpsScript;
    //Le bruit de noyade
    public AudioSource audio;
    //Le boolean si on active le son
    private bool SoundRunning = false;
    //La gravité du personnage
    public Rigidbody rb;
    //Script qui permet de faire sauter le personnage
    private Jump JumpScript;
    //Timer
    private float time = 0.0f;
    //L'eau
    public GameObject water;
    //La tete du personnage
    public GameObject Head;

    


    // Start is called before the first frame update
    void Start()
    {
        //Initiliasation de nos attribut
        RenderSettings.fog = false;
        RenderSettings.fogColor = Color.blue;
        RenderSettings.fogDensity = 0.05f;
        time = 0;
        fpsScript = GetComponent<FirstPersonMovement>();
        JumpScript = GetComponent<Jump>();
        rb = GetComponent<Rigidbody>();
    }

    bool IsUnderWater(){
        //Si on est sous l'eau, on fait coulé doucement notre joueur
        return Head.transform.position.y < water.transform.position.y;
    }
    

    // Update is called once per frame
    void Update()
    {
        RenderSettings.fog = IsUnderWater();

        if(IsUnderWater()){
            if(!SoundRunning){
                //Si on est sous l'eau et que l'audio n'est pas encore lancé, on le lance
                audio.Play();
                SoundRunning = true;
            }
            //Si on est sous l'eau, on fait coulé tranquillement le personnage en désactivant tous ses mouvements
            time+=Time.deltaTime;
            Bubble.SetActive(true);
            fpsScript.enabled = false;
            JumpScript.enabled = false;
            //Change la gravité
            rb.drag = 15;

            if(time >= 5.0){
                //Au bout de 5 seconde, le joueur est compté comme mort
                audio.Stop();
                GameOverScript.lastScene = SceneManager.GetActiveScene().name;
                SceneManager.LoadScene("GameOverScreen");

            }


        }else{
            //Si le joueur n'est pas entrain de couler on lui laisse sa possibilité de mouvement
            Bubble.SetActive(false);
            fpsScript.enabled = true;
            JumpScript.enabled = true;
            rb.drag = 0;
        }
    }
}
