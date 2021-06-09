using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManagerElectricity : MonoBehaviour
{
   public List<Transform>[] enemiesPoints;
   private EnemyController[] enemies;
   
   private string[] type;
    public static EnemyManagerElectricity instance;
   
    
    public GameObject enemySocket;
    public GameObject enemyBattery;
    public GameObject enemyPlug;
    
    

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
           if(type[i] == "Socket"){
                  GameObject enemyObj = (GameObject) Instantiate(enemySocket,enemiesPoints[i][0].position,Quaternion.Euler(0f,0f,0f));
                  EnemyController enemy = enemyObj.GetComponent<EnemyController>();
                   enemy.points = enemiesPoints[i];
            }else if(type[i] == "Battery"){
                GameObject enemyObj = (GameObject) Instantiate(enemyBattery,enemiesPoints[i][0].position,Quaternion.Euler(0f,0f,0f));
                EnemyController enemy = enemyObj.GetComponent<EnemyController>();
                   enemy.points = enemiesPoints[i];
            }else if(type[i] == "Plug"){
                 GameObject enemyObj = (GameObject)Instantiate(enemyPlug,enemiesPoints[i][0].position,Quaternion.Euler(0f,0f,0f));
                EnemyController enemy = enemyObj.GetComponent<EnemyController>();
                   enemy.points = enemiesPoints[i];
                   
           
        }

    }
    }



}
