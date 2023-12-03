using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Docking : MonoBehaviour
{
    public GameObject player;
    public Ship shipScript;
    public GameObject ship1;
    public Vector2 marker;
    public Vector2 cr;

    // Start is called before the first frame update
    void Start()
    {
        GameObject shipObject = GameObject.Find("ship1");
        shipScript = shipObject.GetComponent<Ship>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckCollisionWithDock(ship1.transform.position);
        
    }




    void CheckCollisionWithDock(Vector2 position)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, 1.0f); // Adjust the radius as needed

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("dock"))
            {
                dockScript dockScript = collider.GetComponent<dockScript>();
                marker = dockScript.spawnPos.position;

                if (Input.GetKeyDown(KeyCode.E))
                {
                    // Update the current dock spawn position
                    Swap(marker);

                    // Teleport the player to the selected spawn position
                }
            }
        }
    }

    void Swap(Vector2 spawnPos)
    {
        player.transform.position = spawnPos;
        correction(player.transform.position);

    }
    void correction(Vector2 correct)
    {
        player.SetActive(true);
        shipScript.moveOk = false;
        player.transform.position = correct;
        cr = player.transform.position = correct;
    }
}
