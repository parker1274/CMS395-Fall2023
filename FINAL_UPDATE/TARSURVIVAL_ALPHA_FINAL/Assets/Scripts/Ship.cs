using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] GameObject boat;
    public float moveSpeed = 5.0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Get input for boat movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the new position
        Vector3 newPosition = transform.position + new Vector3(horizontalInput, verticalInput, 0) * moveSpeed * Time.deltaTime;

        // Move the boat only if there is no collision with islands
        if (!CheckCollisionWithIsland(newPosition))
        {
            // Move the boat
            transform.position = newPosition;
        }
        if (transform.position.y < 5)
        {
            transform.position = new Vector2(transform.position.x, 5);
        }
        if (transform.position.x < 9.5)
        {
            transform.position = new Vector2(9.5f, transform.position.y);
        }
        if (transform.position.y > 495)
        {
            transform.position = new Vector2(transform.position.x, 495);
        }
        if (transform.position.x > 495)
        {
            transform.position = new Vector2(495, transform.position.y);
        }
    }

    bool CheckCollisionWithIsland(Vector3 position)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, 1.0f); // Adjust the radius as needed

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("island"))
            {
                return true; // Collision with island detected
            }
        }

        return false; // No collision with islands
    }
}

