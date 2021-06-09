using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
   public List<Transform>[] enemiesPoints;
   private EnemyController[] enemies;
   private EnemyEagleController[] flyingEnemies;
   public List<Transform>[] eaglePoints;
   private MoquitoController[] enemyMosquitos;
   public List<Transform>[] mosquitoPoints;

   private string[] type;
    public static EnemyManager instance;
    public GameObject enemyFrog;
    /*
    public GameObject enemySocket;
    public GameObject enemyBattery;
    public GameObject enemyPlug;
    */
    public GameObject enemyPossum;
    public GameObject enemyEagle;
    public GameObject enemyMosquito;

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

          flyingEnemies = FindObjectsOfType<EnemyEagleController>();
         
          eaglePoints =  new List<Transform>[flyingEnemies.Length];
          for(int i = 0; i<flyingEnemies.Length;i++){
              eaglePoints[i] = flyingEnemies[i].points;
          }
          

          enemyMosquitos = FindObjectsOfType<MoquitoController>();
             mosquitoPoints =  new List<Transform>[enemyMosquitos.Length];
          for(int i = 0; i<enemyMosquitos.Length;i++){
              mosquitoPoints[i] = enemyMosquitos[i].points;
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
            if(type[i] == "Frog"){
             GameObject enemyObj = (GameObject)Instantiate(enemyFrog,enemiesPoints[i][0].position,Quaternion.Euler(0f,0f,0f));
             EnemyController enemy = enemyObj.GetComponent<EnemyController>();
             enemy.points = enemiesPoints[i];
            }/*
            else if(type[i] == "Socket"){
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
                   */
             else if(type[i] == "Possum"){


                   GameObject enemyObj = (GameObject)Instantiate(enemyPossum,enemiesPoints[i][0].position,Quaternion.Euler(0f,0f,0f));
                   EnemyController enemy = enemyObj.GetComponent<EnemyController>();
                   enemy.points = enemiesPoints[i];
            }
        }


    EnemyEagleController[] flyingEnemiesDestroy = FindObjectsOfType<EnemyEagleController>();
     for(var i = 0 ; i < flyingEnemiesDestroy.Length ; i ++)
     {
         
         Destroy(flyingEnemiesDestroy[i].gameObject);
     }


     for(int i = 0; i<eaglePoints.Length;i++){  
            
            GameObject enemyObj = (GameObject) Instantiate(enemyEagle,eaglePoints[i][0].position,Quaternion.Euler(0f,0f,0f));
            EnemyEagleController enemy = enemyObj.GetComponent<EnemyEagleController>();
            enemy.points = eaglePoints[i];
          
        }



         MoquitoController[] mosquitosDestroy = FindObjectsOfType<MoquitoController>();
     for(var i = 0 ; i < mosquitosDestroy.Length ; i ++)
     {
         
         Destroy(mosquitosDestroy[i].gameObject);
     }


     for(int i = 0; i<mosquitoPoints.Length;i++){  
            
            GameObject enemyObj = (GameObject) Instantiate(enemyMosquito,mosquitoPoints[i][0].position,Quaternion.Euler(0f,0f,0f));
            MoquitoController enemy = enemyObj.GetComponent<MoquitoController>();
            enemy.points = mosquitoPoints[i];
          
        }
    }

}
