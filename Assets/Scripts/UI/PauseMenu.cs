using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject buttons;
    public Animator animator;
    public bool paused = false;
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
        pauseMenu.SetActive(false);
        buttons.SetActive(false);      
        paused = false;
    }
 

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
