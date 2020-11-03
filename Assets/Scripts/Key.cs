using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Key : MonoBehaviour
{
    [SerializeField] private KeyColour keyColour = KeyColour.Red; // Assign key type to key
    public Image keyImage;
    public float rotateSpeed = 120;

    void Start() {
        keyImage.enabled = false; // Key Images are disabled at the start
    }

    void Update()
    {
        transform.Rotate (0, 0, rotateSpeed * Time.deltaTime); // Constant rotation of key
    }
    
    public enum KeyColour {
        Red, 
        Orange, 
        Yellow,
        Green,
        Blue,
        Purple,
        Pink
    }

    public KeyColour GetKeyColour() 
    {
        return keyColour;
    }

    public void ShowKeyImage() { // Show the key image is inventory when the key is collected
        keyImage.enabled = true;
    }
}
