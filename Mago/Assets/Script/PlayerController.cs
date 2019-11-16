using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //public float maxSpeed = 5f;
    public float speed;
    public bool grounded; //Para controlar colision con el suelo
    public float jumpPower = 6.5f;
    //public bool shot;

    

    private Rigidbody2D body;
    private SpriteRenderer spr;
    private Animator animacion;
    private bool jump;

    public Transform trans;
    // Start is called before the first frame update
    void Start()
    {
        animacion = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();
        trans = this.transform;
    }

    void Update()
    {
        animacion.SetFloat("Velocidad", Mathf.Abs(body.velocity.x)); //El segundo argumento debe ser valor psitivo, ya sea si nos movemos de izquierda a derecha
        animacion.SetBool("Piso", grounded);
        if (Input.GetKeyDown(KeyCode.UpArrow) && grounded)
        {
            jump = true;
            /*var newPos = trans.position;
            newPos.y += 2;
            trans.position = newPos;*/
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {              

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

        if (direccion < -0.1f)
        {
            //transform.localScale = new Vector3(-1f, 1f, 1f);
            spr.flipX = true;
        }
        if(direccion > 0.1f)
        {
            //transform.localScale = new Vector3(1f, 1f, 1f);
            spr.flipX = false;
        }
        salto();
    }

    void salto()
    {
        if (jump)
        {
            body.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            jump = false;
        }
    }

    

}
