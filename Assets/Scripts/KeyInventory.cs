using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInventory : MonoBehaviour
{
    private List<Key.KeyColour> keys;
    public AudioSource keyAudio;
    public AudioSource doorAudio;

    void Awake() 
    {
        keys = new List<Key.KeyColour>();
    }

    private void addKey(Key.KeyColour colour) 
    {
        keys.Add(colour); // Add key to inventoy
    }

    private void removeKey(Key.KeyColour colour) 
    {
        keys.Remove(colour); // Remove key from inventory
    }

    void OnTriggerEnter(Collider other) {
        // Check if the player collides with a key
        if (other.tag == "Key") {
            Key currentKey = other.GetComponent<Key>();
            keyAudio.Play(); // Play fun audio when key is collected
            addKey(currentKey.GetKeyColour()); // Add the key to inventory
            currentKey.ShowKeyImage(); // Update the inventory image
            Destroy(other.gameObject); // Destroy the key object
        }

    // Check if the player collides with a door
        if (other.tag == "Door") {
            Door currentDoor = other.GetComponent<Door>();
            // Only open the door if the user has collected the key
            if (keys.Contains(currentDoor.GetDoorColour()))
            {
                other.GetComponent<Door>().OpenDoor(); // Open the door
                doorAudio.Play(); // Play fun audio when door is opened
                currentDoor.HideKeyImage(); // Remove the key image from the inventory
            }
        }
    }
}
