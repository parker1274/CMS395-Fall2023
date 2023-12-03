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
    private bool death_con;

    //private bool hasSliced;
    public GameObject chest;
    public GameObject emerald;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public Text words;
    public LayerMask Enemy_layer;

    // Sound effects
    [SerializeField] public AudioSource attack;
    [SerializeField] public AudioSource collect;
    [SerializeField] public AudioSource coin;

    void Start()
    {
        avatar = GetComponent<Rigidbody2D>();
        initial = avatar.transform.localPosition;
        direction = Vector2.one.normalized; //(1,1)
        playerNearChest = false;
        emerald.SetActive(false);
        words.text = " ";
        death_con = false;

        // Fight controls
        isDown = false;
        isUp = false;
        isLeft = false;
        isRight = false;

    }

    void Update()
    {
        if ((Input.GetKey(KeyCode.D)))
        {
            if (initial.x <= 14)
            {
                isDown = false;
                isUp = false;
                isLeft = false;
                isRight = false;
                initial.x = initial.x + displacement;
                animator.SetBool("walkright", true);
                animator.SetBool("walkleft", false);
                animator.SetBool("walkforward", false);
                animator.SetBool("walkbackward", false);
                isRight = true;
            }

        }
        else if ((Input.GetKey(KeyCode.A)))
        {
            if (initial.x > -14)
            {
                isDown = false;
                isUp = false;
                isLeft = false;
                isRight = false;
                initial.x = initial.x - displacement;
                animator.SetBool("walkforward", false);
                animator.SetBool("walkbackward", false);
                animator.SetBool("walkright", false);
                animator.SetBool("walkleft", true);
                isLeft = true;

            }
        }
        else if ((Input.GetKey(KeyCode.W)))
        {
            if (initial.y <= 14)
            {
                isDown = false;
                isUp = false;
                isLeft = false;
                isRight = false;
                initial.y = initial.y + displacement;
                animator.SetBool("walkleft", false);
                animator.SetBool("walkbackward", false);
                animator.SetBool("walkright", false);
                animator.SetBool("walkforward", true);
                isUp = true;
            }
        }
        else if ((Input.GetKey(KeyCode.S)))
        {
            if (initial.y > -14)
            {
                isDown = false;
                isUp = false;
                isLeft = false;
                isRight = false;
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
            // isDown = false;
            // isUp = false;
            // isLeft = false;
            // isRight = false;


        }

        if (playerNearChest && Input.GetKey(KeyCode.P))
        {
            words.text = "You've earned\n an \nemerald !!!";
            emerald.SetActive(true);
            collect.Play();
        }

        if (Input.GetKey(KeyCode.Y) && isRight)
        {
            animator.SetTrigger("rightFight");
            death_con = true;
            attack.Play();
        }
        if (Input.GetKeyDown(KeyCode.Y) && isLeft)
        {
            animator.SetTrigger("leftFight");
            death_con = true;
            attack.Play();
        }
        if (Input.GetKey(KeyCode.Y) && isUp)
        {
            animator.SetTrigger("upFight");
            death_con = true;
            attack.Play();
        }
        if (Input.GetKeyDown(KeyCode.Y) && isDown)
        {
            animator.SetTrigger("downFight");
            death_con = true;
            attack.Play();
        }

        avatar.MovePosition(initial);
    }

    void OnTriggerEnter2D(Collider2D collison)
    {

        if (collison.gameObject.CompareTag("chest"))
        {
            playerNearChest = true;
        }

        if (collison.gameObject.CompareTag("coin"))
        {
            coin.Play();
        }

        if (collison.gameObject.CompareTag("enemy") && death_con)
        {

            enemy1.GetComponent<AIChase>().TakeDamage(25);

        }

        if (collison.gameObject.CompareTag("enemy1") && death_con)
        {

            enemy2.GetComponent<AIChase>().TakeDamage(25);

        }


        if (collison.gameObject.CompareTag("enemy2") && death_con)
        {

            enemy3.GetComponent<AIChase>().TakeDamage(25);

        }
    }


    public bool deathCon()
    {
        return death_con;
    }

    void OnTriggerExit2D(Collider2D collison)
    {

        if (collison.gameObject.CompareTag("chest"))
        {
            playerNearChest = false;
            words.text = " ";
            emerald.SetActive(false);
        }

        if (collison.gameObject.CompareTag("enemy"))
        {
            death_con = false;
        }

    }
}