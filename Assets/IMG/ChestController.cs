using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour

{
    // Reference to the animator component controlling the door
    private Animator chestAnimator;

    // Reference to the collider component attached to the door
    private Collider2D chestCollider;

    // A flag to track whether the door has been opened
    private bool chestOpened = false;

    // Start is called before the first frame update
    void Start()
    {
        // Get the Animator component attached to the door GameObject
        chestAnimator = GetComponent<Animator>();
        
        // Get the Collider2D component attached to the door GameObject
        chestCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the door is not already opened and if the player presses the 'Enter' key
        if (!chestOpened && Input.GetKeyDown(KeyCode.Space))
        {
            // Set the "OpenDoor" bool parameter to true to trigger the door opening animation
            chestAnimator.SetBool("OpenDoor", true);
            
            // Disable the collider to prevent further triggers
            chestCollider.enabled = false;
            
            // Set the flag to indicate that the door has been opened
            chestOpened = true;
        }
    }

    // Called when another Collider2D enters the trigger collider attached to this GameObject
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the entering GameObject has the "Player" tag and if the door hasn't been opened yet
        if (other.CompareTag("Player") && !chestOpened)
        {
            // Prompt the player to press 'Enter' to open the door
            Debug.Log("Press 'Enter' to open the door.");
        }
    }
}
