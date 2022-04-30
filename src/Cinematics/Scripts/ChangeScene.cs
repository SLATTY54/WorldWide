using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

//Script qui permet de changer de Scene une fois la vidéo fini ou de les skips avec les boutons Echap ou Entrer
public class ChangeScene : MonoBehaviour
{
    //Video de la Scene actuelle
    public VideoPlayer vid;

    //Nom de la Scene qui doit se lancer une fois la cinématique fini
    public string nextScene;
 
 
    //On initialise quand se termine la video
    void Start(){vid.loopPointReached += CheckOver;}
 
    //Une fois terminé on lance la prochaine Scene
    void CheckOver(UnityEngine.Video.VideoPlayer vp){
        SceneManager.LoadScene(nextScene);

    }

    void Update(){
        //Si l'utilisateur appuie sur Echap ou Entrer
        if(Input.GetKey(KeyCode.Escape) || Input.GetKey(KeyCode.Return)){
            //On alnce la prochaine Scene
            SceneManager.LoadScene(nextScene);
        }
    }



}
