using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Runtime.InteropServices;
using System;
using UnityEngine.Networking;
using SimpleJSON;

public class MainMenu : MonoBehaviour
{
    public string startScene;
     public Text lockedText;
     public int levelNum;
     public bool isWorldSelect;
   // private readonly string zenikApiURL = "https://test.playzenik.com";
    private readonly string zenikApiURL = "https://prod-server.playzenik.com";


     [DllImport("__Internal")]
    private static extern string getUserName();

    // Start is called before the first frame update
    void Start()
    {
        if(isWorldSelect){
        unlockWorlds(getUserName());
       // unlockWorlds("yanu23");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame(){
        SceneManager.LoadScene("FInalLevel1-1");
    }

    public void QuitGame(){
        Application.Quit();
        Debug.Log("Quitting Game");
    }

    public void WorldSelect(){
        SceneManager.LoadScene("World_Select");
    }

     public void AnimalWorld(){
         if(isWorldSelect){
           lockedText.gameObject.SetActive(false);
         }
        SceneManager.LoadScene("LevelSelect");
    }
     public void ElectricityWorld(){
         if(levelNum>=201){
              lockedText.gameObject.SetActive(false);
        SceneManager.LoadScene("LevelSelect 2");
         }else{
               lockedText.gameObject.SetActive(true);
         }
    }

    public void MagnetismWorld(){
         if(levelNum>=301){
              lockedText.gameObject.SetActive(false);
        SceneManager.LoadScene("LevelSelect 3");
         }else{
               lockedText.gameObject.SetActive(true);
         }
    }

     public void IOT(){
         if(levelNum>=401){
              lockedText.gameObject.SetActive(false);
        SceneManager.LoadScene("LevelSelect 4");
         }else{
               lockedText.gameObject.SetActive(true);
         }
    }

    public void unlockWorlds(string user_name){
    StartCoroutine(userProgressWebRequest(user_name));
}

   IEnumerator userProgressWebRequest(string user_name){
        
        
        string getLevelUrl = zenikApiURL + "/user/"+user_name+"/user-profile";

        UnityWebRequest userInfoRequest = UnityWebRequest.Get(getLevelUrl);

        yield return userInfoRequest.SendWebRequest();

        if(userInfoRequest.isNetworkError || userInfoRequest.isHttpError){
            Debug.Log("ERROR");
             yield break;
        }

        JSONNode userInfo = JSON.Parse(userInfoRequest.downloadHandler.text);
       
        string level = userInfo["userprofile"]["play_level"];
        Debug.Log(level);
        int currentLevel = -1;
        

        if(!Int32.TryParse(level,out currentLevel)){
            Debug.Log("ERROR");
            yield break;

        }
        
        levelNum = currentLevel;
    }





}
