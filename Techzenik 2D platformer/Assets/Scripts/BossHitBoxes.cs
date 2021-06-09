using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHitBoxes : MonoBehaviour
{

    public LayerMask whatIsPlayer;
    private SpriteRenderer theSR; 
    private BossHitBoxes instance;

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
        
    }


     private void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
       //FindObjectOfType<PlayerHealthController>().DealDamage();
      
       PlayerHealthController.instance.KillPlayerBoss();

        }
    }
}
