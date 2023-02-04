using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemymovement : MonoBehaviour
{
   Rigidbody2D myrigidbody;
   [SerializeField] float moveSpeed=1f;
    void Start()
    {
       myrigidbody= GetComponent<Rigidbody2D>(); 
    }

   
    void Update()
    {
      myrigidbody.velocity=new Vector2(moveSpeed,0f);  
    }


    void OnTriggerExit2D(Collider2D other) {
        moveSpeed= -moveSpeed;
        FlipEnemyFacing();
        
    }
    void FlipEnemyFacing(){
        transform.localScale= new Vector3(-(Mathf.Sign(myrigidbody.velocity.x)),1f);
    }





}
