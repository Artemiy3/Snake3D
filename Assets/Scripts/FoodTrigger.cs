using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Head")
        {
            other.GetComponent<SnakeMovement>().AddNewTailPart();
            Destroy(gameObject);
        }
    }
}