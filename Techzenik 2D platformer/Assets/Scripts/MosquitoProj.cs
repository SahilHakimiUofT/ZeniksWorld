using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosquitoProj : MonoBehaviour
{
    public float speed = 10f;
    public bool slowDown;
    public Rigidbody2D theRB;
    // Start is called before the first frame update
    void Start()
    {
     theRB.velocity = (PlayerController.instance.transform.position - transform.position).normalized * speed;   
     Vector2 v = theRB.velocity;
    float angle = Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;
    transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            PlayerHealthController.instance.DealDamage(1);
            if(slowDown){
                PlayerController.instance.slowDown();
            }
        }
        Debug.Log(other.tag);
        if(other.tag == "Player" || other.tag == "Solids"){
        Destroy(gameObject);
        }
        
    }
}
