using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreManager : MonoBehaviour
{
    [SerializeField]
    bool resetBool = false;
    [SerializeField]
    GameManager m_gameManager;

    public Text HighScoreText;
    public Text ScoreText;


    // Start is called before the first frame update
    void Start()
    {
        if (resetBool)
        {
            HighScoreSingleton.instance.ResetCurrentScore();
        }
        else
        {
            HighScoreSingleton.instance.CalculateScore();
        }

        if (m_gameManager != null)
        {
            HighScoreSingleton.instance.UpdateScore(m_gameManager.money, m_gameManager.roundCounter);
        }
        else
        {
            Debug.Log("No GameManager");
        }
    }
    void OnEnable()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Updates UI
        if (HighScoreText != null)
        {
            HighScoreText.text = "HighScore: " + HighScoreSingleton.instance.highScore.ToString();
            ScoreText.text = "Score: " + HighScoreSingleton.instance.currentScore.ToString();
        }
    }
}
