using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class DoorController : MonoBehaviour
{
    // Reference to the animator component controlling the door
    private Animator doorAnimator;

    // Reference to the collider component attached to the door
    private Collider2D doorCollider;

    // A flag to track whether the door has been opened
    private bool doorOpened = false;

    // Start is called before the first frame update
    void Start()
    {
        // Get the Animator component attached to the door GameObject
        doorAnimator = GetComponent<Animator>();
        
        // Get the Collider2D component attached to the door GameObject
        doorCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the door is not already opened and if the player presses the 'Enter' key
        if (!doorOpened && Input.GetKeyDown(KeyCode.Return))
        {
            // Set the "OpenDoor" bool parameter to true to trigger the door opening animation
            doorAnimator.SetBool("OpenDoor", true);
            
            // Disable the collider to prevent further triggers
            doorCollider.enabled = false;
            
            // Set the flag to indicate that the door has been opened
            doorOpened = true;
        }
    }

    // Called when another Collider2D enters the trigger collider attached to this GameObject
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the entering GameObject has the "Player" tag and if the door hasn't been opened yet
        if (other.CompareTag("Player") && !doorOpened)
        {
            // Prompt the player to press 'Enter' to open the door
            Debug.Log("Press 'Enter' to open the door.");
        }
    }
}


