using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Script qui gère les boutons du menu principale
public class MenuPrincipale : MonoBehaviour
{
    public void Jouer(){
        //Lancement de la Scene du panel des niveaux
        SceneManager.LoadScene("Niveaux");
    }

    public void Quitter(){
        //Ferme l'application
        Application.Quit();
    }

}
