using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameOverMenuMult : MonoBehaviour
{
    public GameObject gameOverMenu;
    public GameObject levelInfo;
    public SnakeMovement1 head1;
    public SnakeMovement2 head2;
    public bool winnerIs1;
    public TMP_Text gameOverText;

    // Start is called before the first frame update
    void Start()
    {
        gameOverMenu.SetActive(false);
        head1 = GameObject.FindGameObjectWithTag("SnakeHead1").GetComponent<SnakeMovement1>();
        head2 = GameObject.FindGameObjectWithTag("SnakeHead2").GetComponent<SnakeMovement2>();
    }

    public void FailGame()
    {
        if (winnerIs1)
        {
            gameOverText.text = "Green player won!";
        }
        else
        {
            gameOverText.text = "Red player won!";
        }
        gameOverMenu.SetActive(true);
        //levelInfo.GetComponent<LevelInfo>().isPaused = true;
        head1.isPaused = true;
        head2.isPaused = true;
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        gameOverMenu.SetActive(false);
        Time.timeScale = 1f;
        head1.isPaused = false;
        head2.isPaused = false;
        //levelInfo.GetComponent<LevelInfo>().isPaused = false;
        SceneManager.LoadScene("Multiplayer");

    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        //levelInfo.GetComponent<LevelInfo>().isPaused = false;
        head1.isPaused = false;
        head2.isPaused = false;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
