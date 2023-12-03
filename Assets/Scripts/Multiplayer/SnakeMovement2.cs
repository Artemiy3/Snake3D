using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnakeMovement2 : MonoBehaviour
{
    public float speed = 4.5f;
    public float rotationSpeed = 250;
    public List<GameObject> tailParts = new List<GameObject>();
    public float tailOffset = -0.3f;
    public GameObject tailPrefab;
    public GameObject levelInfo;
    public GameObject nextObj;
    public int score;
    public bool isPaused;
    
    void Start()
    {
        tailParts.Add(gameObject);
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (nextObj != null && !isPaused) // && !levelInfo.GetComponent<LevelInfo>().isPaused
        {
            Vector3 nextPosForTailPart = transform.position;
            nextPosForTailPart.y = 0.27f;
            nextObj.GetComponent<TailPartsMovementMult2>().trajectory.Enqueue(nextPosForTailPart);
        }

        if (!isPaused)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.down * rotationSpeed * Time.deltaTime);
        }
    
    }

    public void AddNewTailPart()
    {

        levelInfo.GetComponent<LevelInfoMult>().score2++;

        Vector3 positionTailPart = tailParts[tailParts.Count - 1].transform.position;
        positionTailPart.z += tailOffset;
        positionTailPart.y = 0.27f;

        tailParts.Add(GameObject.Instantiate(tailPrefab, positionTailPart, Quaternion.identity) as GameObject);

        Vector3 firstPosForTailPart = tailParts[tailParts.Count - 2].transform.position;
        firstPosForTailPart.y = 0.27f;

        if (tailParts.Count == 2)
        {
            nextObj = tailParts[1];
        }

        tailParts[tailParts.Count - 1].GetComponent<TailPartsMovementMult2>().firstPos = firstPosForTailPart;
    }

    // public Vector3 calculateNewPosition()
    // {
    //     Vector3 first = tailParts[tailParts.Count - 2].transform.position;
    //     first.y = 0.27f;
    //     Vector3 second = tailParts[tailParts.Count - 1].transform.position;
    //     return first + second;
    // }
}