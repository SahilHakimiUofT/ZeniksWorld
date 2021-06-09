using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Trap_Basic : MonoBehaviour
{
    public List<GameObject> falseFloors;
 
   public Trap_Basic instance; 
 
   
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
 
    private void OnTriggerEnter2D(Collider2D other){
        Debug.Log("Hema");
 
        if(other.tag == "Player"){
            
            for(int i =0; i<falseFloors.Count;i++){
                falseFloors[i].gameObject.SetActive(false);
            }
        }
 
    }
 
 
    public void resetTrap(){
        for(int i =0; i<falseFloors.Count;i++){
                falseFloors[i].gameObject.SetActive(true);
            }
    }
}
