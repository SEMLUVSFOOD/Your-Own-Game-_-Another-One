using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderMovement : MonoBehaviour
{
    private float vertical;
    private float speed = 8f;
    private bool isLadder;
    private bool isClimbing;
    [SerializeField] private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        vertical = Input.GetAxis("Vertical");
        if (isLadder && Mathf.Abs(vertical) > 0f) {
            isClimbing = true;
        }

    }

    private void FixedUpdate() {
        if (isClimbing) {
            rb.velocity = new Vector2(rb.velocity.x, vertical * speed);
        }    
        else {
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
            rb.gravityScale = 2f;
            isLadder = false;
            isClimbing = false;
            Debug.Log("off ladder");
        }
    }
}
