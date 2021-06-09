using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu instance;
    public string levelSelect;
    public string mainMenu;
    public GameObject pauseScreen;
    public GameObject instructionScreen;
    public bool isPaused;
    private void Awake()
    {

        instance= this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P) && !instructionScreen.activeSelf){
            PauseUnpause();
        }
    }

    public void PauseUnpause(){
        if(isPaused){
            isPaused = false;
            pauseScreen.SetActive(false);
            Time.timeScale = 1f;
        }else{
            isPaused = true;
             pauseScreen.SetActive(true);
             Time.timeScale = 0f;
        }
    }

    public void Instructions(){
        SceneManager.LoadScene("Instructions");
        Time.timeScale = 1f;
    }

    public void MainMenu(){
        SceneManager.LoadScene("Final Main_Menu");
        Time.timeScale = 1f;
    }
    public void LSelectMenu(){
        SceneManager.LoadScene("LevelSelect");
        Time.timeScale = 1f;
    }

     public void LSelectMenuElectricity(){
        SceneManager.LoadScene("LevelSelect 2");
        Time.timeScale = 1f;
    }

    public void LSelectMenuMagnetism(){
        SceneManager.LoadScene("LevelSelect 3");
        Time.timeScale = 1f;
    }

    public void LSelectIOT(){
        SceneManager.LoadScene("LevelSelect 4");
        Time.timeScale = 1f;
    }

    public void InstructionMenu(){
        instructionScreen.SetActive(true);
    }
   
   public void InstructionMenuFalse(){
       instructionScreen.SetActive(false);
   }

 

}
