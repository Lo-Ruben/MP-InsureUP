using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreSingleton : GenericSingleton<HighScoreSingleton>
{
    public int currentScore;
    public int highScore;
    public int round;

    public void OverrideHighScore()
    {
        if (currentScore > highScore)
        {
            highScore = currentScore;
        }
    }
    public void ResetCurrentScore()
    {
        currentScore = 0;
    }
    public void UpdateScore(int updatedScore, int roundNumber)
    {
        currentScore = updatedScore;
        round = roundNumber;
    }
    public void AddScore(int addPoints)
    {
        currentScore += addPoints;
    }
    public void DeductScore(int deductPoints)
    {
        currentScore -= deductPoints;
    }

    public void CalculateScore()
    {
        if (round != 0)
        {
            currentScore /= round;
            OverrideHighScore();
        }
        
    }

}
