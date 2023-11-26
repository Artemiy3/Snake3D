using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Border : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SnakeHead"))
        {
            // Destroy the entire snake game object
            SnakeMovement snakeMovement = other.GetComponent<SnakeMovement>();
            // Destroy the snake game object
            foreach (var partOfChain in snakeMovement.tailParts)
            {
                Destroy(partOfChain);
            }
            snakeMovement.tailParts.Clear();
            Destroy(other.gameObject);
        }
    }
}