using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MoveArrows : MonoBehaviour
{
    
    public float speed;
    public float climbingSpeed;
    public float jump;
    
    private float MovementX;
    public Rigidbody2D rb;

    public bool isGrounded;
    private bool isLadder;

    Animator animator;
    SpriteRenderer spriteRenderer; // Add this line

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        MovementX = 0;

        // Get the SpriteRenderer component
        spriteRenderer = GetComponent<SpriteRenderer>(); // Add this line
    }

    // Update is called once per frame
    void Update()
    {
        // Set velocity based on input and speed
        rb.velocity = new Vector2(MovementX * speed * Time.deltaTime, rb.velocity.y);

        // Flip the character's sprite based on movement direction
        if (MovementX < 0) // Moving left
        {
            spriteRenderer.flipX = true;
        }
        else if (MovementX > 0) // Moving right
        {
            spriteRenderer.flipX = false;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MovementX = 1; // Set movement to positive when right arrow is pressed
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MovementX = -1; // Set movement to negative when left arrow is pressed
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            MovementX = 0; // Stop movement when arrow keys are released
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded && !isLadder) 
        {
            rb.AddForce(new Vector2(0f, jump));
            isGrounded = false;
            animator.SetBool("isJumping", !isGrounded);
        }
        else if(Input.GetKey(KeyCode.UpArrow) && isLadder)
        {
            rb.velocity = new Vector2(rb.velocity.x, climbingSpeed * Time.deltaTime);
            animator.SetBool("isLadderAnimation", true);

        }
        else if(Input.GetKey(KeyCode.DownArrow) && isLadder)
        {
            rb.velocity = new Vector2(rb.velocity.x, climbingSpeed * Time.deltaTime * -1f);
            animator.SetBool("isLadderAnimation", true);
            
        }
        else if(isLadder)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }
        
        
    }

    private void FixedUpdate () {
        animator.SetFloat("xVelocity", Math.Abs(rb.velocity.x));
        animator.SetFloat("yVelocity", rb.velocity.y);

    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Floor")) {
            isGrounded = true;
            animator.SetBool("isJumping", !isGrounded);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Ladder")) {
            rb.gravityScale = 0f;
            isLadder = true;
            Debug.Log("in ladder");
        }
        

    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.CompareTag("Ladder")) {
            rb.gravityScale = 5f;
            isLadder = false;
            Debug.Log("off ladder");
            animator.SetBool("isLadderAnimation", false);

        }
    }
}
