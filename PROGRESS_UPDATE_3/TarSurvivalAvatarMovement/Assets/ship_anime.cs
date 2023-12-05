using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ship_anime : MonoBehaviour
{

    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKey(KeyCode.W)) && (Input.GetKey(KeyCode.D)))
        {
                animator.SetTrigger("northEast");  
        }

        else if ((Input.GetKey(KeyCode.W)) && (Input.GetKey(KeyCode.A)))
         {
                animator.SetTrigger("northWest");
            
        }

        else if ((Input.GetKey(KeyCode.S)) && (Input.GetKey(KeyCode.A)))
        {
                animator.SetTrigger("southWest");
            
        }

        else if ((Input.GetKey(KeyCode.S)) && (Input.GetKey(KeyCode.D)))
        {
                animator.SetTrigger("southEast");
            
        }
        
        else if((Input.GetKey(KeyCode.W)))
        {
            animator.SetTrigger("north");

        }
        else if((Input.GetKey(KeyCode.A)))
        {
            animator.SetTrigger("west");

        }

         else if((Input.GetKey(KeyCode.D)))
        {
            animator.SetTrigger("east");

        }

        else if((Input.GetKey(KeyCode.S)))
        {
           animator.SetTrigger("south");
        }
        
    }
}
