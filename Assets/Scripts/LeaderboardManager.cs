using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderboardManager : MonoBehaviour
{

    private static string PREFIX = "leaderboard";
    private static int MAX_SCORES = 10; 

    public static void submitScore(float score, string name) 
    {
        int rankEarned = MAX_SCORES + 1; 

        // Loop through scores and figure out the submitted score's place in the leaderboard
        for (int currentRank = 1; currentRank <= MAX_SCORES; currentRank++)
        {
            // IF the current score holder is empty OR the score is less than (better) than the current score...
            if ((!PlayerPrefs.HasKey(getScoreKey(currentRank))) || (score < getScore(currentRank))) { // golf score
                rankEarned = currentRank;
                break;
            }
        }

        // Loop and change the positions of each score to accomodate new score
        for (int currentRank = MAX_SCORES; currentRank > rankEarned; currentRank--)
        {
            if (PlayerPrefs.HasKey(getScoreKey(currentRank - 1)))
            {
                setScore(currentRank, getScore(currentRank - 1));
                setPlayer(currentRank, getPlayer(currentRank - 1));
            }
        }

        setScore(rankEarned, score);
        setPlayer(rankEarned, name);
    }

    // GETTERS AND SETTERS :)
    public static float getScore(int rank) 
    {
        return PlayerPrefs.GetFloat(getScoreKey(rank));
    }

    public static string getPlayer(int rank)
    {
        return PlayerPrefs.GetString(getPlayerKey(rank));
    }
    private static string getScoreKey(int rank) 
    {
        return PREFIX + "score" + rank.ToString(); 
    }

    private static string getPlayerKey(int rank) 
    {
        return PREFIX + "player" + rank.ToString();
    }

    private static void setScore(int rank, float score)
    {
        PlayerPrefs.SetFloat(getScoreKey(rank), score);
    }

    private static void setPlayer(int rank, string player)
    {
        PlayerPrefs.SetString(getPlayerKey(rank), player);
    }

    // Format the leaderboard into a string variable
    public static string getFormattedLeaderboardText()
    {
        string text = "";

        for (int rank = 1; rank <= MAX_SCORES; rank++)
        {
            if (!PlayerPrefs.HasKey(getScoreKey(rank)))
            {
                break;
            }
            text += rank.ToString() + ". " + getPlayer(rank) + " ......................... " + getScore(rank).ToString() + " seconds\n";
        }

        return text;
    }
}
