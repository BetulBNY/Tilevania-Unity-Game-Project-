using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Playermovement : MonoBehaviour
{
    [SerializeField] float runSpeed=5f;
    [SerializeField] float JumpSpeed=3f;
    [SerializeField] float climbSpeed=5f;
    [SerializeField] Vector2 deathKick= new Vector2(20f,10f);
    [SerializeField] Transform gun;
    [SerializeField] GameObject bullet;
    Vector2 moveInput;
    Rigidbody2D myrigidbody;
    Animator myAnimator;
    CapsuleCollider2D myBodyCollider;
    BoxCollider2D myfeetCollider;
    float gravityScaleAtStart;
    bool isAlive= true;
    void Start()
    {
       myrigidbody=GetComponent<Rigidbody2D>(); 
       myAnimator=GetComponent<Animator>();
       myBodyCollider=GetComponent<CapsuleCollider2D>();
       myfeetCollider= GetComponent<BoxCollider2D>();
       gravityScaleAtStart=myrigidbody.gravityScale;
    }

    
    void Update()
    {   if(!isAlive){return;}
        Run();
        FlipSprite();
        ClimbLadder();
        Die();
    }

void OnMove(InputValue value)
{   if(!isAlive){return;}
    moveInput=value.Get<Vector2>();
    Debug.Log(moveInput);
}

void OnFire(InputValue value){
     if(!isAlive){return;}
     Instantiate(bullet, gun.position, transform.rotation);
}
void OnJump(InputValue value){
    if(!isAlive){return;}
 if(!myfeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))) {return;}  
if(value.isPressed  )  //Mathf.Approximately(myrigidbody.velocity.y,0) buraya eklemiştim ama hoca farklı bir yol gösterdi onu kullanıcaz..
myrigidbody.velocity+=new Vector2(0f,JumpSpeed);                         
}

void Run(){
    //myrigidbody.velocity=moveInput;
    Vector2 playerVelocity= new Vector2(moveInput.x*runSpeed,myrigidbody.velocity.y);
    myrigidbody.velocity=playerVelocity;
    bool  playerHorizontalSpeed= Mathf.Abs(myrigidbody.velocity.x) > Mathf.Epsilon;
    myAnimator.SetBool("IsRunning",true);
}

void FlipSprite(){
   bool playerHorizontalSpeed= Mathf.Abs(myrigidbody.velocity.x) > Mathf.Epsilon;
if(playerHorizontalSpeed){
    transform.localScale=new Vector2(Mathf.Sign(myrigidbody.velocity.x),1f);
} 
}

void ClimbLadder(){
    if(!myfeetCollider.IsTouchingLayers(LayerMask.GetMask("Climbing"))){
        myrigidbody.gravityScale=gravityScaleAtStart;
         myAnimator.SetBool("IsClimbing",false);
        return;}
    Vector2 climbVelocity= new Vector2(myrigidbody.velocity.x,moveInput.y*climbSpeed);
    myrigidbody.velocity=climbVelocity;
    myrigidbody.gravityScale=0f;
    bool playerHasVerticalSpeed=Mathf.Abs(myrigidbody.velocity.y)>Mathf.Epsilon;
    myAnimator.SetBool("IsClimbing",playerHasVerticalSpeed);}

void Die(){
    if(myBodyCollider.IsTouchingLayers(LayerMask.GetMask("enemies","hazards"))){
        isAlive=false;
        myAnimator.SetTrigger("dying");
        myrigidbody.velocity=deathKick;
        FindObjectOfType<gamesession>().ProcessPlayerDeath();
    }

}

}
