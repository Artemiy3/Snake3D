using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodTrigger : MonoBehaviour
{

    public GameObject gameHelper;
    public AudioSource audioSource;
    public AudioClip eatClip;

    void Start()
    {
        gameHelper = GameObject.FindGameObjectWithTag("GameHelper");
        audioSource = gameHelper.GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SnakeHead"))
        {
            other.GetComponent<SnakeMovement>().AddNewTailPart();
            audioSource.PlayOneShot(eatClip, 1f);
            Destroy(gameObject);
        }
        else if (other.CompareTag("SnakeHead1"))
        {
            other.GetComponent<SnakeMovement1>().AddNewTailPart();
            audioSource.PlayOneShot(eatClip, 1f);
            Destroy(gameObject);
        }
        else if (other.CompareTag("SnakeHead2"))
        {
            other.GetComponent<SnakeMovement2>().AddNewTailPart();
            audioSource.PlayOneShot(eatClip, 1f);
            Destroy(gameObject);
        }
        else if (other.CompareTag("Obstacle") || other.CompareTag("Wall"))
        {
            gameHelper.GetComponent<FoodGeneration>().AddFood();
            Destroy(gameObject);
        }
    }
}