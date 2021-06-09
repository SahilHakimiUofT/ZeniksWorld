using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutTexTrigger : MonoBehaviour
{

    public Text tutorialText;
    public string tutorialLine;
    private float delay = 0.05f;
    private string currentText = "";
    public bool seenBefore;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      if(PauseMenu.instance.isPaused){
          tutorialText.gameObject.SetActive(false);
      }else{
           tutorialText.gameObject.SetActive(true);
      }
    }

    IEnumerator ShowText()
    {
        for(int i = 0;i<tutorialLine.Length;i++){
            currentText = tutorialLine.Substring(0,i+1);
            tutorialText.text = currentText;
            yield return new WaitForSeconds(delay);
        }
    }


    private void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player" ){
        if(!seenBefore)
        StartCoroutine(ShowText());
        seenBefore = true;
        }

    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Player"){
        tutorialText.text = "";
        }
    }

}
