using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using TMPro; // Import TextMeshPro namespace

public class DoorScript : MonoBehaviour
{
    public TextMeshProUGUI popupText; // Use TextMeshProUGUI instead of Text

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player1") && collision.gameObject.name == "Player1")
        {
            popupText.gameObject.SetActive(true);
              Debug.Log("Popup text shown");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player1") && collision.gameObject.name == "Player1")
        {
            popupText.gameObject.SetActive(false);
        }
    }
}


