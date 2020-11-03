using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    [SerializeField] private Key.KeyColour keyColour = Key.KeyColour.Red; 
    public Image keyImage;

    public Key.KeyColour GetDoorColour() // Set respective door colour based on keys
    {
        return keyColour;
    }

    public void OpenDoor() // Open the door
    {
        gameObject.SetActive(false);
    }

    public void HideKeyImage() // Hide key image based on current key when the door is opened
    {
        keyImage.enabled = false;
    }

}
