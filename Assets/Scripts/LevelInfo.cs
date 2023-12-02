using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelInfo : MonoBehaviour
{
    public int score;
    public int levelCount = 2;
    public int[] neededScoreForEachLevel = new int[] {3, 5}; // length is equal to level count
    public bool wonGame;
    public Text infoText;
    int levelNumber;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        levelNumber = SceneManager.GetActiveScene().buildIndex;
        wonGame = false;
    }

    // Update is called once per frame
    void Update()
    {
        infoText.text = "Score: " + score.ToString() + "\nLevel: " + levelNumber;
        if (score >= neededScoreForEachLevel[levelNumber - 1])
        {
            wonGame = true;
        }
    }
}
