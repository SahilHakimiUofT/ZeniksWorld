using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bossLevelCounter : MonoBehaviour


{

  public static bossLevelCounter instance;
  public Slider slider; 
  public int maxHealth;
  public int currentHealth;

    void Awake(){
        instance = this; 
        SetMaxHealth(maxHealth);
        currentHealth = maxHealth;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SetMaxHealth(int health){
        slider.maxValue = health;
        slider.value = health; 
    }
    public void SetHealth(int health){
            slider.value = health;

            if(currentHealth == 0){
                WallBossEnd.instance.wallUp();
            }
    }


}
