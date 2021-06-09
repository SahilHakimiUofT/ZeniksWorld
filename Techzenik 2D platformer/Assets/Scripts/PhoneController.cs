using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneController : MonoBehaviour
{

     public float moveSpeed;
    public int currentPoint;
    public List<Transform> points;

      public SpriteRenderer theSR;
    public Rigidbody2D theRB;
    private Animator anim; 
    public float moveTime,waitTime;
    public float moveCount,waitCount;
    public float jumpCount,jumpTimer;

       public string type;
    public PhoneController instance;


    void Awake(){
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
           moveCount = moveTime;
        theRB = GetComponent<Rigidbody2D>();
       for(int i = 0 ; i<points.Count;i++){
           points[i].parent = null;
       }
        
         anim=GetComponent<Animator>();
         jumpCount = jumpTimer;
    }

    // Update is called once per frame
    void Update()
    {

               if(moveCount>0){
            moveCount-=Time.deltaTime;
            if(jumpCount>=0){
                jumpCount-=Time.deltaTime;
            }else{
               anim.SetTrigger("Jump");
               jumpCount = Random.Range(jumpTimer*.75f,jumpTimer*1.25f);
            }

           

        transform.position = Vector3.MoveTowards(transform.position,points[currentPoint].position,moveSpeed*Time.deltaTime);

        if(Vector3.Distance(transform.position,points[currentPoint].position)<0.5f){
            
            currentPoint++;
            if(currentPoint == points.Count){
                currentPoint = 0;
            }
        }


     if(transform.position.x<points[currentPoint].position.x ){
                theSR.flipX = false;
        }else if(transform.position.x>points[currentPoint].position.x){
            theSR.flipX = true;
        }

  
        if(moveCount<=0){
            waitCount = Random.Range(waitTime*0.75f,waitTime*1.25f);
            if(waitCount <= 0){
                 moveCount = Random.Range(moveTime*.75f,moveTime*1.25f);
            }

        }  
        }else if(waitCount>0){
            waitCount-=Time.deltaTime;
            anim.SetTrigger("Jump");
            theRB.velocity = new Vector2(0f,theRB.velocity.y);
            if(waitCount<=0){
                moveCount = Random.Range(moveTime*.75f,moveTime*1.25f);
            }
        }
            
    }


      public void SelfDestroy(){
        Destroy(instance.gameObject);
    }
}
