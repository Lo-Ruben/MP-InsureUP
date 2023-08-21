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
        StartCoroutine(displayScores());
        if (resetBool)
        {
            HighScoreSingleton.instance.ResetCurrentScore();
        }
        else
        {
            HighScoreSingleton.instance.CalculateScore();
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
            HighScoreText.text = "" + HighScoreSingleton.instance.highScore.ToString();
            ScoreText.text = "" + HighScoreSingleton.instance.currentScore.ToString();
        }
        if (m_gameManager != null)
        {
            HighScoreSingleton.instance.UpdateScore(m_gameManager.money, m_gameManager.roundCounter);
        }
    }
    void displayHighScore()
    {
        if (HighScoreText != null)
        {
            HighScoreText.gameObject.SetActive(true);
        }
    }
    void displayCurrentScore()
    {
        if (ScoreText != null)
        {
            ScoreText.gameObject.SetActive(true);
        }
    }
    IEnumerator displayScores()
    {
        yield return new WaitForSeconds(0.4f);
        displayHighScore();
        yield return new WaitForSeconds(0.44f);
        displayCurrentScore();
    }
}
