using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelInfoMult : MonoBehaviour
{
    public int score1;
    public int score2;
    public Text infoText;
    //public bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        score1 = 0;
        score2 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        infoText.text = "Green player score: " + score1.ToString() + "\nRed player score: " + score2.ToString();
        // if (score >= neededScoreForEachLevel[levelNumber - 1])
        // {
        //     wonGame = true;
        // }
    }
}
