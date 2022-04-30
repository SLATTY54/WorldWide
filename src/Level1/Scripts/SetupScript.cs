using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script qui gère le lancement de niveau
public class SetupScript : MonoBehaviour
{

    public Transform fireContainer;

    void Start()
    {
        //Rempli la barre d'eau
        FontainWater.FullBar();

        //Arrête la propagation du feu
        CountdownFire.fire = false;

        //Le joueur n'est pas dans les flammes
        FireCollider.onFire = false;
 
        //Detruit tous les feux présents sur la map (notamment si le joueur fait rejouer dans le GameOver)
        foreach(Transform child in fireContainer) {
            Destroy(child);
            CountdownFire.fire= false;
        }
    }

    void Update(){
        //Permet de rendre invisible le curseur
        Cursor.visible = false;
        //Permet de figer le curseur au milieu de l'écran
        Cursor.lockState = CursorLockMode.Locked;
    }

}
