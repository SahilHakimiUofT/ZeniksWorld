using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManagerMagnetism : MonoBehaviour
{
   public List<Transform>[] enemiesPoints;
   private EnemyController[] enemies;
   
   private string[] type;
    public static EnemyManagerMagnetism instance;
   
    
    public GameObject enemyMagnet;
    public GameObject enemyCompass;
    
    
    

   void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
       
         enemies = FindObjectsOfType<EnemyController>();
        enemiesPoints = new List<Transform>[enemies.Length];
        type = new string[enemies.Length];        
         for(int i = 0;i<enemies.Length;i++){

             enemiesPoints[i] = enemies[i].points;
             type[i] = enemies[i].type;
          }

          
          
         
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RespawnEnemies(){

      EnemyController[] enemiesDestroy = FindObjectsOfType<EnemyController>();
     
     for(var i = 0 ; i < enemiesDestroy.Length ; i ++)
     {
        
         Destroy(enemiesDestroy[i].gameObject);
        

     }


        for(int i = 0; i<enemiesPoints.Length;i++){  
           if(type[i] == "Magnet"){
                  GameObject enemyObj = (GameObject) Instantiate(enemyMagnet,enemiesPoints[i][0].position,Quaternion.Euler(0f,0f,0f));
                  EnemyController enemy = enemyObj.GetComponent<EnemyController>();
                   enemy.points = enemiesPoints[i];
            }else if(type[i] == "Compass"){
                GameObject enemyObj = (GameObject) Instantiate(enemyCompass,enemiesPoints[i][0].position,Quaternion.Euler(0f,0f,0f));
                EnemyController enemy = enemyObj.GetComponent<EnemyController>();
                   enemy.points = enemiesPoints[i];
            }

    }
    }



}
