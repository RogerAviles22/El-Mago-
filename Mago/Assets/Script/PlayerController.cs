using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //public float maxSpeed = 5f;
    public float speed;
    public bool grounded; //Para controlar colision con el suelo
    //public bool shot;

    private Rigidbody2D body;
    private SpriteRenderer spr;
    private Animator animacion;

    // Start is called before the first frame update
    void Start()
    {
        animacion = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        animacion.SetFloat("Velocidad", Mathf.Abs(body.velocity.x)); //El segundo argumento debe ser valor psitivo, ya sea si nos movemos de izquierda a derecha
        animacion.SetBool("Piso", grounded);        

        float direccion = Input.GetAxis("Horizontal"); //Captura una tecal que denota movimiento en eje X
        /*float limiteVelocidad = Mathf.Clamp(body.velocity.x, -maxSpeed, maxSpeed);
        body.velocity = new Vector2(limiteVelocidad, body.velocity.y);*/
        body.velocity = new Vector3(direccion * speed, body.velocity.y, transform.position.z);
        /*{
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                animacion.SetBool("Disparo", shot);
            }
        }*/

        if (direccion < 0)
        {
            spr.flipX = true;
        }
        if(direccion > 0)
        {
            spr.flipX = false;
        }
    }
    
}
