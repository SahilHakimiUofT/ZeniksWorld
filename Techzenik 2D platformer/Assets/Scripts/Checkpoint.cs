using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Sprite cpOn,cpOff;
    public SpriteRenderer theSR;
    public bool newMethod;
    public int checkNum;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
         
         if(other.tag == "Player"){

             if(!newMethod){
             CheckpointController.instance.DeactivateCheckpoints(transform.position);
       //FindObjectOfType<PlayerHealthController>().DealDamage();
             
             if(CheckpointController.instance.ActivateCheckpoint(transform.position)){
                 theSR.sprite = cpOn;
                 CheckpointController.instance.SetSpawnPoint(transform.position);
                 LevelManager.instance.collectibleToCheckpoint = LevelManager.instance.collectibleCollected;
             }

             }else{
                 CheckpointController.instance.DeactivateCheckpointsNew(checkNum);
                 if(CheckpointController.instance.ActivateCheckpointNew(checkNum)){
                 theSR.sprite = cpOn;
                 CheckpointController.instance.SetSpawnPoint(transform.position);
                 LevelManager.instance.collectibleToCheckpoint = LevelManager.instance.collectibleCollected;
             }

             }
             
        }
    }

    public void ResetCheckpoint(){
        theSR.sprite = cpOff;
    }
}
