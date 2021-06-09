using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;

public class UIController : MonoBehaviour
{
    public static UIController instance;
    public Image heart1,heart2,heart3;
    public Sprite heartFull,heartEmpty;
    public Text collectibleText;
    public Image fadeScreen;
    public float fadeSpeed;
    private bool shouldFadeFromBlack;
    private bool shouldFadeToBlack;
    public GameObject levelCompleteText;

/*
   [DllImport("__Internal")]
  private static extern void setCookie();
  */

    void Awake(){
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
    
    UpdateCollectibleCount();
    FadeFromBlack();
    UpdateHealthDisplay();
    
       
    }

    // Update is called once per frame
    void Update()
    {
        if(shouldFadeToBlack)
        {
            fadeScreen.color = new Color(fadeScreen.color.r,fadeScreen.color.g,fadeScreen.color.b,Mathf.MoveTowards(fadeScreen.color.a, 1f, fadeSpeed * Time.deltaTime));
            if(fadeScreen.color.a == 1f)
            {
                shouldFadeToBlack = false;
            }
        
        }
        if(shouldFadeFromBlack)
        {
            fadeScreen.color = new Color(fadeScreen.color.r,fadeScreen.color.g,fadeScreen.color.b,Mathf.MoveTowards(fadeScreen.color.a, 0f, fadeSpeed * Time.deltaTime));
            if(fadeScreen.color.a == 0f)
            {
                shouldFadeFromBlack = false;
            }
        }
    }

    public void UpdateHealthDisplay(){
        switch(PlayerHealthController.instance.currentHealth){
            case 3:
                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                heart3.sprite = heartFull;
                break;
            case 2:
                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                heart3.sprite = heartEmpty;
                break;
            case 1:
                heart1.sprite = heartFull;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;
                break;
            case 0:
                heart1.sprite = heartEmpty;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;
                break;
            default:
                heart1.sprite = heartEmpty;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;
                break;

        }
    }

    public void UpdateCollectibleCount()
    {
        collectibleText.text = LevelManager.instance.collectibleCollected.ToString();
    }
    public void FadeToBlack()
    {
        shouldFadeToBlack = true;
        shouldFadeFromBlack = false;
    }

      public void FadeFromBlack()
    {
        shouldFadeToBlack = false;
        shouldFadeFromBlack = true;
    }
}
