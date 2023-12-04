using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
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
        CheckCollisionWithCheck(boat.transform.position);
        float distance = Vector3.Distance(player.transform.position, marker);

        // Check if the distance is more than the threshold
        if (distance > 20)
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
                
                
            }
        }

         // No collision with dock or "SpawnPos" not found
    }

}

