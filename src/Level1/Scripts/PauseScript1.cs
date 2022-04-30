using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Script qui gère le menu échap
public class PauseScript1 : MonoBehaviour
{

    //Canvas du menu échap
    public Canvas PauseScreen;
    void Start()
    {
        //Au début on ne l'affiche pas
        PauseScreen.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Escape)){
            //Si le joueur appuie sur échap on l'affiche et on dévérouille sa souris
            Cursor.lockState = CursorLockMode.None;
            PauseScreen.enabled = true;
            Cursor.visible = true;
            //On freeze le temps et on désactive certains scripts qui peuvent interferer
            Time.timeScale = 0;
            GameObject.Find("First Person Camera").GetComponent<FirstPersonLook>().enabled = false;
            GameObject.Find("SetupScript").GetComponent<SetupScript>().enabled = false;
        }
    }

    public void exit(){
        //Si le joueur clique sur la maison
        //On defreeze le temps
        Time.timeScale = 1;
        //Et on le ramène au Menu
        SceneManager.LoadScene("Menu");
    }

    public void Resume(){
        //Si le joueur continue sa partie
        PauseScreen.enabled = false;
        //On defreeze le temps et on relance les scripts arrêter
        GameObject.Find("First Person Camera").GetComponent<FirstPersonLook>().enabled = true;
        GameObject.Find("SetupScript").GetComponent<SetupScript>().enabled = true;
        
        Time.timeScale = 1;
        
        Cursor.visible = false;
    }
}
