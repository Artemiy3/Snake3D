using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelInfo : MonoBehaviour
{
    public int score;
    public int levelCount = 5;
    public int[] neededScoreForEachLevel = new int[] {3, 5, 8, 13, 21}; // length is equal to level count
    public bool wonGame;
    public Text infoText;
    public int levelNumber;
    public AudioSource audioSource;
    public AudioClip portalClip;
    public AudioSource music;
    void Start()
    {
        score = 0;
        levelNumber = SceneManager.GetActiveScene().buildIndex;
        wonGame = false;
        audioSource = GameObject.FindGameObjectWithTag("GameHelper").GetComponent<AudioSource>();
        audioSource.PlayOneShot(portalClip, 1f);
        music.Play();
    }

    // Update is called once per frame
    void Update()
    {
        infoText.text = "Score: " + score.ToString() + "/" + neededScoreForEachLevel[levelNumber - 1].ToString() + "\nLevel: " + levelNumber;
        if (score >= neededScoreForEachLevel[levelNumber - 1])
        {
            wonGame = true;
        }
    }
}
