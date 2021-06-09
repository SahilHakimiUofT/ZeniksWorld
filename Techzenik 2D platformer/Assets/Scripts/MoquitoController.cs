using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoquitoController : MonoBehaviour
{
    public Transform firePoint;
    public GameObject projectile;

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
   
    public float shootDistance;
    public SpriteRenderer theSR;
    public Rigidbody2D theRB;
    private Animator anim; 
    public float moveTime,waitTime;
    public float moveCount,waitCount;
    public bool isMoving;
    
    public string type;
    public MoquitoController instance;



    public bool hasShot;
    public bool beenFlipped;
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


         if(waitCount<=0){
             hasShot = false;
            moveCount-=Time.deltaTime;
            isMoving = true;



        transform.position = Vector3.MoveTowards(transform.position,points[currentPoint].position,moveSpeed*Time.deltaTime);

        if(Vector3.Distance(transform.position,points[currentPoint].position)<0.5f){
             
             waitCount = 2f;
            currentPoint++;
            if(currentPoint == points.Count){
                currentPoint = 0;
            }
        }


     if(transform.position.x<points[currentPoint].position.x && !beenFlipped){
           // theSR.flipX = true;
           Flip();
           beenFlipped = true;
        }else if(transform.position.x>points[currentPoint].position.x && beenFlipped){
            //theSR.flipX = false;
            beenFlipped = false;
            Flip();
        }

    }else{

            if(!hasShot && (beenFlipped && PlayerController.instance.transform.position.x > transform.position.x || !beenFlipped && PlayerController.instance.transform.position.x < transform.position.x ) && Vector3.Distance(transform.position,PlayerController.instance.transform.position)<=shootDistance){
               isMoving = false;
               anim.SetTrigger("Spit");
               Invoke("Shoot", .3f);
               
                hasShot = true;
            }
            waitCount-=Time.deltaTime;
            
            theRB.velocity = new Vector2(0f,theRB.velocity.y);

         

        }
       
         

        
        
      

    }

    public void Shoot(){
        Instantiate(projectile,firePoint.position,firePoint.rotation);
    }


    private void Flip(){
        transform.Rotate(0f,180f,0f);  
        
        }

    public void SelfDestroy(){
        Destroy(instance.gameObject);
    }
}
