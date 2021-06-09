using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonController : MonoBehaviour
{

     private Animator anim;
     public GameObject collectible;
     public GameObject deathEffect;
     [Range(0,100)]public float chanceToDrop;
     public bool initialBoss;
     public bool secondaryBoss;
     
    // Start is called before the first frame update
    void Start()
    {
         anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other){
             if(other.tag == "Player"){  
            anim.SetTrigger("press");


             float willItDrop = Random.Range(0,100);
            if(willItDrop<=chanceToDrop){
                Instantiate(collectible,transform.position,transform.rotation);
                
            }
           

           PlayerHealthController.instance.setInivincibility(0.25f);
            Instantiate(deathEffect,transform.position,transform.rotation);
            if(initialBoss){
            IOTInitialBoss.instance.SelfDestroy();
            }else if(secondaryBoss){
                IOTBossX2 enemy = this.transform.parent.gameObject.GetComponent<IOTBossX2>();
                enemy.instance.SelfDestroy();
            }else{
                    IOTBossX3 enemy = this.transform.parent.gameObject.GetComponent<IOTBossX3>();
                enemy.instance.SelfDestroy();
            }
           // Destroy(other.transform.parent.gameObject);        
            PlayerController.instance.Bounce(); 
            bossLevelCounter.instance.currentHealth--;
             bossLevelCounter.instance.SetHealth(bossLevelCounter.instance.currentHealth);

                  
        }
    }
}
