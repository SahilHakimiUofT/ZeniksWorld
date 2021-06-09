using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StompBox : MonoBehaviour

{
    public GameObject deathEffect;
    [Range(0,100)]public float chanceToDrop;
    public GameObject collectible;
    public static StompBox instance;
    private float disableCounter;
    
    void Awake(){
        instance = this;
    }
    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(disableCounter>0){
            disableCounter-=Time.deltaTime;
        }


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(disableCounter<=0){
        if(other.tag == "EnemyHitBox"){
            float willItDrop = Random.Range(0,100);
            if(willItDrop<=chanceToDrop){
                Instantiate(collectible,other.transform.position,other.transform.rotation);
                
            }
            EnemyController enemy = other.transform.parent.gameObject.GetComponent<EnemyController>();
            Instantiate(deathEffect,other.transform.position,other.transform.rotation);
            
            enemy.instance.SelfDestroy();
           // Destroy(other.transform.parent.gameObject);
           
            PlayerController.instance.Bounce();

           
            Debug.Log(willItDrop);
            
        }
        }
    }

    public void disableCollider(float disableTime){
        disableCounter = disableTime;
    }
}
