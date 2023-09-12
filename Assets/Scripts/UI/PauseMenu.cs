using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    
    public GameObject pauseMenu;
    public GameObject buttons;
    public Animator animator;
    public GameObject tutorialScreen;
    bool opened = false;

    public AudioSource audioSource;
    public AudioClip click;
    public AudioClip select;

    void Start()
    {
        pauseMenu.SetActive(false);
        buttons.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape) && opened == false)
        {
            OpenMenu();
            opened = true;
        }
        if (Input.GetKeyDown(KeyCode.Escape) && opened == true)
        {
            Resume();
            opened = false;
        }
    }
    public void OpenMenu()
    {
        pauseMenu.SetActive(true);
        audioSource.clip = select;
        audioSource.Play();
    }

    public void Resume()
    {
        animator.SetTrigger("close");  
        buttons.SetActive(false);
        Time.timeScale = 1f;
        audioSource.clip = click;
        audioSource.Play();
    }
 
    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
        audioSource.clip = click;
        audioSource.Play();
    }
    public void tutorial()
    {
        tutorialScreen.SetActive(true);
        Resume();
    }
    public void tutorialBack()
    {
        pauseMenu.SetActive(true);
        tutorialScreen.SetActive(false);
        OpenMenu();
    }
}
