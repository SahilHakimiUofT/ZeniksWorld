using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEagleController : MonoBehaviour
{
    public Vector3 initialSpot;
    public List<Transform> points;
    public float moveSpeed;
    public int currentPoint;
   public EnemyEagleController instance;
   public SpriteRenderer theSR;
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
         initialSpot = new Vector3(transform.position.x,transform.position.y,transform.position.z);
        for(int i = 0; i<points.Count;i++){
            points[i].parent = null;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(attackCounter>0){
            attackCounter-=Time.deltaTime;
        }else{
            if(Vector3.Distance(transform.position,PlayerController.instance.transform.position)>distanceToAttack){
        transform.position = Vector3.MoveTowards(transform.position,points[currentPoint].position,moveSpeed*Time.deltaTime);

        if(Vector3.Distance(transform.position,points[currentPoint].position)<0.5f){
            
            currentPoint++;
            if(currentPoint == points.Count){
                currentPoint = 0;
            }
        }

        if(transform.position.x<points[currentPoint].position.x){
            theSR.flipX = true;
        }else if(transform.position.x>points[currentPoint].position.x ){
            theSR.flipX = false;
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
            attackCounter = waitAfterAttack;
            attackTarget=Vector3.zero;
        }

    }
        }

    }


     public void SelfDestroy(){
        Destroy(instance.gameObject);

    }
}
