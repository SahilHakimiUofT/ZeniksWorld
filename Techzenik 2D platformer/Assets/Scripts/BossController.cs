using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
       public float moveSpeed;
    public int currentPoint;
    /*
    public Transform leftPoint,rightPoint;
    public Transform topPoint,bottomPoint;

    public Transform topLeftPoint,bottomLeftPoint;
    public Transform topRightPoint,bottomRightPoint;

    private bool movingRight,movingLeft;
    private bool movingUp,movingDown;
    */

   public List<Transform> points;
   
    
    public SpriteRenderer theSR;
    public Rigidbody2D theRB;
    private Animator anim; 
    public float moveTime,waitTime;
    public float moveCount,waitCount;
    public bool isMoving;
    public bool facingLeft;
    
    
    public BossController instance;



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
    }

    // Update is called once per frame
    void Update()
    {
         if(moveCount>0){
            moveCount-=Time.deltaTime;
            isMoving = true;



        transform.position = Vector3.MoveTowards(transform.position,points[currentPoint].position,moveSpeed*Time.deltaTime);

        if(Vector3.Distance(transform.position,points[currentPoint].position)<0.5f){
            
            currentPoint++;
            if(currentPoint == points.Count){
                currentPoint = 0;
            }
        }


     if(transform.position.x<points[currentPoint].position.x && facingLeft){
            theSR.flipX = true;
        }else if(transform.position.x>points[currentPoint].position.x  && facingLeft){
            theSR.flipX = false;
        }else if(transform.position.x<points[currentPoint].position.x && !facingLeft){
                theSR.flipX = false;
        }else if(transform.position.x>points[currentPoint].position.x  && !facingLeft){
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
            isMoving = false;
            theRB.velocity = new Vector2(0f,theRB.velocity.y);

            if(waitCount<=0){
                moveCount = Random.Range(moveTime*.75f,moveTime*1.25f);
            }
        }
       
         


        
        
        anim.SetBool("isMoving",isMoving);
    }
}
