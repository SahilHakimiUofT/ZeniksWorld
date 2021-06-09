using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerRevamp : MonoBehaviour
{

    public static PlayerControllerRevamp instance;

    public float moveSpeed;
    public Rigidbody2D theRB;
    public float jumpForce;
    
    private bool isGrounded;
    public Transform groundCheckPoint;
    public LayerMask whatIsGround;

    private bool canDoubleJump;

    private Animator anim; 
    private SpriteRenderer theSR;


    public float knockBackLength,knockBackForce;
    private float knockBackCounter;

    public bool isHurt;

    public float bounceForce;

    public bool stopInput;

    void Awake(){
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        anim=GetComponent<Animator>();
        theSR=GetComponent<SpriteRenderer>();
        isHurt = false;
    }

    // Update is called once per frame
    void Update()
    {
    if(!PauseMenu.instance.isPaused && !stopInput)
    {
        if(knockBackCounter<=0){
        isHurt = false;
        theRB.velocity = new Vector2(moveSpeed*Input.GetAxisRaw("Horizontal"),theRB.velocity.y);

        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position,.2f,whatIsGround);

        if(isGrounded)
        {
            canDoubleJump = true;
        }



        if(Input.GetButtonDown("Jump"))
        {

        if(isGrounded)
        {
            theRB.velocity = new Vector2(theRB.velocity.x,jumpForce);
        }
            else
            {
                if(canDoubleJump)
                {

                    theRB.velocity = new Vector2(theRB.velocity.x,jumpForce);
                    canDoubleJump = false;
                }
            }


        }
if(theRB.velocity.x<0)
{
theSR.flipX =true;
}else if(theRB.velocity.x>0)
{
theSR.flipX =false;
}
        }
        else{
            knockBackCounter-=Time.deltaTime;
            
        }
    
    anim.SetBool("isGrounded",isGrounded);
    anim.SetFloat("moveSpeed",Mathf.Abs(theRB.velocity.x));
    anim.SetBool("isHurt",isHurt);
    
    
    }
    }
    public void KnockBack(){
        knockBackCounter = knockBackLength;
        isHurt = true;
         if(theSR.flipX){
                theRB.velocity = new Vector2(.75f* knockBackForce,knockBackForce);
            }else{
                theRB.velocity = new Vector2(.75f*-knockBackForce,knockBackForce);
            }
        
        
       

    }

    public void Bounce(){

        theRB.velocity = new Vector2(theRB.velocity.x,bounceForce);
    }



    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Platform"){
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
