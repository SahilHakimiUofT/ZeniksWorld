using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurret : MonoBehaviour
{

       public GameObject projectile;
       public float shootDistance;
       public EnemyTurret instance;
       public float waitCount;
       public float waitTime;
       public Transform firePoint;
       public bool FacingRight;

  void Awake(){
        instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
         waitCount = waitTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(waitCount>0){
            waitCount-=Time.deltaTime;
        }else if(waitCount<=0 && PlayerController.instance.transform.position.x < (transform.position.x-1f)  && Vector3.Distance(transform.position,PlayerController.instance.transform.position)<=shootDistance && !FacingRight){
            waitCount = waitTime;
              Instantiate(projectile,firePoint.position,firePoint.rotation);
        }
        else if (waitCount <= 0 && PlayerController.instance.transform.position.x > (transform.position.x - 1f) && Vector3.Distance(transform.position, PlayerController.instance.transform.position) <= shootDistance && FacingRight)
        {
            waitCount = waitTime;
            Instantiate(projectile, firePoint.position, firePoint.rotation);
        }
    }

      private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Platform"){
            Debug.Log("Asdasdsa");
            transform.parent = other.transform;
            
        }
    }


     private void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.tag == "Platform"){
            transform.parent = null;
        }
    }




}
