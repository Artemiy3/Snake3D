using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodGeneration : MonoBehaviour
{
    public float widthSize = 9.0f;
    public float heightSize = 9.0f;
    public GameObject foodPrefab;
    public GameObject currentFood;
    public Vector3 currentPosition;

    public void AddFood()
    {
        FoodPosition();
        currentFood = GameObject.Instantiate(foodPrefab, currentPosition, Quaternion.identity) as GameObject;
    }

    // TODO: check obstacles on each level and prevent food generation inside of them
    void FoodPosition()
    {
        currentPosition = new Vector3(
            Random.Range(-widthSize, widthSize),
            0.45f,
            Random.Range(-heightSize, heightSize)
        );
    }

    void Update()
    {
        if (!currentFood)
        {
            AddFood();
        }
    }
}