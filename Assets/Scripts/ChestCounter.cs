using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ChestCounter : MonoBehaviour
{

    private int chestsOpenedCount; // Counter for the number of chests opened
    public TextMeshProUGUI chestCountText; // Reference to the TextMeshPro text element

    public MoveWASD movementWASD;
    public MoveArrows movementArrow;

    private bool inMenu;

    [SerializeField] private GameObject FirstChestImage; 
    [SerializeField] private GameObject SecondChestImage;
    [SerializeField] private GameObject ThirdChestImage;
    [SerializeField] private GameObject FourthChestImage;
    [SerializeField] private GameObject VideoCamera;
    [SerializeField] private GameObject DividingLine;

    




    private bool executeOnce;

    public void UpdateUI()
    {
        chestsOpenedCount++;
        executeOnce = false;
        Debug.Log(chestsOpenedCount);
        chestCountText.text = chestsOpenedCount.ToString() + "/4 Chests";
    }

    void Update() {

        if (Input.GetKeyDown(KeyCode.Return) && inMenu) {
                inMenu = false;
                ToggleControl();
                HideAllImages();
        }

        switch(chestsOpenedCount) {
            case 1 when !executeOnce:
            executeOnce = true;
            FirstChestImage.SetActive(true);
            VideoCamera.SetActive(true);
            DividingLine.SetActive(false);
            inMenu = true;
            ToggleControl();
            break;

            case 2 when !executeOnce:
            executeOnce = true;
            SecondChestImage.SetActive(true);
            inMenu = true;
            ToggleControl();
            break;

            case 3 when !executeOnce:
            executeOnce = true;
            ThirdChestImage.SetActive(true);
            inMenu = true;
            ToggleControl();
            break;

            case 4 when !executeOnce:
            executeOnce = true;
            FourthChestImage.SetActive(true);
            inMenu = true;
            ToggleControl();
            break;
        }
    }

    void HideAllImages() {
        FirstChestImage.SetActive(false);
        SecondChestImage.SetActive(false);
        ThirdChestImage.SetActive(false);
        FourthChestImage.SetActive(false);
        VideoCamera.SetActive(false);
        DividingLine.SetActive(true);
    }

    void ToggleControl () {
        movementArrow.enabled = !inMenu;
        movementWASD.enabled = !inMenu;
    }
}
