using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChestController : MonoBehaviour
{

    public TextMeshProUGUI popupText;
    
    // Reference to the animator component controlling the door
    private Animator chestAnimator;

    // Reference to the collider component attached to the door
    private Collider2D chestCollider;

    // A flag to track whether the door has been opened
    private bool chestOpened = false;
    private bool canOpen = false;

    [SerializeField] private DoorController door;

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
        if(canOpen && DoorOpened() && !chestOpened && popupText != null)
        {
            popupText.gameObject.SetActive(true);
        }
        else if(popupText != null)
        {
            popupText.gameObject.SetActive(false);
        }

        // Check if the door is not already opened and if the player presses the 'Enter' key
        if (canOpen && DoorOpened() && Input.GetKeyDown(KeyCode.Return))
        {
            // Set the "OpenDoor" bool parameter to true to trigger the door opening animation
            chestAnimator.SetBool("OpenDoor", true);
            
            // Disable the collider to prevent further triggers
            chestCollider.enabled = false;
            
            // Set the flag to indicate that the door has been opened
            chestOpened = true;
            canOpen = false;
        }
    }

    private bool DoorOpened()
    {
        if(door == null)
            return true;

        return door.DoorOpened;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the entering GameObject has the "Player" tag and if the door hasn't been opened yet
        if (other.CompareTag("Player2") && !chestOpened)
        {
            // Prompt the player to press 'Enter' to open the door
            canOpen = true;
            Debug.Log("Press 'Enter' to open the door.");
        }
    }

    void OnTriggerExit2D(Collider2D other) 
    {
        canOpen = false;
    }

}
