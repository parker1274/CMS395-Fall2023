using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    public int downing = 0;
    public GameObject player;
    public GameObject boat;
    public bool docking = false;
    public bool boatColliding;
    public bool playerColliding;
    public Vector2 marker;
    public bool checkE;
    public Ship shipScript;
    public movement move;
    public Transform e1;
    public Transform e2;
    public Transform e3;
    public GameObject r1;
    bool award1;
    bool award2;
    bool award3;
    public GameObject coin;
    bool inBuilding = false;
    public Transform kwrSpawn;
    public Transform kwrExit;
    GameObject e4;
    GameObject e5;
    GameObject e6;
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        player.SetActive(false);
        GameObject shipObject = GameObject.Find("ship1");
        shipScript = shipObject.GetComponent<Ship>();
        GameObject moveObj = GameObject.Find("player");
        move = moveObj.GetComponent<movement>();


    }

    // Update is called once per frame
    void Update()
    {
        CheckCollisionWithEntry(player.transform.position);
        CheckCollisionWithDock(player.transform.position);
        CheckCollisionWithCheck(boat.transform.position);
        float distance = Vector3.Distance(player.transform.position, marker);

        // Check if the distance is more than the threshold
        if (distance > 20 && !inBuilding)
        {
            if (move.initial != marker)
            {
                move.initial = marker;
            }
            player.transform.position = marker;
            
        }
        boatColliding = CheckCollisionWithDock(boat.transform.position);
       
        playerColliding = CheckCollisionWithDock(player.transform.position);
        
        
        if (docking == false && boatColliding == true)
        {
            boat.SetActive(false);
            docking = true;
            boat.transform.position = new Vector2(boat.transform.position.x-2f, boat.transform.position.y - 2f);
            player.SetActive(true);
            player.transform.position = marker;
            shipScript.moveOk = false;
            award1 = false;
            award2 = false;
            award3 = false;
            e4 = Instantiate(r1, e1.transform.position, Quaternion.identity);
            e5 = Instantiate(r1, e2.transform.position, Quaternion.identity);
            e6 = Instantiate(r1, e3.transform.position, Quaternion.identity);
            

        }
        if (docking == true && playerColliding == true)
        {
            player.SetActive(false);
            boat.SetActive(true);
            shipScript.moveOk = true;
            docking = false;
            player.transform.position = new Vector2(0, 0);
            Destroy(e4);
            Destroy(e5);
            Destroy(e6);
        }
        if (!e4.activeSelf && award1 == false && e4 != null)
        {
            award1 = true;
            downing += 1;
            if (Random.Range(0f, 1f) <= 0.3f)
            {
                Instantiate(coin, e4.transform.position, Quaternion.identity);
            }
        }
        if (!e5.activeSelf && award2 == false && e5 != null)
        {
            award2 = true;
            downing += 1;
            if (Random.Range(0f, 1f) <= 0.3f)
            {
                Instantiate(coin, e5.transform.position, Quaternion.identity);
            }
        }
        if (!e6.activeSelf && award3 == false && e5 != null)
        {
            award3 = true;
            downing += 1;
            if (Random.Range(0f, 1f) <= 0.3f)
            {
                Instantiate(coin, e6.transform.position, Quaternion.identity);
            }
        }

    }
    bool CheckCollisionWithDock(Vector2 position)
    {

        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, 1.0f); // Adjust the radius as needed

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("dock"))
            {
                
                return true;
            }
        }

        return false; // No collision with dock or "SpawnPos" not found
    }
    void CheckCollisionWithCheck(Vector2 position)
    {

        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, 1.0f); // Adjust the radius as needed

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("check"))
            {
                dockScript dockScript = collider.GetComponent<dockScript>();
                marker = dockScript.spawnPos.position;
                e1 = dockScript.enemyOne;
                e2 = dockScript.enemyTwo;
                e3 = dockScript.enemyThree;
                kwrExit = dockScript.kwrExit;
                
            }
        }

         // No collision with dock or "SpawnPos" not found
    }
    void CheckCollisionWithEntry(Vector2 position)
    {

        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, 1.0f); // Adjust the radius as needed

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("entry"))
            {
                move.initial = kwrSpawn.transform.position;
                player.transform.position = kwrSpawn.transform.position;
                inBuilding = true;
            }
            if (collider.CompareTag("exit"))
            {
                move.initial = kwrExit.transform.position;
                player.transform.position = kwrExit.transform.position;
                inBuilding = false;
            }
        }

        // No collision with dock or "SpawnPos" not found
    }

}

