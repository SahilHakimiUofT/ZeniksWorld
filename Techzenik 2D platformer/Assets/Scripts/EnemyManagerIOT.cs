using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManagerIOT : MonoBehaviour
{
    public List<Transform>[] enemiesPoints;
    private LaptopController[] laptop;
    private PhoneController[] phone;
    public static EnemyManagerIOT instance;
    public int numOfLaptops;
    public int numOfPhones;
    public GameObject enemyPhone;
    public GameObject enemyLaptop;

     void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
         laptop = FindObjectsOfType<LaptopController>();
         phone = FindObjectsOfType<PhoneController>();
         numOfLaptops = laptop.Length;
         numOfPhones = phone.Length;
         enemiesPoints = new List<Transform>[laptop.Length+phone.Length];
              
         for(int i = 0;i<laptop.Length+phone.Length;i++){
             if(i < laptop.Length){
                 enemiesPoints[i] = laptop[i].points;
             }
              else{
                  enemiesPoints[i] = phone[i-(laptop.Length)].points;
              
             
            }
         }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RespawnEnemies(){

      PhoneController[] phonesDestroy = FindObjectsOfType<PhoneController>();
      LaptopController[] laptopsDestroy = FindObjectsOfType<LaptopController>();
     for(var i = 0 ; i < phonesDestroy.Length ; i ++)
     {
        
         Destroy(phonesDestroy[i].gameObject);
        

     }

     for(var i = 0 ; i < laptopsDestroy.Length ; i ++)
     {
        
         Destroy(laptopsDestroy[i].gameObject);
        

     }


        for(int i = 0; i<enemiesPoints.Length;i++){  
           if(i< numOfLaptops){
                GameObject enemyObj = (GameObject) Instantiate(enemyLaptop,enemiesPoints[i][0].position,Quaternion.Euler(0f,0f,0f));
                LaptopController enemy = enemyObj.GetComponent<LaptopController>();
                enemy.points = enemiesPoints[i];

               
            }else if (i< numOfPhones+numOfLaptops){
                GameObject enemyObj = (GameObject) Instantiate(enemyPhone,enemiesPoints[i][0].position,Quaternion.Euler(0f,0f,0f));
                PhoneController enemy = enemyObj.GetComponent<PhoneController>();
                enemy.points = enemiesPoints[i];
               
         
           
        }

    }
    }


}
