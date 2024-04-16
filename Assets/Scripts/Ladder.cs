using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ladder : MonoBehaviour
{

    [SerializeField] private GameObject DLadderPr, DLadderPa;
    [SerializeField] private GameObject ALadderPr, ALadderPa;
    [SerializeField] private GameObject Text;


    private bool isActive;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive && Input.GetKeyDown(KeyCode.Space)) {
            Debug.Log("Put Up Ladder");
            isActive = false;
            DLadderPa.SetActive(false);
            DLadderPr.SetActive(false);
            ALadderPa.SetActive(true);
            ALadderPr.SetActive(true);
            Text.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the entering GameObject has the "Player" tag and if the door hasn't been opened yet
        if (other.CompareTag("Player1"))
        {
            Debug.Log("Player1 Entered Ladder");
            isActive = true;
            Text.SetActive(true);
        }
    }

     void OnTriggerExit2D(Collider2D other)
    {
        // Check if the entering GameObject has the "Player" tag and if the door hasn't been opened yet
        if (other.CompareTag("Player1"))
        {
            isActive = false;
            Text.SetActive(false);
        }
    }
}
