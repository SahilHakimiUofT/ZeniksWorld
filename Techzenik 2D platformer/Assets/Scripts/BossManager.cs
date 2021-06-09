using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour
{

     public GameObject bossPlug;

     public List<Transform>[] bossPoints;
   private  BossController[] boss;
   public static BossManager instance;
   public float waitToRespawn;
   


void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
            boss = FindObjectsOfType<BossController>();
        bossPoints = new List<Transform>[boss.Length];
           
         for(int i = 0;i<boss.Length;i++){

             bossPoints[i] = boss[i].points;
          
          }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void RespawnBoss(){
        BossController[] bossDestroy = FindObjectsOfType<BossController>();
     
     for(var i = 0 ; i < bossDestroy.Length ; i ++)
     {
        
         Destroy(bossDestroy[i].gameObject);
        

     }
    for(int i = 0; i<bossPoints.Length;i++){  
                 
                  GameObject enemyObj = (GameObject) Instantiate(bossPlug,bossPoints[i][0].position,Quaternion.Euler(0f,0f,0f));
                  BossController enemy = enemyObj.GetComponent<BossController>();
                   enemy.points = bossPoints[i];
    
    
    }
    }
}
