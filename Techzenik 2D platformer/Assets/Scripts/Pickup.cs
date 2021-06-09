using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public bool isCollectible;
    public bool isLightning;
    public static Pickup instance;
    public GameObject pickupEffect;
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
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            if(isCollectible){
                LevelManager.instance.collectibleCollected++;
                gameObject.SetActive(false);
                Instantiate(pickupEffect,transform.position,transform.rotation);
                UIController.instance.UpdateCollectibleCount();
            }if(isLightning){
                PlayerHealthController.instance.HealPlayer();
                gameObject.SetActive(false);
                Instantiate(pickupEffect,transform.position,transform.rotation);
                
            }
        
    }
}
}
