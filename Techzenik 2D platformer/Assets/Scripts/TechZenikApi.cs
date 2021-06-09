using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;
using UnityEngine.UI;
using System.Runtime.InteropServices;
using System;


public class TechZenikApi : MonoBehaviour
{

      [DllImport("__Internal")]
  private static extern string getUserName();
  
  
  public string user_Name;

//private readonly string zenikApiURL = "https://test.playzenik.com";
private readonly string zenikApiURL = "http://localhost:8000";
    // Start is called before the first frame update
    void Start()
    {
        
        //user_Name = getUserName();
        //Debug.Log(user_Name);
        
        getUserScore("yanu23",10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


public void getUserScore(string user_name, int additionalScore){
    StartCoroutine(userScoreWebRequest(user_name,additionalScore));
}

   IEnumerator userScoreWebRequest(string user_name,int additionalScore){
        string getScoreUrl = zenikApiURL + "/user/"+user_name+"/user-profile";

        UnityWebRequest userInfoRequest = UnityWebRequest.Get(getScoreUrl);

        yield return userInfoRequest.SendWebRequest();

        if(userInfoRequest.isNetworkError || userInfoRequest.isHttpError){
            Debug.Log("ERROR");
             yield break;
        }

        JSONNode userInfo = JSON.Parse(userInfoRequest.downloadHandler.text);
       
        string score = userInfo["userprofile"]["play_score"];
        Debug.Log(score);
        int currentScore = -1;
        

        if(!Int32.TryParse(score,out currentScore)){
            Debug.Log("ERROR");
            yield break;

        }
        string newScore = (currentScore + additionalScore).ToString();
        
        string updateScoreURL =  zenikApiURL + "/user/" + user_name+ "/playscore=" + newScore;
        UnityWebRequest updateScoreRequest = UnityWebRequest.Get(updateScoreURL);
        updateScoreRequest.method = "PATCH";

        yield return updateScoreRequest.SendWebRequest();

         if(updateScoreRequest.isNetworkError ||updateScoreRequest.isHttpError){
            Debug.Log("ERROR");
             yield break;
        }

    }
}
