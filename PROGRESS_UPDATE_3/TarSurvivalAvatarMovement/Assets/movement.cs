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
        private bool isLeft;
        private bool isDown;
        private bool isUp;
        private bool isRight;
        private bool playerNearChest;

        //private bool hasSliced;
        public GameObject chest;
        public GameObject emerald;
        public Text words;

        // Sound effects
        [SerializeField]public AudioSource attack;
        [SerializeField]public AudioSource collect;
        [SerializeField]public AudioSource coin;
    
    void Start()
    {
        avatar = GetComponent<Rigidbody2D>();
        initial = avatar.transform.localPosition;
        direction = Vector2.one.normalized; //(1,1)
        playerNearChest = false;
        emerald.SetActive(false);
        words.text = " ";
        
        // Fight controls
        isDown = false;
        isUp = false;
        isLeft = false;
        isRight = false;

    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKey(KeyCode.D))){
            if (initial.x <= 14){
                initial.x = initial.x + displacement;
                animator.SetBool("walkright", true);
                animator.SetBool("walkleft", false);
                animator.SetBool("walkforward", false);
                animator.SetBool("walkbackward", false);
                isRight = true;
            }
            
        }
        else if((Input.GetKey(KeyCode.A))){
            if (initial.x > -14){
                initial.x = initial.x - displacement;
                animator.SetBool("walkforward", false);
                animator.SetBool("walkbackward", false);
                animator.SetBool("walkright", false);
                animator.SetBool("walkleft", true);
                isLeft = true;

            }
        }
        else if((Input.GetKey(KeyCode.W))){
            if (initial.y <= 14){
                initial.y = initial.y + displacement;
                animator.SetBool("walkleft", false);
                animator.SetBool("walkbackward", false);
                animator.SetBool("walkright", false);
                animator.SetBool("walkforward", true);
                isUp = true;
            }
        }
        else if((Input.GetKey(KeyCode.S))){
            if (initial.y > -14){
                initial.y = initial.y - displacement;
                animator.SetBool("walkleft", false);
                animator.SetBool("walkforward", false);
                animator.SetBool("walkright", false);
                animator.SetBool("walkbackward", true);
                isDown = true;
            }
        }

        else
        {
            animator.SetBool("walkleft", false);
            animator.SetBool("walkforward", false);
            animator.SetBool("walkbackward", false);
            animator.SetBool("walkright", false);
            isDown = false;
            isUp = false;
            isLeft = false;
            isRight = false;
        

        }

        if(playerNearChest && Input.GetKey(KeyCode.P )){
            words.text = "You've earned\n an \nemerald !!!";
            emerald.SetActive(true);
            collect.Play();
        }

        if (Input.GetKey(KeyCode.Y) && isRight)
        {   
            animator.SetTrigger("rightFight");
            attack.Play();   
        }
        if (Input.GetKeyDown(KeyCode.Y) && isLeft){
            animator.SetTrigger("leftFight");
            attack.Play();
        }
        if (Input.GetKey(KeyCode.Y) && isUp){
            animator.SetTrigger("upFight");
            attack.Play();
        }
        if (Input.GetKeyDown(KeyCode.Y) && isDown){
            animator.SetTrigger("downFight");
            attack.Play();
        }

        avatar.MovePosition(initial);
    }

    void OnTriggerEnter2D(Collider2D collison){

        if (collison.gameObject.CompareTag("chest")){
            playerNearChest = true;
        }

        if(collison.gameObject.CompareTag("coin")){
            coin.Play();
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
