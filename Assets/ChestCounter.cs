using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ChestCounter : MonoBehaviour
{

    private int chestsOpenedCount; // Counter for the number of chests opened
    public TextMeshProUGUI chestCountText; // Reference to the TextMeshPro text element

  public void UpdateUI()
    {
        // Debug.Log("chestsOpenedCount");


        chestsOpenedCount++;
        Debug.Log(chestsOpenedCount);
        chestCountText.text = chestsOpenedCount.ToString() + "/4 Chests";
    }
}
