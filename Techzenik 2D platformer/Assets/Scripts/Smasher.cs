using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smasher : MonoBehaviour
{
    public float slamSpeed;
    public float sitCounter;
    public float sitTimeTop;
    public float sitTimeBottom;

    public bool goingDown;
    public bool goingUp;
  
    public Rigidbody2D theRB;
    public Transform topSpot;
    public Transform bottomSpot;



    // Start is called before the first frame update
    void Start()
    {
         topSpot.parent = null;
         bottomSpot.parent = null;
         goingDown = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(goingDown && sitCounter<=0 && Vector3.Distance(transform.position,bottomSpot.position)>=.1f){
            

            theRB.velocity = (bottomSpot.position - transform.position).normalized * slamSpeed;
           
        }else if(goingDown && Vector3.Distance(transform.position,bottomSpot.position)<.1f && sitCounter<=0){
            sitCounter = sitTimeBottom;
            theRB.velocity = new Vector2(0f,0f);
            goingDown = false;
        }else if(!goingDown && sitCounter >0){
            sitCounter -=Time.deltaTime;
        }else if(!goingDown && sitCounter<=0 && Vector3.Distance(transform.position,topSpot.position)>=.1f){
           
           theRB.velocity = (topSpot.position - transform.position).normalized * slamSpeed*0.5f;
        }else if(!goingDown && sitCounter<=0 && Vector3.Distance(transform.position,topSpot.position)<.1f){
            theRB.velocity = new Vector2(0f,0f);
            sitCounter = sitTimeTop;
            goingDown =true;
        }else if(goingDown && sitCounter>0){
            sitCounter-=Time.deltaTime;
        }

      
    

        



/*
         isGrounded = Physics2D.OverlapCircle(transform.position,.2f,whatIsGround);
        if(isGrounded && !hitGround){
            hitGround = true;
            sitCounter = sitTime;
            theRB.velocity = new Vector2(0f,0f);
        }
        else if(hitGround && sitCounter >0){
            sitCounter -= Time.deltaTime;
        }else if(hitGround && sitCounter<=0){
            transform.position = Vector3.MoveTowards(transform.position,startingSpot.position,4f*Time.deltaTime);
        }

        if(Vector3.Distance(transform.position,startingSpot.position)<.1f && isGrounded == false && sitCounter <=0){
            hitGround = false;
            theRB.velocity = new Vector2(0f,-slamSpeed);
        }

*/


    }
}
