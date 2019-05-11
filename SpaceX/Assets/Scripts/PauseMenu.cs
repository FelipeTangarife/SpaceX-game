using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public string mainMenuScene;
    public GameObject pauseMenu;
    public bool ispaused;

    void Start()
    {
      
        

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (ispaused)
            {
                ResumeGame();
            }else
            {
                ispaused = true;
                pauseMenu.SetActive(true);
                Time.timeScale = 0f;
            }
        }
    }


    public void ResumeGame()
    {
        ispaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void RestartGame()
    {
        ispaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1.5f;
    }

    public void ReturnToMain()
    {
        SceneManager.LoadScene(mainMenuScene);
    }
}
