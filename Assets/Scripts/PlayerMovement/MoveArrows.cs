using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveArrows : MonoBehaviour
{
    
    public float speed;
    public float climbingSpeed;
    public float jump;
    
    private float MovementX;
    public Rigidbody2D rb;

    public bool isJumping;
    private bool isLadder;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        MovementX = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Set velocity based on input and speed
        rb.velocity = new Vector2(MovementX * speed * Time.deltaTime, rb.velocity.y);

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

        if (Input.GetKeyDown(KeyCode.UpArrow) && !isJumping && !isLadder) 
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump));
            isJumping = true;
        }
        else if(Input.GetKey(KeyCode.UpArrow) && isLadder)
        {
            rb.velocity = new Vector2(rb.velocity.x, climbingSpeed * Time.deltaTime);
        }
        else if(Input.GetKey(KeyCode.DownArrow) && isLadder)
        {
            rb.velocity = new Vector2(rb.velocity.x, climbingSpeed * Time.deltaTime * -1f);
        }
        else if(isLadder)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }
        
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Floor")) {
            isJumping = false;
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
        }
    }
}
