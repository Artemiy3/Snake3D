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
    public AudioSource audioSource;
    public AudioClip portalClip;
    public AudioSource music;
    void Start()
    {
        score1 = 0;
        score2 = 0;
        audioSource = GameObject.FindGameObjectWithTag("GameHelper").GetComponent<AudioSource>();
        audioSource.PlayOneShot(portalClip, 1f);
        music.Play();
    }

    // Update is called once per frame
    void Update()
    {
        infoText.text = "Green player score: " + score1.ToString() + "\nRed player score: " + score2.ToString();
    }
}
