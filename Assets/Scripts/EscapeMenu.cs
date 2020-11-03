using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeMenu : MonoBehaviour
{

    public CanvasGroup escapeMenu;
    private float currentTime;
    public GameObject timer;

    void Update()
    {
        // Check if player ever presses Escape button, initiate the escape menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            escapeMenu.alpha = 1;
            escapeMenu.blocksRaycasts = true;
            timer.GetComponent<Timer>().PauseTime(); // Put the timer on pause
        }
    }

    // Continue the game if the player presses continue
    public void Continue() {
        escapeMenu.alpha = 0;
        escapeMenu.blocksRaycasts = false;
        timer.GetComponent<Timer>().unPauseTime();
    }

    // Restart the game
    public void Restart()
    {
        SceneManager.LoadScene(1);
    }

    // Exit the game
    public void Exit()
    {
        SceneManager.LoadScene(0);
    }
}
