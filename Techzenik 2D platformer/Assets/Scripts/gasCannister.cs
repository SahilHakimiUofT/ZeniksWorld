using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gasCannister : MonoBehaviour
{
    public bool gasCan; 
    public GameObject pickupEffect;
    public static gasCannister instance;
    public SpriteRenderer theSR;
    public bool beenUsed;
    // Start is called before the first frame update
     void Awake(){
        instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
        private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            if(!beenUsed){
            StartCoroutine(delayCannister());
            }
         
    }
}

IEnumerator delayCannister (){
 
                if(gasCan){
               // gameObject.SetActive(false);
                theSR.enabled=false;
                beenUsed = true;
                Instantiate(pickupEffect,transform.position,transform.rotation);
               // PlayerController.instance.dashCount += PlayerController.instance.startDashCount;
                PlayerController.instance.didDash = false;
                yield return new WaitForSeconds(1.5f);
                theSR.enabled=true;
                beenUsed = false;
                Debug.Log("crack");
            }

}
    
}
