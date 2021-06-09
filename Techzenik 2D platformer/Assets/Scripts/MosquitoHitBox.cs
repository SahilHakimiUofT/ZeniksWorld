using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosquitoHitBox : MonoBehaviour
{

     public LayerMask whatIsPlayer;
    private SpriteRenderer theSR; 
    private MosquitoHitBox instance;
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
       

        RaycastHit2D hitCentre  =  Physics2D.Raycast(new Vector3(transform.position.x,transform.position.y+(theSR.bounds.extents.y*.4f),transform.position.z),Vector2.up,.65f,whatIsPlayer);
        
        
        RaycastHit2D hitLeft =  Physics2D.Raycast(new Vector3(transform.position.x-(theSR.bounds.extents.x*.5f),transform.position.y+(theSR.bounds.extents.y*.4f),transform.position.z),Vector2.up,.65f,whatIsPlayer);


        RaycastHit2D hitRight =  Physics2D.Raycast(new Vector3(transform.position.x+(theSR.bounds.extents.x*.5f),transform.position.y+(theSR.bounds.extents.y*.4f),transform.position.z),Vector2.up,.65f,whatIsPlayer);

    
        Debug.DrawRay(new Vector3(transform.position.x,transform.position.y+(theSR.bounds.extents.y*.4f),transform.position.z), Vector2.up*.4f, Color.green);
        Debug.DrawRay(new Vector3(transform.position.x-(theSR.bounds.extents.x*.5f),transform.position.y+(theSR.bounds.extents.y*.4f),transform.position.z), Vector2.up*.4f, Color.green);
        Debug.DrawRay(new Vector3(transform.position.x+(theSR.bounds.extents.x*.5f),transform.position.y+(theSR.bounds.extents.y*.4f),transform.position.z), Vector2.up*.4f, Color.green);




           if ((hitLeft || hitCentre || hitRight))
        {
            float willItDrop = Random.Range(0,100);
            if(willItDrop<=chanceToDrop){
                Instantiate(collectible,transform.position,transform.rotation);
                
            }
            MoquitoController enemy = this.transform.parent.gameObject.GetComponent<MoquitoController>();
            Instantiate(deathEffect,transform.position,transform.rotation);
            enemy.instance.SelfDestroy();
           // Destroy(other.transform.parent.gameObject);        
            PlayerController.instance.Bounce();       
        }
        
        }else{
            disableHitCounter-=Time.deltaTime;
        }




    }





     private void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
       //FindObjectOfType<PlayerHealthController>().DealDamage();
       disableHitCounter = 0.5f;
       PlayerHealthController.instance.DealDamage(1);
        }
    }
}
