using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TailPartsMovement : MonoBehaviour
{
    public Vector3 followingTarget;
    public int index;
    public GameObject followingTargetObj;
    public SnakeMovement snakeHead; // Change the data type to SnakeMovement

    void Start()
    {
        snakeHead = GameObject.FindGameObjectWithTag("SnakeHead").GetComponent<SnakeMovement>();
        followingTargetObj = snakeHead.tailParts[snakeHead.tailParts.Count - 2];
        index = snakeHead.tailParts.IndexOf(gameObject);
    }

    void Update()
    {
        if (followingTargetObj != null) // Check if followingTargetObj is null to avoid errors
        {
            followingTarget = followingTargetObj.transform.position;
            followingTarget.z += snakeHead.tailOffset;
            followingTarget.y = 0.27f;
            // transform.LookAt(followingTarget);
            transform.position = Vector3.Lerp(transform.position, followingTarget, Time.deltaTime * snakeHead.speed);
        }
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SnakeHead"))
        {
            if (index > 2)
            {
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
}