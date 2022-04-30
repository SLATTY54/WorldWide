using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script du lancement du niveau 2
public class SetupScript2 : MonoBehaviour{



    // Start is called before the first frame update
    void Start()
    {
        //On remet la vie du joueur au maximum
        Health.FullBar();
        
    }

    // Update is called once per frame
    void Update()
    {
        //Permet de rendre invisible le curseur
        Cursor.visible = false;
        //Permet de figer le curseur au milieu de l'écran
        Cursor.lockState = CursorLockMode.Locked;
    }
}
