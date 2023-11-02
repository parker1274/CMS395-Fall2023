using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class movement : MonoBehaviour
{
    // Start is called before the first frame update
        Rigidbody2D avatar;
        Vector2 initial;
        public float displacement;
        public Animator animator;
        public Vector2 direction;
        private bool playerNearChest;
        public GameObject chest;
        public GameObject emerald;
        public Text words;
       // public float jump;
    
    void Start()
    {
        avatar = GetComponent<Rigidbody2D>();
        initial = avatar.transform.localPosition;
        direction = Vector2.one.normalized; //(1,1)
        playerNearChest = false;
        emerald.SetActive(false);
        words.text = " ";
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKey(KeyCode.D))){
            if (initial.x <= 14){
                initial.x = initial.x + displacement;
                animator.SetBool("isRight", true);
                //animator.SetInteger("speed", 2);
                animator.SetBool("walkright", true);
                // animator.SetBool("walkleft", false);
                // animator.SetBool("walkforward", false);
                // animator.SetBool("walkbackward", false);
            }
            
        }
        else if((Input.GetKey(KeyCode.A))){
            if (initial.x > -14){
                initial.x = initial.x - displacement;
                animator.SetBool("walkforward", false);
                animator.SetBool("walkbackward", false);
                animator.SetBool("walkright", false);
                animator.SetBool("walkleft", true);
            }
        }
        else if((Input.GetKey(KeyCode.W))){
            if (initial.y <= 14){
                initial.y = initial.y + displacement;
                //animator.SetInteger("speed",3);
                animator.SetBool("walkleft", false);
                animator.SetBool("walkbackward", false);
                animator.SetBool("walkright", false);
                animator.SetBool("walkforward", true);
            }
        }
        else if((Input.GetKey(KeyCode.S))){
            if (initial.y > -14){
                initial.y = initial.y - displacement;
                //animator.SetInteger("speed",-1);
                animator.SetBool("walkleft", false);
                animator.SetBool("walkforward", false);
                animator.SetBool("walkright", false);
                animator.SetBool("walkbackward", true);
            }
        }

        else
        {
            animator.SetInteger("speed", 0);
            animator.SetBool("walkleft", false);
            animator.SetBool("walkforward", false);
            animator.SetBool("walkbackward", false);
            animator.SetBool("walkright", false);

        }

        if(playerNearChest && Input.GetKey(KeyCode.P )){
            words.text = "You've earned\n an \nemerald !!!";
            emerald.SetActive(true);
        }

        avatar.MovePosition(initial);
    }

    void OnTriggerEnter2D(Collider2D collison){

        if (collison.gameObject.CompareTag("chest")){
            playerNearChest = true;
        }
    
    }

    void OnTriggerExit2D(Collider2D collison){

        if (collison.gameObject.CompareTag("chest")){
            playerNearChest = false;
            words.text = " ";
            emerald.SetActive(false);
        }
    
    }
}
