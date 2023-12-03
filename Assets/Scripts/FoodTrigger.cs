using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SnakeHead"))
        {
            other.GetComponent<SnakeMovement>().AddNewTailPart();
            Destroy(gameObject);
        }
        else if (other.CompareTag("SnakeHead1"))
        {
            other.GetComponent<SnakeMovement1>().AddNewTailPart();
            Destroy(gameObject);
        }
        else if (other.CompareTag("SnakeHead2"))
        {
            other.GetComponent<SnakeMovement2>().AddNewTailPart();
            Destroy(gameObject);
        }
    }
}