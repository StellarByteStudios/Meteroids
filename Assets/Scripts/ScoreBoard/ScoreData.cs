using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreData
{
    private static int playerScore;
    private static string playerName = null;

    public static int getScore()
    {
        return playerScore;
    }

    public static void setScore(int score)
    {
        playerScore = score;
    }

    public static string getName()
    {
        return playerName;
    }

    public static void setName(string name)
    {
        playerName = name;
    }
}
