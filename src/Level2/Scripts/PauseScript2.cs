using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Menu pause du niveu 2
public class PauseScript2 : MonoBehaviour
{

    //Canvas contenant le menu pause
    public Canvas PauseScreen;
    


    // Start is called before the first frame update
    void Start()
    {
        
        PauseScreen.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Escape)){
            //Si le joueur appuie sur espace, on désactive certains script, on affiche le canvas et on délock sa souris

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            PauseScreen.enabled = true;
            //Permet de freeze le temps
            Time.timeScale = 0;

            GameObject.Find("First Person Camera").GetComponent<FirstPersonLook>().enabled = false;
            GameObject.Find("SetupScript2").GetComponent<SetupScript2>().enabled = false;
            
        }
    }

    public void exit(){
        //Si il choisi la maison, retour au menu et on unfreeze le temps
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }

    public void Resume(){
        //Si il décide de continuer à jouer, on defreeze le temps et on remet en place les scripts qui étaient désactivés
        PauseScreen.enabled = false;
        Time.timeScale = 1;

        GameObject.Find("First Person Camera").GetComponent<FirstPersonLook>().enabled = true;
        GameObject.Find("SetupScript2").GetComponent<SetupScript2>().enabled = true;
            
    } 




}
