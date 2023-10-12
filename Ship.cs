using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float boundaryXMin = -50.0f; // Define the map boundary in X-axis
    public float boundaryXMax = 50.0f;  // Define the map boundary in X-axis
    public float boundaryYMin = -50.0f; // Define the map boundary in Y-axis
    public float boundaryYMax = 50.0f;  // Define the map boundary in Y-axis

    void Update()
    {
        // Get input for boat movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the new position
        Vector3 newPosition = transform.position + new Vector3(horizontalInput, verticalInput, 0) * moveSpeed * Time.deltaTime;

        // Clamp the position to stay within the map boundaries
        newPosition.x = Mathf.Clamp(newPosition.x, boundaryXMin, boundaryXMax);
        newPosition.y = Mathf.Clamp(newPosition.y, boundaryYMin, boundaryYMax);

        // Move the boat
        transform.position = newPosition;
    }
}
