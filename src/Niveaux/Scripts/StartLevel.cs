using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Script qui gère les boutons dans le menu des Niveaux
public class StartLevel : MonoBehaviour
{
    public void LoadScene(string sceneName){
        //On lance la Scene du niveau selectionné
        SceneManager.LoadScene(sceneName);
    }
}
