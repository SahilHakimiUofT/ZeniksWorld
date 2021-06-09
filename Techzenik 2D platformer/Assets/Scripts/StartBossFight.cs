using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBossFight : MonoBehaviour
{

    public GameObject HealthBar;
    public GameObject bossText;
    public GameObject boss;
    public Transform spawnPoint;
    public bool startFight;

    public static StartBossFight instance;


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

    private void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            HealthBar.SetActive(true);
              bossText.SetActive(true);
              if(!startFight){
              WallBossStart.instance.wallUp();
              startFight = true;
              }

        }
    }



     private void OnTriggerExit2D(Collider2D other){
        if(other.tag == "Player"){
            
              WallBossStart.instance.wallDown();

        }
    }

    public void resetFight(){


if(HealthBar.activeSelf){
         IOTInitialBoss bossDestroy = FindObjectOfType<IOTInitialBoss>();
     
        if(bossDestroy != null){
         Destroy(bossDestroy.gameObject);
        }


         IOTBossX2 [] bossDestroyX2 = FindObjectsOfType<IOTBossX2>();
     
     for(int i = 0; i<bossDestroyX2.Length; i++){
        if(bossDestroyX2[i] != null){
         Destroy(bossDestroyX2[i].gameObject);
        }
     }


     IOTBossX3 [] bossDestroyX3 = FindObjectsOfType<IOTBossX3>();
     
     for(int i = 0; i<bossDestroyX3.Length; i++){
        if(bossDestroyX3[i] != null){
         Destroy(bossDestroyX3[i].gameObject);
        }
     }
        
         bossLevelCounter.instance.currentHealth =  bossLevelCounter.instance.maxHealth;
         bossLevelCounter.instance.SetHealth( bossLevelCounter.instance.currentHealth);
         GameObject enemyObj = (GameObject)Instantiate(boss,spawnPoint.position,Quaternion.Euler(0f,0f,0f));

           HealthBar.SetActive(false);
            bossText.SetActive(false);
              startFight = false;
        
        

}
     }


     public void beatBossFight(){

     }
    }

