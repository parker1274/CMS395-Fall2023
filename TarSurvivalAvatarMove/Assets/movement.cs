using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    // Start is called before the first frame update
        Rigidbody2D avatar;
        Vector2 initial;
        public float displacement;
        public Animator animator;
       // public float jump;
    
    void Start()
    {
        avatar = GetComponent<Rigidbody2D>();
        initial = avatar.transform.localPosition;
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

        avatar.MovePosition(initial);
    }
}
