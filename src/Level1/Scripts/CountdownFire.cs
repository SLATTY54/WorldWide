using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Script qui gère le chrono en haut à gauche de l'écran dans le Niveau 1
public class CountdownFire : MonoBehaviour
{
    //temps restant
    private float timeRemaining = 30;
    //Text affichant le temps restant
    public Text timeText;

    //Si le compteur est en cours ou non
    private bool timeIsRunning = false;
    //Text contenant le nombre de champignons
    public Text MushroomText;

    //Boolean qui permet de lancer l'apparition du feu
    public static bool fire = false;
    //Text de l'avertissement à la catastrophe
    public Text WarningText;
    
    //Nombre de champignons
    private int numMush;

    //Permet d'afficher dans le bon format le temps restants
    void DisplayTime(float timeToDisplay){  
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        float milliSeconds = (timeToDisplay % 1) * 1000;
        timeText.text = string.Format("{0:00}:{1:00}",seconds,milliSeconds);
    }

    void Start()
    {
        //Au début du level, les textes ne doivent pas apparaître
        timeText.gameObject.SetActive(false);
        WarningText.gameObject.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        //Update du text
        numMush = int.Parse(MushroomText.text);
        if(numMush >= 10){
            //Si on a plus de 10 champignon, on lance le chrono et affichent les différents textes de prévention
            timeIsRunning = true;
            timeText.gameObject.SetActive(true);
            WarningText.gameObject.SetActive(true);
            
        }
        if(timeIsRunning){
            if (timeRemaining > 0)
            {
                //Temps que le chrono n'est pas arrivé à la fin, on le refresh
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                //Une fois le chrono fini, on enleve les textes
                timeText.gameObject.SetActive(false);
                WarningText.gameObject.SetActive(false);
                //On remet les valeurs par défaut
                timeRemaining = 0;
                timeIsRunning = false;
                //On lance l'apparition du feu
                fire = true;
            }
            //Execute la fonction du dessus qui permet l'affichage
            DisplayTime(timeRemaining);
        }   
    }
}
