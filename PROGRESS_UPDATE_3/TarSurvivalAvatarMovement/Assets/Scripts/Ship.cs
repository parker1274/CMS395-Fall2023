using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ship : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] GameObject boat;
    public float moveSpeed = 5.0f;
    public bool moveOk = true;
    public GameObject player;
    public money cash;
    public bool end = false;
    
   


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GameObject mapObject = GameObject.Find("player");
        cash = mapObject.GetComponent<money>();

    }

    void Update()
    {
        if (cash.redGem && cash.greenGem && cash.blueGem)
        {
            end = true;
        }
        // Get input for boat movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the new position
        Vector3 newPosition = transform.position + new Vector3(horizontalInput, verticalInput, 0) * moveSpeed * Time.deltaTime;
     
        // Move the boat only if there is no collision with islands or dock
        if (!CheckCollisionWithIsland(newPosition) && moveOk)
        {
            // Move the boat
            transform.position = newPosition;
        }
        if (transform.position.x < 9.5)
        {
            transform.position = new Vector2(9.5f, transform.position.y);
            
        }
        if (transform.position.y < 5)
        {
            transform.position = new Vector2(transform.position.x, 5);
            
        }
        if (transform.position.x > 495)
        {
            transform.position = new Vector2(495, transform.position.y);
            
        }
        if (transform.position.y > 495)
        {
            transform.position = new Vector2(transform.position.x, 495);
        }
        if (end == true)
        {
            SceneManager.LoadScene("Opening");
        }
        
        // ... (your existing boundary checks)

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


