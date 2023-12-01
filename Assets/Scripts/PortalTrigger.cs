using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SnakeHead"))
        {
            other.GetComponent<SnakeMovement>().AddNewTailPart();
            Destroy(gameObject);
        }
    }
}