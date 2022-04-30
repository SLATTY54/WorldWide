using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Script du compteur des déchets
public class CountdownDechet : MonoBehaviour
{
    //Temps avant la catastrophe
    private float timeRemaining = 30;
    //Text qui affiche le temps restants
    public Text timeText;

    //Boolean si le compteur est en route
    private bool timeIsRunning = false;
    //Text du nombre de déchets
    public Text CompteurDechet;

    //Boolean qui permet le lancement de la montée des eaux
    public static bool water = false;
    //Text de l'avertissement
    public Text WarningText;
    //Nombre de déchets
    private int numDechet;

    //Permet l'affichage correct du timer en haut à gauche de 'lécran
    void DisplayTime(float timeToDisplay){  
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        float milliSeconds = (timeToDisplay % 1) * 1000;
        timeText.text = string.Format("{0:00}:{1:00}",seconds,milliSeconds);
    }

    


    // Start is called before the first frame update
    void Start()
    {
        //Au début les texts sont désactivés
        timeText.gameObject.SetActive(false);
        WarningText.gameObject.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        numDechet = int.Parse(CompteurDechet.text);
        if(numDechet >= 10){
            
            //Des qu'on obtient les 10 déchets on lance le chrono et affiche les textes
            timeIsRunning = true;
            timeText.gameObject.SetActive(true);
            WarningText.gameObject.SetActive(true);
            
            
            
        }
        if(timeIsRunning){
            if (timeRemaining > 0)
            {
                //Tant que le chrono n'est pas fini on l'update
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                //Quand il est fini on remet tout par défaut et on désactive les textes
                timeText.gameObject.SetActive(false);
                
                WarningText.gameObject.SetActive(false);
                
                timeRemaining = 0;
                timeIsRunning = false;
                //On lance la montée des eaux
                water = true;
                
            }
            //On actualise le texte du chrono
            DisplayTime(timeRemaining);
        }   
    }
}

