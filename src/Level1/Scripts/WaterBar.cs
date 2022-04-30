using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Script qui gère la barre de soif
public class WaterBar : MonoBehaviour
{
    //On initalise l'image de notre bar d'eau
    public Image barImage;

    private void Awake(){
        //On récupere l'image de la barre d'eau
        barImage = transform.Find("Water").GetComponent<Image>();
    }

    void Update(){
        //On appelle la méthode UpDate dans notre classe Water
        FontainWater.Update();

        //Permet de modifier la taille de l'image de façon horizontale selon le resultat de notre méthode
        barImage.fillAmount = FontainWater.GetWaterNormalized();
        //Si le resultat de la méthode est inférieur ou égal à 0, notre joueur est mort de soif
        if(FontainWater.GetWaterNormalized() <= 0){
            GameOverScript.lastScene = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene("GameOverScreen");
            Debug.Log("Yo mec dommage, mais tu es mort !");
        }
    }
}

public class FontainWater {

    //Constante qui indique le montant maximum d'eau qu'on puisse avoir
    public const int WATER_MAX = 100;

    //Attribut qui correspond au montant d'eau que l'on a
    public static float waterAmount = 100;

    //Attribut qui correspond au montant d'eau qui doit être enleve de la barre à chaque fois.
    public static float waterRegenAmount = 1.5f; 

    public static void Update(){
        waterAmount -= waterRegenAmount * Time.deltaTime;
    }

    //Sur Unity la taille de l'image de la barre est compris entre 0 et 1.
    // 0 --> L'image est invisible 
    // 1 --> L'image prend l'intégralité de la zone qui lui est dédié (horizontalement)
    // Ce calcul permet d'avoir un nombre entre 0 et 1 pour modifier la taille de barre
    public static float GetWaterNormalized(){
        return waterAmount / WATER_MAX;
    }

    //Permet de remonter notre niveau d'eau au MAX.
    public static void FullBar(){
        waterAmount = WATER_MAX;
    }
}
