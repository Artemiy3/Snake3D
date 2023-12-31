using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TailPartsMovementMult1 : MonoBehaviour
{
    public Vector3 targetPos;
    public Vector3 firstPos;
    public int index;
    public GameObject followingTargetObj;
    public GameObject nextObj;
    public SnakeMovement1 snakeHead; // Change the data type to SnakeMovement
    public GameOverMenuMult gameOverMenu;
    public Queue<Vector3> trajectory = new Queue<Vector3>();
    public bool reachedFirstPosition;
    //public GameObject levelInfo;

    void Start()
    {
        gameOverMenu = GameObject.FindGameObjectWithTag("GameHelper").GetComponent<GameOverMenuMult>();

        snakeHead = GameObject.FindGameObjectWithTag("SnakeHead1").GetComponent<SnakeMovement1>();
        followingTargetObj = snakeHead.tailParts[snakeHead.tailParts.Count - 2];

        if (snakeHead.tailParts.Count > 2)
        {
            followingTargetObj.GetComponent<TailPartsMovementMult1>().nextObj = gameObject;
        }
        else
        {
            snakeHead.nextObj = gameObject;
        }
        index = snakeHead.tailParts.IndexOf(gameObject);
    }

    void Update()
    {
        if (!snakeHead.isPaused)
        {
            if (nextObj != null)
            {
                nextObj.GetComponent<TailPartsMovementMult1>().trajectory.Enqueue(transform.position);
            }

            if ((transform.position - firstPos).magnitude < 0.1f && !reachedFirstPosition)
            {
                reachedFirstPosition = true;
            }

            if (!reachedFirstPosition)
            {
                //transform.Translate(Vector3.forward * speed * 1.5f * Time.deltaTime);
                transform.position = Vector3.Lerp(transform.position, firstPos, Time.deltaTime * snakeHead.speed);
            }
            else
            {
                transform.position = trajectory.Dequeue();
            }
        }

        // if (followingTargetObj != null) // Check if followingTargetObj is null to avoid errors
        // {
        //     targetPos = followingTargetObj.transform.position;
        //     targetPos.z += snakeHead.tailOffset;
        //     targetPos.y = 0.27f;
        //     // transform.LookAt(followingTarget);
        //     transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * snakeHead.speed);
        // }
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (snakeHead.tailParts.Count > 2)
        {
            if (other.CompareTag("SnakeHead1"))
            {
                gameOverMenu.winnerIs1 = false;
                gameOverMenu.FailGame();
            }
        else if (other.CompareTag("SnakeHead2"))
            {
                gameOverMenu.winnerIs1 = true;
                gameOverMenu.FailGame();
            }
        }
    }
}