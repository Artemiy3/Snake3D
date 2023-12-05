using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public GameObject gameOverMenu;
    public GameObject levelInfo;
    public SnakeMovement head;
    public AudioSource audioSource;
    public AudioClip gameOverClip;
    public AudioSource music;

    // Start is called before the first frame update
    void Start()
    {
        gameOverMenu.SetActive(false);
        head = GameObject.FindGameObjectWithTag("SnakeHead").GetComponent<SnakeMovement>();
        audioSource = GameObject.FindGameObjectWithTag("GameHelper").GetComponent<AudioSource>();
    }

    public void FailGame()
    {
        gameOverMenu.SetActive(true);
        //levelInfo.GetComponent<LevelInfo>().isPaused = true;
        head.isPaused = true;
        Time.timeScale = 0f;
        audioSource.PlayOneShot(gameOverClip, 0.5f);
        music.Stop();
    }

    public void RestartGame()
    {
        gameOverMenu.SetActive(false);
        Time.timeScale = 1f;
        head.isPaused = false;
        //levelInfo.GetComponent<LevelInfo>().isPaused = false;
        SceneManager.LoadScene("Level01");

    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        //levelInfo.GetComponent<LevelInfo>().isPaused = false;
        head.isPaused = false;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
