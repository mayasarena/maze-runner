using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class EndOfMaze : MonoBehaviour
{
    public float fadeDuration = 1f;
    public float displayImageDuration = 1f;
    public CanvasGroup endOfMaze;
    public CanvasGroup enterName;
    public CanvasGroup nameError;
    public Button okButton;
    float fadeTimer;
    bool IsPlayerAtEnd;
    public GameObject timer;
    float score;
    public AudioSource endAudio;

    void OnTriggerEnter(Collider other) // Check if player is at exit
    {
        if (other.tag == "Player")
        {
            score = timer.GetComponent<Timer>().getTime(); // Get the time at the moment the player enters the exit
            IsPlayerAtEnd = true;
            endAudio.Play(); // Play ending audio
        }
    }

    void Update() // Initiate the end of the maze process
    {
        if(IsPlayerAtEnd)
        {
            EndMaze(endOfMaze);
        }
    }

    void EndMaze(CanvasGroup imageCanvasGroup) 
    {
        // Fade to the end of maze screen
        fadeTimer += Time.deltaTime;
        imageCanvasGroup.alpha = fadeTimer / fadeDuration;

        // Once fade is over, bring up the screen for entering player name
        if(fadeTimer > fadeDuration + displayImageDuration)
        {
            enterName.alpha = 1;
            string name = enterName.GetComponentInChildren<TMP_InputField>().text; // Get the name from the input field

            if (Input.GetKeyDown(KeyCode.Return))
            {
                // Add the name and score to the leaderboard
                if (name.Length == 3)
                {
                    LeaderboardManager.submitScore(score, name);
                    SceneManager.LoadScene(1); // Restart the game
                }

                // Error pop-op if the name is not 3 characters
                else
                {
                    nameError.blocksRaycasts = true;
                    nameError.alpha = 1;
                    okButton.onClick.AddListener(ClosePopup);
                }
            }
        }

        void ClosePopup() { // Close the error pop-up if the OK button is clicked
            nameError.alpha = 0;
            nameError.blocksRaycasts = false;
        }
    }
}
