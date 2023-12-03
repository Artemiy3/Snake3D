using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Border : MonoBehaviour
{
    public GameObject gameHelper;

    void Start()
    {
        gameHelper = GameObject.FindGameObjectWithTag("GameHelper");
    }

    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SnakeHead"))
        {
            // // Destroy the entire snake game object
            // SnakeMovement snakeMovement = other.GetComponent<SnakeMovement>();
            // // Destroy the snake game object
            // foreach (var partOfChain in snakeMovement.tailParts)
            // {
            //     Destroy(partOfChain);
            // }
            // snakeMovement.tailParts.Clear();
            // Destroy(other.gameObject);

            gameHelper.GetComponent<GameOverMenu>().FailGame();

        }
        else if (other.CompareTag("SnakeHead1"))
        {
            gameHelper.GetComponent<GameOverMenuMult>().winnerIs1 = false;
            gameHelper.GetComponent<GameOverMenuMult>().FailGame();
        }
        else if (other.CompareTag("SnakeHead2"))
        {
            gameHelper.GetComponent<GameOverMenuMult>().winnerIs1 = true;
            gameHelper.GetComponent<GameOverMenuMult>().FailGame();
        }
    }
}