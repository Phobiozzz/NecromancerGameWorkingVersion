using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class CharacterMovement : MonoBehaviour
{
   
	private float characterMoveSpeed;
	private float directionX;
    Rigidbody2D rb;

    public bool lookingRight;

    public float jumpPower;
    public bool isGrounded;
    public Transform groundChek;
    public float chekRadius;
    public LayerMask whatIsGround;

    public GameObject Spawner;
    public Animator animator;
    public bool isJumping;
   
    private void Move()
    {
        directionX = CrossPlatformInputManager.GetAxis("Horizontal") * characterMoveSpeed * Time.deltaTime;
        
        transform.position = new Vector2(transform.position.x + directionX, transform.position.y);
        animator.SetFloat("Speed", Mathf.Abs(directionX));
        //Debug.Log(directionX);
        if (directionX < 0)
        {
            lookingRight = false;
            transform.rotation = Quaternion.Euler(0, 180, 0);
            
        }
        else if(directionX > 0)
        {

            lookingRight = true;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
       
    }

    // Start is called before the first frame update
    void Start() {
        lookingRight = true;
       rb = transform.GetComponent<Rigidbody2D>();
       characterMoveSpeed = 1f;
        animator = transform.GetComponent<Animator>();
        isGrounded = true;
       
	}


	// Update is called once per frame
	
    
    private void Jump()
    {
        isGrounded = Physics2D.OverlapCircle(groundChek.position, chekRadius, whatIsGround);
        
        if (CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            if (isGrounded == true)
            {
               
                rb.velocity = Vector2.up * jumpPower;

            }
           
        }
       

    }

    public void SpawnSomeThing()
    {

        RaycastHit2D groundInfo = Physics2D.Raycast(Spawner.transform.position, Vector2.down, 7f, whatIsGround);

        if (groundInfo.collider.tag == "Ground")
        {
           // Debug.DrawRay(Spawner.transform.localPosition, Vector2.down, Color.red, 7f);
            if (groundInfo.collider.gameObject.name == "Ground_Middle(Clone)")
            {
                //Debug.Log(groundInfo.collider.gameObject.transform.position);
                groundInfo.collider.gameObject.GetComponent<Spawn>().SpawnObject();

            }
        }

    }
    private void Update()
    {
        Move();
        Jump();
        SpawnSomeThing();


        if (isGrounded == false)
        {
            animator.SetBool("isJumping", true);
            //Debug.Log(isGrounded);
        }
        else
        {
            animator.SetBool("isJumping", false);
        }
            
    }
}
