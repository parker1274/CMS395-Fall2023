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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        myText.text = "Coins: " + funds.ToString();
        CheckCollisionWithMoney(player.transform.position);
        if (Input.GetKey(KeyCode.E)){
            if (collect == true)
            {
                Instantiate(dia, boxPos, Quaternion.identity);
                Destroy(box);
                collect = false;
            }
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
                
            } else if (collider.CompareTag("Ruby"))
            {
                funds = funds + 10;
                collider.gameObject.SetActive(false);
            } else if (collider.CompareTag("box"))
            {
                collect = true;
                boxPos = collider.gameObject.transform.position;
                box = collider.gameObject;
            }
        }
    }
}
