using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBoat : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public OceanTile oceanTile; // Reference to the script that checks for ocean tiles

    void Update()
    {
        // Get input for boat movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the new position
        Vector3 newPosition = transform.position + new Vector3(horizontalInput, verticalInput, 0) * moveSpeed * Time.deltaTime;

        // Check if the new position is over an ocean tile
        if (oceanTile.IsOverOcean(newPosition))
        {
            // Move the boat
            transform.position = newPosition;
        }
    }
}