using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class money : MonoBehaviour
{
    public GameObject player;
    public int funds;
    bool collect = false;
    Vector2 boxPos;
    public GameObject dia;
    GameObject box;
    public Text myText;
    public Text traderText;
    public bool talk;
    public bool activePlayer;
    public BoxCollider2D talk1;
    bool canBuy = false;
    public bool unlockMap = false;
    public Text imgText;
    public bool greenGem = false;
    public bool redGem = false;
    public bool blueGem = false;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        imgText.text = "Coins: " + funds.ToString();
        myText.text = "Coins: " + funds.ToString();
        CheckCollisionWithMoney(player.transform.position);
        if (Input.GetKey(KeyCode.E)){
            if (collect == true)
            {
                Instantiate(dia, boxPos, Quaternion.identity);
                Destroy(box);
                collect = false;
            }
            if (canBuy == true && funds >= 15 && unlockMap == false)
            {
                funds = funds - 15;
                unlockMap = true;
            }
        }
        
        if (IsPlayerPositionInsideBoxCollider(talk1))
        {
            traderText.gameObject.SetActive(true);
            canBuy = true;
        } else
        {
            traderText.gameObject.SetActive(false);
            canBuy = false;
        }
    }

    
    void CheckCollisionWithMoney(Vector2 position)
    {

        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, .1f); // Adjust the radius as needed

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("coins"))
            {
                funds = funds + 1;
                collider.gameObject.SetActive(false);

            }
            else if (collider.CompareTag("Ruby"))
            {
                funds = funds + 10;
                collider.gameObject.SetActive(false);
            }
            else if (collider.CompareTag("box"))
            {
                collect = true;
                boxPos = collider.gameObject.transform.position;
                box = collider.gameObject;
            }
            else if (collider.CompareTag("npc1"))
            {
                talk1 = collider.gameObject.GetComponent<BoxCollider2D>();
            }
            else if (collider.CompareTag("greenGem"))
            {
                collider.gameObject.SetActive(false);
                greenGem = true;
            }
            
        }
        
    }
    bool IsPlayerPositionInsideBoxCollider(BoxCollider2D boxCollider)
    {
        // Get the center and size of the Box Collider
        Vector2 colliderCenter = boxCollider.bounds.center;
        Vector2 colliderSize = boxCollider.bounds.size;

        // Get the player's position
        Vector2 playerPosition = player.transform.position;

        // Check if the player's position is inside the Box Collider
        return Mathf.Abs(playerPosition.x - colliderCenter.x) < colliderSize.x / 2f &&
               Mathf.Abs(playerPosition.y - colliderCenter.y) < colliderSize.y / 2f;
    }
}




