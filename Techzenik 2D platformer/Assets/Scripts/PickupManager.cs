using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupManager : MonoBehaviour
{

     private Pickup[] pickups;
    public static PickupManager instance;

    void Awake(){
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
          pickups = FindObjectsOfType<Pickup>();
    }

    // Update is called once per frame
    void Update(){

        
    }


    public void RespawnPickups(){

        Pickup[] pickupsDeactivate = FindObjectsOfType<Pickup>();

        for(int i = 0;i<pickupsDeactivate.Length;i++){

            pickupsDeactivate[i].gameObject.SetActive(false);
        }


        for(int i = 0;i<pickups.Length;i++){
            if(pickups[i].isCollectible){
            if(pickups[i].transform.position.x>CheckpointController.instance.spawnPoint.x){
                pickups[i].gameObject.SetActive(true);
            }
            }else{
                pickups[i].gameObject.SetActive(true);
            }

        }
    }



}
