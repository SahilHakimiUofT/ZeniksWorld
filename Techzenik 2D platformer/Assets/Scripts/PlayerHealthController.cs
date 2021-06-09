using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public int currentHealth, maxHealth;
    public static PlayerHealthController instance;
    public float invincibilityLength;
    private float invincibilityCounter;
    private SpriteRenderer theSR;
    public GameObject deathEffect;
    void Awake(){
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        theSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(invincibilityCounter>0){
            invincibilityCounter-=Time.deltaTime;
            if(invincibilityCounter<=0){
                theSR.color = new Color(theSR.color.r,theSR.color.g,theSR.color.b,1f);
            }
        }
    }

    public void  DealDamage(int damage){
        //currentHealth-=1;
        if(invincibilityCounter<=0)
        {
      
        currentHealth-=damage;
        if(currentHealth<=0){
             PlayerController.instance.isDashing = false;
             PlayerController.instance.direction = 0;
           PlayerController.instance.dashCount = PlayerController.instance.startDashCount;
            //gameObject.SetActive(false);
            Instantiate(deathEffect,transform.position,transform.rotation);
            LevelManager.instance.RespawnPlayer();
        }else{
        
             PlayerController.instance.dashCount = PlayerController.instance.startDashCount;
             PlayerController.instance.theRB.velocity = Vector2.zero;
             PlayerController.instance.isDashing = false;
             PlayerController.instance.direction = 0;

            invincibilityCounter = invincibilityLength;
            theSR.color = new Color(theSR.color.r,theSR.color.g,theSR.color.b,.5f);
            PlayerController.instance.KnockBack();
        }
        UIController.instance.UpdateHealthDisplay();
    }
    }
    public void HealPlayer(){
        if(currentHealth<maxHealth){
        currentHealth++;
        UIController.instance.UpdateHealthDisplay();
        }
    }


    public void KillPlayerBoss(){
         currentHealth-=3;
        
            Instantiate(deathEffect,transform.position,transform.rotation);
            LevelManager.instance.RespawnPlayer();
      
            UIController.instance.UpdateHealthDisplay();
            


    }

    public void setInivincibility(float time){
            invincibilityCounter = time;
    }

}
