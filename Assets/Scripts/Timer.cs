using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    float timer;
    public TextMeshProUGUI timerText;
    private bool isTimePaused;

    void Start()
    {
        timer = 0; // Set the timer to 0 when the scene is loaded
    }

    void Update()
    {
        // Update the timer if the time isn't paused
        if (!isTimePaused)
        {
            timer += Time.deltaTime;
            timerText.text = timer.ToString("0.00");
        }
    }

    public float getTime()
    {
        return timer;
    }

    public void PauseTime() // Pause the time - used for the pause menu
    {
        isTimePaused = true;
    }

    public void unPauseTime()
    {
        isTimePaused = false;
    }
}