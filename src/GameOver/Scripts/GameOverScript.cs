using UnityEngine;
using UnityEngine.SceneManagement;

//Script qui gère l'interface du Gameover
public class GameOverScript : MonoBehaviour
{

    //Nom de la Scene où l'utilisateur était avant d'arriver sur le GameOver
    public static string lastScene;

    public void Start(){
            //On rend visible le curseur et on le delock
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
    }

    public void RestartButton(){
        //Si le joueur veut rejouer, on le remet sur sa précédente Scene
        SceneManager.LoadScene(lastScene);
    }

    public void ExitButton(){
        //Si le joueur veut "quitter", on le ramène au Menu
        SceneManager.LoadScene("Menu");
    }
}
