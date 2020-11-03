using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Leaderboard : MonoBehaviour
{

    public TextMeshProUGUI highScores;

    // Get the leaderboard and update text when leaderboard is opened
    void Start()
    {
        highScores.text = LeaderboardManager.getFormattedLeaderboardText();

    }

}
