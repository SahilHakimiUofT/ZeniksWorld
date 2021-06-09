using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneHitBoxes : MonoBehaviour
{
    public LayerMask whatIsPlayer;
    private SpriteRenderer theSR; 
    private PhoneHitBoxes instance;
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
       

        RaycastHit2D hitCentre  =  Physics2D.Raycast(new Vector3(transform.position.x,transform.position.y+(theSR.bounds.extents.y*.7f),transform.position.z),Vector2.up,.4f,whatIsPlayer);
        
        
        RaycastHit2D hitLeft =  Physics2D.Raycast(new Vector3(transform.position.x-(theSR.bounds.extents.x*.5f),transform.position.y+(theSR.bounds.extents.y*.7f),transform.position.z),Vector2.up,.4f,whatIsPlayer);


        RaycastHit2D hitRight =  Physics2D.Raycast(new Vector3(transform.position.x+(theSR.bounds.extents.x*.5f),transform.position.y+(theSR.bounds.extents.y*.7f),transform.position.z),Vector2.up,.4f,whatIsPlayer);


          
        RaycastHit2D hitLeft2 =  Physics2D.Raycast(new Vector3(transform.position.x-(theSR.bounds.extents.x*.4f),transform.position.y+(theSR.bounds.extents.y*.7f),transform.position.z),Vector2.up,.4f,whatIsPlayer);


        RaycastHit2D hitRight2 =  Physics2D.Raycast(new Vector3(transform.position.x+(theSR.bounds.extents.x*.4f),transform.position.y+(theSR.bounds.extents.y*.7f),transform.position.z),Vector2.up,.4f,whatIsPlayer);


  
        RaycastHit2D hitLeft3 =  Physics2D.Raycast(new Vector3(transform.position.x-(theSR.bounds.extents.x*.3f),transform.position.y+(theSR.bounds.extents.y*.7f),transform.position.z),Vector2.up,.4f,whatIsPlayer);


        RaycastHit2D hitRight3 =  Physics2D.Raycast(new Vector3(transform.position.x+(theSR.bounds.extents.x*.3f),transform.position.y+(theSR.bounds.extents.y*.7f),transform.position.z),Vector2.up,.4f,whatIsPlayer);


  
        RaycastHit2D hitLeft4 =  Physics2D.Raycast(new Vector3(transform.position.x-(theSR.bounds.extents.x*.2f),transform.position.y+(theSR.bounds.extents.y*.7f),transform.position.z),Vector2.up,.4f,whatIsPlayer);


        RaycastHit2D hitRight4 =  Physics2D.Raycast(new Vector3(transform.position.x+(theSR.bounds.extents.x*.2f),transform.position.y+(theSR.bounds.extents.y*.7f),transform.position.z),Vector2.up,.4f,whatIsPlayer);


  
        RaycastHit2D hitLeft5 =  Physics2D.Raycast(new Vector3(transform.position.x-(theSR.bounds.extents.x*.1f),transform.position.y+(theSR.bounds.extents.y*.7f),transform.position.z),Vector2.up,.4f,whatIsPlayer);


        RaycastHit2D hitRight5 =  Physics2D.Raycast(new Vector3(transform.position.x+(theSR.bounds.extents.x*.1f),transform.position.y+(theSR.bounds.extents.y*.7f),transform.position.z),Vector2.up,.4f,whatIsPlayer);
        
        //Artheek's Changes
        RaycastHit2D hitLeft6 =  Physics2D.Raycast(new Vector3(transform.position.x-(theSR.bounds.extents.x*.6f),transform.position.y+(theSR.bounds.extents.y*.7f),transform.position.z),Vector2.up,.4f,whatIsPlayer);
        RaycastHit2D hitRight6 =  Physics2D.Raycast(new Vector3(transform.position.x+(theSR.bounds.extents.x*.6f),transform.position.y+(theSR.bounds.extents.y*.7f),transform.position.z),Vector2.up,.4f,whatIsPlayer);

        RaycastHit2D hitLeft6dot7 =  Physics2D.Raycast(new Vector3(transform.position.x-(theSR.bounds.extents.x*.67f),transform.position.y+(theSR.bounds.extents.y*.7f),transform.position.z),Vector2.up,.4f,whatIsPlayer);    
        RaycastHit2D hitRight6dot7 =  Physics2D.Raycast(new Vector3(transform.position.x+(theSR.bounds.extents.x*.67f),transform.position.y+(theSR.bounds.extents.y*.7f),transform.position.z),Vector2.up,.4f,whatIsPlayer);

        RaycastHit2D hitRightAngle =  Physics2D.Raycast(new Vector3(transform.position.x+(theSR.bounds.extents.x*.6f),transform.position.y+(theSR.bounds.extents.y*.3f),transform.position.z),new Vector2(1,1.75f),.2f,whatIsPlayer);

        RaycastHit2D hitLeftAngle =  Physics2D.Raycast(new Vector3(transform.position.x-(theSR.bounds.extents.x*.6f),transform.position.y+(theSR.bounds.extents.y*.3f),transform.position.z),new Vector2(-1,1.75f),.2f,whatIsPlayer);
        

    /*
    
        Debug.DrawRay(new Vector3(transform.position.x,transform.position.y+(theSR.bounds.extents.y*.7f),transform.position.z), Vector2.up*.4f, Color.green);
        Debug.DrawRay(new Vector3(transform.position.x-(theSR.bounds.extents.x*.5f),transform.position.y+(theSR.bounds.extents.y*.7f),transform.position.z), Vector2.up*.4f, Color.green);
        Debug.DrawRay(new Vector3(transform.position.x+(theSR.bounds.extents.x*.5f),transform.position.y+(theSR.bounds.extents.y*.7f),transform.position.z), Vector2.up*.4f, Color.green);
        
        Debug.DrawRay(new Vector3(transform.position.x-(theSR.bounds.extents.x*.4f),transform.position.y+(theSR.bounds.extents.y*.7f),transform.position.z), Vector2.up*.4f, Color.green);
        Debug.DrawRay(new Vector3(transform.position.x+(theSR.bounds.extents.x*.4f),transform.position.y+(theSR.bounds.extents.y*.7f),transform.position.z), Vector2.up*.4f, Color.green);
        
        Debug.DrawRay(new Vector3(transform.position.x-(theSR.bounds.extents.x*.6f),transform.position.y+(theSR.bounds.extents.y*.7f),transform.position.z), Vector2.up*.4f, Color.green);
        Debug.DrawRay(new Vector3(transform.position.x+(theSR.bounds.extents.x*.6f),transform.position.y+(theSR.bounds.extents.y*.7f),transform.position.z), Vector2.up*.4f, Color.green);
        
        Debug.DrawRay(new Vector3(transform.position.x-(theSR.bounds.extents.x*.67f),transform.position.y+(theSR.bounds.extents.y*.7f),transform.position.z), Vector2.up*.4f, Color.green);
        Debug.DrawRay(new Vector3(transform.position.x+(theSR.bounds.extents.x*.67f),transform.position.y+(theSR.bounds.extents.y*.7f),transform.position.z), Vector2.up*.4f, Color.green);

         Debug.DrawRay(new Vector3(transform.position.x-(theSR.bounds.extents.x*.3f),transform.position.y+(theSR.bounds.extents.y*.7f),transform.position.z), Vector2.up*.4f, Color.green);
        Debug.DrawRay(new Vector3(transform.position.x+(theSR.bounds.extents.x*.3f),transform.position.y+(theSR.bounds.extents.y*.7f),transform.position.z), Vector2.up*.4f, Color.green);

         Debug.DrawRay(new Vector3(transform.position.x-(theSR.bounds.extents.x*.2f),transform.position.y+(theSR.bounds.extents.y*.7f),transform.position.z), Vector2.up*.4f, Color.green);
        Debug.DrawRay(new Vector3(transform.position.x+(theSR.bounds.extents.x*.2f),transform.position.y+(theSR.bounds.extents.y*.7f),transform.position.z), Vector2.up*.4f, Color.green);


        Debug.DrawRay(new Vector3(transform.position.x-(theSR.bounds.extents.x*.1f),transform.position.y+(theSR.bounds.extents.y*.7f),transform.position.z), Vector2.up*.4f, Color.green);
        Debug.DrawRay(new Vector3(transform.position.x+(theSR.bounds.extents.x*.1f),transform.position.y+(theSR.bounds.extents.y*.7f),transform.position.z), Vector2.up*.4f, Color.green);


        Debug.DrawRay(new Vector3(transform.position.x+(theSR.bounds.extents.x*.6f),transform.position.y+(theSR.bounds.extents.y*.3f),transform.position.z), new Vector2(1,1.75f)*.2f, Color.green);
        Debug.DrawRay(new Vector3(transform.position.x-(theSR.bounds.extents.x*.6f),transform.position.y+(theSR.bounds.extents.y*.3f),transform.position.z), new Vector2(-1,1.75f)*.2f, Color.green);

 */


           if ((hitLeft ||hitLeft2 ||hitLeft3 ||hitLeft4 ||hitLeft5 || hitCentre || hitRight || hitRight2 || hitRight3|| hitRight4 || hitRight5 ||hitRightAngle || hitLeftAngle ||hitLeft6 || hitRight6 || hitRight6dot7||hitLeft6dot7))
        {
            float willItDrop = Random.Range(0,100);
            if(willItDrop<=chanceToDrop){
                Instantiate(collectible,transform.position,transform.rotation);
                
            }
            PhoneController enemy = this.transform.parent.gameObject.GetComponent<PhoneController>();
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
