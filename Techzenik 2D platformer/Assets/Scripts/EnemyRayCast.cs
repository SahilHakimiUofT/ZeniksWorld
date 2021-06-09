using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRayCast : MonoBehaviour
{
    public LayerMask whatIsPlayer;
    private SpriteRenderer theSR; 
    private EnemyRayCast instance;
    private Vector3 rayDirection;


    public GameObject deathEffect;
    [Range(0,100)]public float chanceToDrop;
    public GameObject collectible;
    public float disableHitCounter;
    void Awake(){
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        theSR=GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {


        if(disableHitCounter<=0){
       

        RaycastHit2D hitCentre  =  Physics2D.Raycast(new Vector3(transform.position.x,transform.position.y+(theSR.bounds.extents.y*.65f),transform.position.z),Vector2.up,.65f,whatIsPlayer);
        
        
        RaycastHit2D hitLeft =  Physics2D.Raycast(new Vector3(transform.position.x-(theSR.bounds.extents.x*.5f),transform.position.y+(theSR.bounds.extents.y*.65f),transform.position.z),Vector2.up,.65f,whatIsPlayer);


        RaycastHit2D hitRight =  Physics2D.Raycast(new Vector3(transform.position.x+(theSR.bounds.extents.x*.5f),transform.position.y+(theSR.bounds.extents.y*.65f),transform.position.z),Vector2.up,.65f,whatIsPlayer);

    
        Debug.DrawRay(new Vector3(transform.position.x,transform.position.y+(theSR.bounds.extents.y*.65f),transform.position.z), Vector2.up*.4f, Color.green);
        Debug.DrawRay(new Vector3(transform.position.x-(theSR.bounds.extents.x*.5f),transform.position.y+(theSR.bounds.extents.y*.65f),transform.position.z), Vector2.up*.4f, Color.green);
        Debug.DrawRay(new Vector3(transform.position.x+(theSR.bounds.extents.x*.5f),transform.position.y+(theSR.bounds.extents.y*.65f),transform.position.z), Vector2.up*.4f, Color.green);




           if ((hitLeft || hitCentre || hitRight))
        {
            float willItDrop = Random.Range(0,100);
            if(willItDrop<=chanceToDrop){
                Instantiate(collectible,transform.position,transform.rotation);
                
            }
            EnemyController enemy = this.transform.parent.gameObject.GetComponent<EnemyController>();
            Instantiate(deathEffect,transform.position,transform.rotation);
            enemy.instance.SelfDestroy();
           // Destroy(other.transform.parent.gameObject);        
            PlayerController.instance.Bounce();       
        }
        
        }else{
            disableHitCounter-=Time.deltaTime;
        }



/*

        RaycastHit2D damage1 =  Physics2D.Raycast(new Vector3(transform.position.x,transform.position.y+(theSR.bounds.extents.y*0.30f),transform.position.z),Vector2.left,.65f,whatIsPlayer);

        RaycastHit2D damage2 =  Physics2D.Raycast(new Vector3(transform.position.x,transform.position.y+(theSR.bounds.extents.y*0.20f),transform.position.z),Vector2.left,.65f,whatIsPlayer);

        RaycastHit2D damage3 =  Physics2D.Raycast(new Vector3(transform.position.x,transform.position.y,transform.position.z),Vector2.left,.65f,whatIsPlayer);

        RaycastHit2D damage4 =  Physics2D.Raycast(new Vector3(transform.position.x,transform.position.y-(theSR.bounds.extents.y*.5f),transform.position.z),Vector2.left,.65f,whatIsPlayer);

        RaycastHit2D damage5 =  Physics2D.Raycast(new Vector3(transform.position.x,transform.position.y-(theSR.bounds.extents.y*0.70f),transform.position.z),Vector2.left,.65f,whatIsPlayer);
       



        Debug.DrawRay(new Vector3(transform.position.x,transform.position.y+(theSR.bounds.extents.y*0.30f),transform.position.z),Vector2.left*.65f,Color.red);
        
        Debug.DrawRay(new Vector3(transform.position.x,transform.position.y+(theSR.bounds.extents.y*0.20f),transform.position.z),Vector2.left*.65f,Color.red);

        Debug.DrawRay(new Vector3(transform.position.x,transform.position.y,transform.position.z),Vector2.left*.65f,Color.red);

        Debug.DrawRay(new Vector3(transform.position.x,transform.position.y-(theSR.bounds.extents.y*.5f),transform.position.z),Vector2.left*.65f,Color.red);
        
        Debug.DrawRay(new Vector3(transform.position.x,transform.position.y-(theSR.bounds.extents.y*0.70f),transform.position.z),Vector2.left*.65f,Color.red);



        RaycastHit2D damage6 =  Physics2D.Raycast(new Vector3(transform.position.x,transform.position.y+(theSR.bounds.extents.y*0.30f),transform.position.z),Vector2.right,.65f,whatIsPlayer);

        RaycastHit2D damage7 =  Physics2D.Raycast(new Vector3(transform.position.x,transform.position.y+(theSR.bounds.extents.y*0.20f),transform.position.z),Vector2.right,.65f,whatIsPlayer);

        RaycastHit2D damage8 =  Physics2D.Raycast(new Vector3(transform.position.x,transform.position.y,transform.position.z),Vector2.right,.65f,whatIsPlayer);

        RaycastHit2D damage9 =  Physics2D.Raycast(new Vector3(transform.position.x,transform.position.y-(theSR.bounds.extents.y*.5f),transform.position.z),Vector2.right,.65f,whatIsPlayer);

        RaycastHit2D damage10 =  Physics2D.Raycast(new Vector3(transform.position.x,transform.position.y-(theSR.bounds.extents.y*0.70f),transform.position.z),Vector2.right,.65f,whatIsPlayer);



        Debug.DrawRay(new Vector3(transform.position.x,transform.position.y+(theSR.bounds.extents.y*0.30f),transform.position.z),Vector2.right*.65f,Color.red);
        
        Debug.DrawRay(new Vector3(transform.position.x,transform.position.y+(theSR.bounds.extents.y*0.20f),transform.position.z),Vector2.right*.65f,Color.red);

        Debug.DrawRay(new Vector3(transform.position.x,transform.position.y,transform.position.z),Vector2.right*.65f,Color.red);

        Debug.DrawRay(new Vector3(transform.position.x,transform.position.y-(theSR.bounds.extents.y*.5f),transform.position.z),Vector2.right*.65f,Color.red);
        
        Debug.DrawRay(new Vector3(transform.position.x,transform.position.y-(theSR.bounds.extents.y*0.70f),transform.position.z),Vector2.right*.65f,Color.red);



         RaycastHit2D damage11 =  Physics2D.Raycast(new Vector3(transform.position.x,transform.position.y-(theSR.bounds.extents.y*.65f),transform.position.z),Vector2.down,.65f,whatIsPlayer);
        
        
        RaycastHit2D damage12 =  Physics2D.Raycast(new Vector3(transform.position.x-(theSR.bounds.extents.x*.5f),transform.position.y-(theSR.bounds.extents.y*.65f),transform.position.z),Vector2.down,.65f,whatIsPlayer);


        RaycastHit2D damage13 =  Physics2D.Raycast(new Vector3(transform.position.x+(theSR.bounds.extents.x*.5f),transform.position.y-(theSR.bounds.extents.y*.65f),transform.position.z),Vector2.down,.65f,whatIsPlayer);

        Debug.DrawRay(new Vector3(transform.position.x,transform.position.y-(theSR.bounds.extents.y*.65f),transform.position.z), Vector2.down*.50f, Color.red);
        Debug.DrawRay(new Vector3(transform.position.x-(theSR.bounds.extents.x*.5f),transform.position.y-(theSR.bounds.extents.y*.65f),transform.position.z), Vector2.down*.50f, Color.red);
        Debug.DrawRay(new Vector3(transform.position.x+(theSR.bounds.extents.x*.5f),transform.position.y-(theSR.bounds.extents.y*.65f),transform.position.z), Vector2.down*.50f, Color.red);

        


    


        if(damage1 || damage2 || damage3 || damage4|| damage5|| damage6|| damage7|| damage8|| damage9|| damage10|| damage11|| damage12|| damage13){
            disableHitCounter = .75f;
            PlayerHealthController.instance.DealDamage(1);


        }
        */



    }
     private void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
       //FindObjectOfType<PlayerHealthController>().DealDamage();
       disableHitCounter = .75f;
       PlayerHealthController.instance.DealDamage(1);
        }
    }

}
