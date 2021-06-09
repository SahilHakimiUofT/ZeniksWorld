using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    private Checkpoint[] checkpoints;
    public static CheckpointController instance;
    public Vector3 spawnPoint;

    void Awake(){
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        checkpoints = FindObjectsOfType<Checkpoint>();
        spawnPoint = PlayerController.instance.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DeactivateCheckpoints(Vector3 checkPointSpot){
        for(int i = 0; i<checkpoints.Length;i++){
            if(checkpoints[i].transform.position.x<checkPointSpot.x){
            checkpoints[i].ResetCheckpoint();
            }
        }
    }


    public bool ActivateCheckpoint(Vector3 checkPointSpot){
        
        for(int i = 0; i<checkpoints.Length;i++){
            if(checkpoints[i].transform.position.x>=checkPointSpot.x & checkpoints[i].theSR.sprite == checkpoints[i].cpOn){
                return false;
            }
        }
    return true;

    }



    public void DeactivateCheckpointsNew(int checkNum){
        for(int i = 0; i<checkpoints.Length;i++){
            if(checkpoints[i].checkNum<checkNum){
            checkpoints[i].ResetCheckpoint();
            }
        }
    }


     public bool ActivateCheckpointNew(int checkNum){
        
        for(int i = 0; i<checkpoints.Length;i++){
            if(checkpoints[i].checkNum>=checkNum & checkpoints[i].theSR.sprite == checkpoints[i].cpOn){
                return false;
            }
        }
    return true;

    }





    public void SetSpawnPoint(Vector3 newSpawnPoint){
        spawnPoint = newSpawnPoint;
    }
}
