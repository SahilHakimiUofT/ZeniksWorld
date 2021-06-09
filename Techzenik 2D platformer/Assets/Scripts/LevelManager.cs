using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using SimpleJSON;
using System.Runtime.InteropServices;
using System;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public string theme;
    public static LevelManager instance;
    public float waitToRespawn;
    public string levelToLoad;
    public int collectibleCollected;
    public int collectibleToCheckpoint;
    public int levelNum;
    public int nextLevel;
    public Text collectedText;
    public Text bonusText;
    public Text overallScoreText;

    public bool hasBoss;
   // private readonly string zenikApiURL = "https://test.playzenik.com";
    private readonly string zenikApiURL = "https://prod-server.playzenik.com";
    public GameObject scoreScreen;
   
    public int levelBonus;
    public bool BossLevel;


    //private readonly string zenikApiURL = "http://localhost:8000";

     [DllImport("__Internal")]
  private static extern string getUserName();

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

    public void RespawnPlayer(){
            StartCoroutine(RespawnCo());
    }

    private IEnumerator RespawnCo()
    {
        PlayerController.instance.gameObject.SetActive(false);
        
        yield return new WaitForSeconds(waitToRespawn-(1f / UIController.instance.fadeSpeed));

        UIController.instance.FadeToBlack();

        yield return new WaitForSeconds((1f/UIController.instance.fadeSpeed) + .2f);

        UIController.instance.FadeFromBlack();

        PlayerController.instance.gameObject.SetActive(true);
        PlayerController.instance.transform.position = CheckpointController.instance.spawnPoint;
        PlayerHealthController.instance.currentHealth = PlayerHealthController.instance.maxHealth;
        LevelManager.instance.collectibleCollected = LevelManager.instance.collectibleToCheckpoint;
        PlayerController.instance.slowTimer = 0f;
        PickupManager.instance.RespawnPickups();
        if(theme == "animal"){
        EnemyManager.instance.RespawnEnemies();
        }else if(theme == "electricity"){
        EnemyManagerElectricity.instance.RespawnEnemies();
        }
        else if(theme == "magnetism"){
            EnemyManagerMagnetism.instance.RespawnEnemies();
            TrapManager.instance.resetAllTraps();
        }
        else if(theme == "IOT"){
            EnemyManagerIOT.instance.RespawnEnemies();
            TrapManager.instance.resetAllTraps();
            if(hasBoss){
                StartBossFight.instance.resetFight();
            }
        }

        UIController.instance.UpdateHealthDisplay();
        UIController.instance.UpdateCollectibleCount();
        if(BossLevel){
            BossManager.instance.RespawnBoss();
           
        }
        

    }
    public void EndLevel()
    {
        StartCoroutine(EndLevelCo());
    }

    public IEnumerator EndLevelCo()
    {
       //updateProgress("yanu23",levelBonus + (collectibleCollected*10));
       updateProgress(getUserName(),levelBonus + (collectibleCollected*10));
        PlayerController.instance.stopInput = true;
        
        CameraController.instance.stopFollow = true;
        
        UIController.instance.levelCompleteText.SetActive(true);
        collectedText.text = collectibleCollected.ToString();
        bonusText.text = levelBonus.ToString();
        string overallLine = collectibleCollected + "X10 + " + levelBonus + " = " + ((collectibleCollected*10)+levelBonus);
        overallScoreText.text = overallLine;
        
        yield return new WaitForSeconds(1.5f);
        
        UIController.instance.FadeToBlack();

        yield return new WaitForSeconds((1f/ UIController.instance.fadeSpeed)*.25f);
        
        scoreScreen.SetActive(true);
        //PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_unlocked",1);


        //SceneManager.LoadScene(levelToLoad);

    }

public void updateProgress(string user_name, int additionalScore){
    StartCoroutine(userProgressWebRequest(user_name,additionalScore));
}

   IEnumerator userProgressWebRequest(string user_name,int additionalScore){
        string getScoreUrl = zenikApiURL + "/user/"+user_name+"/user-profile";

        UnityWebRequest userInfoRequest = UnityWebRequest.Get(getScoreUrl);

        yield return userInfoRequest.SendWebRequest();

        if(userInfoRequest.isNetworkError || userInfoRequest.isHttpError){
            Debug.Log("ERROR");
             yield break;
        }

        JSONNode userInfo = JSON.Parse(userInfoRequest.downloadHandler.text);
       
        string play_score = userInfo["userprofile"]["play_score"];
        string overall_score = userInfo["userprofile"]["score"];
        string levelProgress = userInfo["userprofile"]["play_level"];
       
        int currentPlayScore = -1;
        int currentOverallScore = -1;
        int currentLevel = -1;
        

        if(!Int32.TryParse(play_score,out currentPlayScore)){
            Debug.Log("ERROR");
            yield break;

        }
        if(!Int32.TryParse(overall_score,out currentOverallScore)){
            Debug.Log("ERROR");
            yield break;

        }

         if(!Int32.TryParse(levelProgress,out currentLevel)){
            Debug.Log("ERROR");
            yield break;

        }

        Debug.Log("Im on " + currentLevel);


        string newPlayScore = (currentPlayScore + additionalScore).ToString();
         string newOverallScore = (currentOverallScore+ additionalScore).ToString();



        
        string updatePlayScoreURL =  zenikApiURL + "/user/" + user_name+ "/playscore=" + newPlayScore;
        string updateOverallScoreURL =  zenikApiURL + "/user/" + user_name+ "/score=" + newOverallScore;
       


        UnityWebRequest updatePlayScoreRequest = UnityWebRequest.Get(updatePlayScoreURL);
        updatePlayScoreRequest.method = "PATCH";

        yield return updatePlayScoreRequest.SendWebRequest();

         if(updatePlayScoreRequest.isNetworkError ||updatePlayScoreRequest.isHttpError){
            Debug.Log("ERROR");
             yield break;
        }

        UnityWebRequest updateOverallScoreRequest = UnityWebRequest.Get(updateOverallScoreURL);
        updateOverallScoreRequest.method = "PATCH";
        
        yield return updateOverallScoreRequest.SendWebRequest();
        
         if(updateOverallScoreRequest.isNetworkError ||updateOverallScoreRequest.isHttpError){
            Debug.Log("ERROR");
             yield break;
        }



//Debug.Log("here?");

    if(currentLevel<=levelNum){
           // Debug.Log("MAYBE?");
        string updateLevelProgressURL =  zenikApiURL + "/user/" + user_name+ "/playlevel="+this.nextLevel.ToString();
            UnityWebRequest updateLevelRequest = UnityWebRequest.Get(updateLevelProgressURL);
            updateLevelRequest.method = "PATCH";

        yield return updateLevelRequest.SendWebRequest();
//Debug.Log("this one");
         if(updateLevelRequest.isNetworkError ||updateLevelRequest.isHttpError){
            Debug.Log("ERROR");
             yield break;
        }




    }





    }




}
