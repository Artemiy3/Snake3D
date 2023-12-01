using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PortalGenerator : MonoBehaviour
{
    public float widthSize = 8.5f;
    public GameObject portal;
    public GameObject currentPortal;
    public Text scoreText;
    public GameObject snakeMovement;

    void GeneratePortal()
    {
        int wallNumber = Random.Range(0, 4);

        Quaternion rot;
        if (wallNumber == 0 || wallNumber == 2)
        {
            rot = Quaternion.Euler(90, 0, 0);
        }
        else
        {
            rot = Quaternion.Euler(0, 0, 90);
        }

        Vector3 position = GetRandomPortalPosition(wallNumber);

        currentPortal = GameObject.Instantiate(portal, position, rot) as GameObject;
    }

    Vector3 GetRandomPortalPosition(int wallNumber)
    {
        float randomPosition = Random.Range(-widthSize, widthSize);
        Vector3 position;

        if (wallNumber == 0)
        {
            position = new Vector3(
                randomPosition,
                1.04f,
                9.39f
            );
        }
        else if (wallNumber == 1)
        {
            position = new Vector3(
                9.39f,
                1.04f,
                randomPosition
            );
        }
        else if (wallNumber == 2)
        {
            position = new Vector3(
                randomPosition,
                1.04f,
                -9.39f
            );
        }
        else
        {
            position = new Vector3(
                -9.39f,
                1.04f,
                randomPosition
            );
        }

        return position;
    }

    void Start()
    {
        currentPortal = null;
    }

    // Update is called once per frame
    void Update()
    {
        int score = snakeMovement.GetComponent<SnakeMovement>().score;
        if (score == 10 && currentPortal == null)
        {
            GeneratePortal();
        }
    }
}
