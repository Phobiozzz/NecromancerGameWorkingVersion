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

    private void Move()
    {
        directionX = CrossPlatformInputManager.GetAxis("Horizontal") * characterMoveSpeed * Time.deltaTime;
        
        transform.position = new Vector2(transform.position.x + directionX, transform.position.y);

        if (directionX < 0)
        {
            lookingRight = false;
            //transform.GetComponent<SpriteRenderer>().flipX = true;
            transform.rotation = Quaternion.Euler(0, 180, 0);
            
        }
        else if(directionX > 0)
        {
            
            lookingRight = true;
            //transform.GetComponent<SpriteRenderer>().flipX = false;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    // Start is called before the first frame update
    void Start() {
        lookingRight = true;
       rb = transform.GetComponent<Rigidbody2D>();
       characterMoveSpeed = 1f;
	}


	// Update is called once per frame
	void FixedUpdate()
    {
        Move();
       
        isGrounded = Physics2D.OverlapCircle(groundChek.position, chekRadius, whatIsGround);
       
        
    }

    private void Jump()
    {
        if (CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            if (isGrounded == true)
            {
                rb.velocity = Vector2.up * jumpPower;
            }

        }

    }

    private void Update()
    {

        Jump();
    }
}
