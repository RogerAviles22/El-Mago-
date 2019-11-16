using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoEnemy : MonoBehaviour
{
    public float tickDeltaTime;
    public float fastTickDeltaTime;
    private float accDeltaTime;

    public GameManager gameManager;

    public float maxSpeed = 2f;
    public float speed = 1f;
    public Transform trans;

    public Rigidbody2D rb2D;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        trans = this.transform;
    }

    void Awake()
    {
        accDeltaTime = 0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //rb2D.AddForce(Vector2.right * speed);
        {
            accDeltaTime += Time.deltaTime;
            var actualMovementTick = tickDeltaTime;

            if (accDeltaTime > actualMovementTick)
            {
                { // Move down
                    var oldPos = trans.position;
                    var oldRot = trans.rotation;

                    var newPos = trans.position;
                    newPos.x += 1;
                    trans.position = newPos;
                    
                    
                }
                accDeltaTime = 0;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log($"Collision with: {collision.collider.gameObject.tag}");
        var otherObject = collision.collider.gameObject;
        if (otherObject.tag == "Player")
        {
            GameObject.Destroy(otherObject);
            gameManager.GameOver();
        }
    }
}
