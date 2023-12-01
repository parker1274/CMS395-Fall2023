using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    public GameObject player;
    public Ship shipScript;
    public Docking docking;
    public Vector2 checking;
    // Start is called before the first frame update
    void Start()
    {
        GameObject shipObject = GameObject.Find("ship1");

        shipScript = shipObject.GetComponent<Ship>();
        docking = shipObject.GetComponent<Docking>();
    }

    // Update is called once per frame
    void Update()
    {
        bool collisionResult = CheckCollisionWithDock(player.transform.position);
        Debug.Log($"Collision result: {collisionResult}");
        checking = docking.marker;
    }

    bool CheckCollisionWithDock(Vector2 position)
    {

        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, 1.0f); // Adjust the radius as needed

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("dock"))
            {

                if (Input.GetKeyDown(KeyCode.E) && collider.CompareTag("dock"))
                {
                    player.SetActive(false);
                    shipScript.moveOk = true;
                    player.transform.position = docking.cr;
                    
                }
                return true;
            }
        }

        return false; // No collision with dock or "SpawnPos" not found
    }
}
