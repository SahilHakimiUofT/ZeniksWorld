using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBossEnd : MonoBehaviour


{
    public static WallBossEnd instance;

    

     private Animator anim;

     void Awake(){
         instance = this;
     }
    // Start is called before the first frame update
    void Start()
    {
         anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void wallUp(){
        anim.SetTrigger("bossDeath");
    }
}
