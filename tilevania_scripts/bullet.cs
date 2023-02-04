using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
   Rigidbody2D myRigidbody;
   [SerializeField] float bulletSpeed=20f;
   Playermovement player;
   float xSpeed;
    void Start()
    {
        myRigidbody= GetComponent<Rigidbody2D>();
        player= FindObjectOfType<Playermovement>();
        xSpeed=player.transform.localScale.x* bulletSpeed;
    }

    
    void Update()
    {
        myRigidbody.velocity= new Vector2(xSpeed,0);
    }
    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag=="enemy")
        {
            Destroy(other.gameObject);
        }
        Destroy(gameObject);
        
    }
     void OnCollisionEnter2D(Collision2D other) {
        Destroy(gameObject);
    }
}
