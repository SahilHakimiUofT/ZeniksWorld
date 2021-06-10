using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallClimb : MonoBehaviour
{

    public float climbSpeed;
    public bool ground;
    public bool wall;
    public bool rightWall;
    public bool leftWall;
    public float collisionRadius;
    public Vector2 rightWallOffset;
    public Vector2 leftWallOffset;
    public Vector2 groundOffset;
    public int side;



    // Start is called before the first frame update
    void Start()
    {
        
    
    }
    // Update is called once per frame
    void Update()
    {

        //ground = Physics2D.OverlapCircle((Vector 2)transform.position + groundOffset, collisionRadius);
        //wall = Physics2D.OverlapCircle((Vector 2)transform.position + rightWallOffset, collisionRadius) || Physics2D.OverlapCircle((Vector 2)transform.position + leftWallOffset, collisionRadius);
        
    }
}
