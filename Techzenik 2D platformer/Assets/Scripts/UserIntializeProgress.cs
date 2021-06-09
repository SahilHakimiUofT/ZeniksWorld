using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;
using UnityEngine.UI;
using System.Runtime.InteropServices;
using System;

public class UserIntializeProgress : MonoBehaviour
{
    //private readonly string zenikApiURL = "https://test.playzenik.com";
    private readonly string zenikApiURL = "https://prod-server.playzenik.com";


    
      [DllImport("__Internal")]
private static extern string getUserName();
  
  
  public string user_Name;
   // private readonly string zenikApiURL = "http://localhost:8000";

    // Start is called before the first frame update
    void Start()
    {

     string username= getUserName();
     unlockLevels(username);
       // Debug.Log(username);
        //unlockLevels("yanu23");
        //unlockLevels("yanu23");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

public void unlockLevels(string user_name){
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
        
        if(currentLevel<101){
            currentLevel = 101;

            string updateLevelProgressURL =  zenikApiURL + "/user/" + user_name+ "/playlevel=101";
            UnityWebRequest updateLevelRequest = UnityWebRequest.Get(updateLevelProgressURL);
            updateLevelRequest.method = "PATCH";

        yield return updateLevelRequest.SendWebRequest();

         if(updateLevelRequest.isNetworkError ||updateLevelRequest.isHttpError){
            Debug.Log("ERROR");
             yield break;
        }

        }
        Debug.Log(currentLevel);
        MapPoint[] levels =  FindObjectsOfType<MapPoint>();
     
            for(int i = 0; i<levels.Length;i++){
                if(levels[i].levelNum <= currentLevel && levels[i].levelNum>0 ){
                    Debug.Log("unloccking");
                    levels[i].isLocked = false;
                    levels[i].unlockLevel();
                    
                }
            }
   
   
   
   
    }
}



