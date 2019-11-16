using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComprobarPiso : MonoBehaviour
{
    private PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponentInParent<PlayerController>(); //Para buscar al padre del Controlador
    }

    /*Comprueba la colision con el piso*/
    private void OnCollisionStay2D(Collision2D collision)
    {
        player.grounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        player.grounded = false;
    }
    
}
