using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnakeMovement : MonoBehaviour
{
    public float speed;
    public float rotationSpeed = 250;

    public List<GameObject> tailParts = new List<GameObject>();

    public float tailOffset = -0.1f;

    public GameObject tailPrefab;

    public Text scoreText;
    public int score;
    
    void Start()
    {
        tailParts.Add(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

        scoreText.text = "Score: " + score.ToString();
        transform.Translate(Vector3.forward * speed * 1.5f * Time.deltaTime);

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.down * rotationSpeed * Time.deltaTime);
        }
    
    }

    public void AddNewTailPart()
    {

        score++;
        Vector3 positionTailPart = tailParts[tailParts.Count - 1].transform.position;
        positionTailPart.z += tailOffset;
        positionTailPart.y = 0.27f;
        tailParts.Add(GameObject.Instantiate(tailPrefab, positionTailPart, Quaternion.identity) as GameObject);
  
    }
}