using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCollided : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

        // This function is called when the Collider other enters the trigger.
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DoorPast"))
        {
            Debug.Log("Player collided with DoorPast!");
        }
    }
}
