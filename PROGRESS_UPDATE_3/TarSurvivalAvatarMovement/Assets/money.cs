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
    public GameObject traderText;
    public GameObject traderText2;
    public GameObject traderText3;
    public GameObject traderText4;
    public GameObject backText1;
    public GameObject backText2;
    public GameObject backText3;

    public bool talk;
    public bool activePlayer;
    BoxCollider2D talk1 = null;
    GameObject traderNum;
    bool canBuy = false;
    bool canBuy1 = false;
    bool canBuy2 = false;
    bool canBuy3 = false;
    public bool unlockMap = false;
    public Text imgText;
    public bool greenGem = false;
    public bool redGem = false;
    public bool blueGem = false;
    public playerMove cash;


    // Start is called before the first frame update
    void Start()
    {
        GameObject mapObject = GameObject.Find("docker");
        cash = mapObject.GetComponent<playerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        imgText.text = "Coins: " + funds.ToString();
        
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
            if(traderNum.name == "npc1")
            {
                traderText.SetActive(true);
                canBuy = true;
            }
            if (traderNum.name == "npc2")
            {
                if (cash.downing >= 5)
                {
                    traderText2.SetActive(true);
                    canBuy1 = true;
                } else
                {
                    backText1.SetActive(true);
                }
                
            }
            if (traderNum.name == "npc3")
            {
                if (cash.downing >= 10)
                {
                    traderText3.SetActive(true);
                    canBuy2 = true;
                } else
                {
                    backText2.SetActive(true);
                }
                
            }
            if (traderNum.name == "npc4")
            {
                if (cash.downing >= 20)
                {
                    traderText4.SetActive(true);
                    canBuy3 = true;
                } else
                {
                    backText3.SetActive(true);
                }
                
            }     
        } else
        {
            traderText.gameObject.SetActive(false);
            traderText2.gameObject.SetActive(false);
            traderText2.gameObject.SetActive(false);
            traderText3.gameObject.SetActive(false);
            backText1.SetActive(false);
            backText2.SetActive(false);
            backText3.SetActive(false);
            canBuy = false;
            canBuy1 = false;
            canBuy2 = false;
            canBuy3 = false;
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
            if (collider.CompareTag("Ruby"))
            {
                funds = funds + 10;
                collider.gameObject.SetActive(false);
            }
            if (collider.CompareTag("box"))
            {
                collect = true;
                boxPos = collider.gameObject.transform.position;
                box = collider.gameObject;
            }
            if (collider.CompareTag("npc1"))
            {
                talk1 = collider.gameObject.GetComponent<BoxCollider2D>();
                traderNum = collider.gameObject;
            }
            
            if (collider.CompareTag("greenGem"))
            {
                collider.gameObject.SetActive(false);
                greenGem = true;
            }
            if (collider.CompareTag("blueGem"))
            {
                collider.gameObject.SetActive(false);
                blueGem = true;
            }
            if (collider.CompareTag("redGem"))
            {
                collider.gameObject.SetActive(false);
                redGem = true;
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




