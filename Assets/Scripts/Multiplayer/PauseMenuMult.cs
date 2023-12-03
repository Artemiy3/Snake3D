using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuMult : MonoBehaviour
{
    public GameObject pauseMenu;
    public SnakeMovement head1;
    public SnakeMovement head2;
    public bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
        head1 = GameObject.FindGameObjectWithTag("SnakeHead1").GetComponent<SnakeMovement>();
        head1 = GameObject.FindGameObjectWithTag("SnakeHead2").GetComponent<SnakeMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else 
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        head1.isPaused = true;
        head2.isPaused = true;
        //levelInfo.GetComponent<LevelInfo>().isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        head1.isPaused = false;
        head2.isPaused = true;
        //levelInfo.GetComponent<LevelInfo>().isPaused = false;
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        //levelInfo.GetComponent<LevelInfo>().isPaused = false;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
