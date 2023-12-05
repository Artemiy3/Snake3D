using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalTrigger : MonoBehaviour
{
    public GameObject levelInfo;
    public AudioSource audioSource;
    public AudioClip portalClip;

    void Start()
    {
        audioSource = GameObject.FindGameObjectWithTag("GameHelper").GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Head 1")
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            if (currentSceneIndex == levelInfo.GetComponent<LevelInfo>().levelCount)
            {
                SceneManager.LoadScene("MainMenu");
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        } else if (other.CompareTag("Obstacle"))
        {
            GameObject.FindGameObjectWithTag("GameHelper").GetComponent<PortalGenerator>().GeneratePortal();
            Destroy(gameObject);
        }
    }
}
