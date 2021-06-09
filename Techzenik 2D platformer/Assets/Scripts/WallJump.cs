using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallJump : MonoBehaviour
{

    PlayerController movingSpeed;
    public float speed=2f;
	bool walljumping;
    public float distance = 1f;

    // Start is called before the first frame update
    void Start()
    {
        movingSpeed = GetComponent<PlayerController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Physics2D.queriesStartInColliders = false;
		RaycastHit2D hit = Physics2D.Raycast(transform.position,Vector2.right*transform.localScale.x,distance);


		if (Input.GetKeyDown (KeyCode.Space) && !movingSpeed.isGrounded && hit.collider != null) {
						{
								//movingSpeed.outsideForce = true;
								GetComponent<Rigidbody2D> ().velocity = new Vector2 (speed * hit.normal.x, speed);

								//StartCoroutine ("TurnIt");

						}
		
				}
        
    }
}
