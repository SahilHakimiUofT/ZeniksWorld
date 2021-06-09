using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IOTInitialBoss : MonoBehaviour
{

     public GameObject explosion;
    public float moveSpeed;
    public int currentPoint;
    public List<Transform> points;
    public GameObject spawn1;
     public GameObject spawn2;



    public float explodeDistance;
    public SpriteRenderer theSR;
    public Rigidbody2D theRB;
    private Animator anim; 
    public float moveTime,waitTime;
    public float moveCount,waitCount;
    public GameObject explodePoint;
   

   public bool hasExploded;
   public bool hasCalmed; 
  
    public string type;
    public static IOTInitialBoss instance;

    public float distanceToAttack,chaseSpeed;
    private Vector3 attackTarget;
    private float attackCounter;
    public float waitAfterAttack;

    

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
            

            hasExploded = false;

            if(!hasCalmed){
                 anim.ResetTrigger("Exploding");
                anim.SetTrigger("Calm");
                hasCalmed = true;
            }



        if(Vector3.Distance(transform.position,PlayerController.instance.transform.position)>distanceToAttack){
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
        }else{

              if(attackTarget == Vector3.zero){
            attackTarget = PlayerController.instance.transform.position;
        }

        transform.position = Vector3.MoveTowards(transform.position,attackTarget,chaseSpeed*Time.deltaTime);
        if(transform.position.x<attackTarget.x){
            theSR.flipX = true;
        }else if(transform.position.x>attackTarget.x ){
            theSR.flipX = false;
        }


        if(Vector3.Distance(transform.position,attackTarget)<=.1f){
            moveCount = 0;
            attackTarget=Vector3.zero;
        }
        }
  
        if(moveCount<=0){
            waitCount = Random.Range(waitTime*0.75f,waitTime*1.25f);
            if(waitCount <= 0){
                 moveCount = Random.Range(moveTime*.75f,moveTime*1.25f);
            }

        }  
        }else if(waitCount>0){
            waitCount-=Time.deltaTime;
            theRB.velocity = new Vector2(0f,theRB.velocity.y);

            if(!hasExploded){
                anim.SetTrigger("Exploding");
                anim.ResetTrigger("Calm");
                hasExploded = true;
                hasCalmed = false;
                Invoke("Explode",0.1f);
            }

            if(waitCount<=0){
                moveCount = Random.Range(moveTime*.75f,moveTime*1.25f);
            }
        }
       





        
    }

    public void Explode(){
         Instantiate(explosion,transform.position,transform.rotation);
    }


    public void SelfDestroy(){


             GameObject enemyObj1 = (GameObject)Instantiate(spawn1,transform.position - new Vector3(3f,1.75f,0f),Quaternion.Euler(0f,0f,0f));
              GameObject enemyObj2 = (GameObject)Instantiate(spawn2,transform.position + new Vector3(3f,1.75f,0f),Quaternion.Euler(0f,0f,0f));


        Destroy(instance.gameObject);
    }

    public void SpawnMinions(){
        
    }
}
