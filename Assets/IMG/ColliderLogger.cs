using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ColliderLogger : MonoBehaviour
{
    // This function is called when the collider enters another collider
    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to the player and has the correct name
        if (other.CompareTag("Player") && other.gameObject.name == "Player2")
        {
            Debug.Log("Player2 entered the collider.");
        }
    }
}
