using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;


public class NewBehaviourScript : MonoBehaviour
{
   
    [DllImport("__Internal")]
  private static extern void Hello();

  void Awake(){
      
  }
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
