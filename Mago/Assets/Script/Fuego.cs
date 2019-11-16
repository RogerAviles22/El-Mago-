using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuego : MonoBehaviour
{
    public GameManager gameManager;
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
