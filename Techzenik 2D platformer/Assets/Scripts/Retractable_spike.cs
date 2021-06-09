using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Retractable_spike : MonoBehaviour
{
    public float up_time;
    public float down_time;
    public bool start_down;
    public float counter;

    private bool is_retracted;
     private Animator anim; 

      public Retractable_spike instance;

      void Awake(){
          instance = this;
      }


    // Start is called before the first frame update
    void Start()
    {
         anim=GetComponent<Animator>();
         if(start_down){
         counter = down_time;
          anim.SetTrigger("retract");
          is_retracted = true;
         }else{
             counter = up_time;
         }
    }

    // Update is called once per frame
    void Update()
    {
        if(counter>0){
            counter -= Time.deltaTime;
        }else{
            if(is_retracted){
                is_retracted = false;
                counter = up_time;
                anim.SetTrigger("extend");

            }else{
                 is_retracted = true;
                counter = down_time;
                anim.SetTrigger("retract");
            }
        }
    }
}
