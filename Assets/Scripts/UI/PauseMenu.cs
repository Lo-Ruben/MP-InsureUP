using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    
    public GameObject pauseMenu;
    public GameObject buttons;
    public Animator animator;

    void Start()
    {
        pauseMenu.SetActive(false);
        buttons.SetActive(false);
    }

    public void OpenMenu()
    {
        pauseMenu.SetActive(true);
    }

    public void Resume()
    {
        animator.SetTrigger("close");  
        buttons.SetActive(false);
        Time.timeScale = 1f;
    }
 
    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
}
