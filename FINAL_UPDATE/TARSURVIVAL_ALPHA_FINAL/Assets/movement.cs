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
    public GameObject player;
    public Ship shipScript;


    //private bool hasSliced;
    public GameObject chest;
    public GameObject emerald;
    public Text words;

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

        // Fight controls
        isDown = false;
        isUp = false;
        isLeft = false;
        isRight = false;

        GameObject shipObject = GameObject.Find("YourShipObjectName");
        shipScript = shipObject.GetComponent<Ship>();

    }

    void Update()
    {
        CheckCollisionWithDock(transform.position);
        
        // Get input for movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Update the initial position based on input
        initial += new Vector2(horizontalInput, verticalInput) * displacement;

        // Set animation based on movement direction
        UpdateAnimation(horizontalInput, verticalInput);

        // Check for interaction with chest
        if (playerNearChest && Input.GetKey(KeyCode.P))
        {
            words.text = "You've earned\n an \nemerald !!!";
            emerald.SetActive(true);
            collect.Play();
        }

        // Check for attack input
        CheckAttackInput();

        // Move the avatar to the updated position
        avatar.MovePosition(initial);

    }

    void UpdateAnimation(float horizontalInput, float verticalInput)
    {
        animator.SetBool("walkleft", horizontalInput < 0);
        animator.SetBool("walkforward", verticalInput > 0);
        animator.SetBool("walkbackward", verticalInput < 0);
        animator.SetBool("walkright", horizontalInput > 0);
    }

    void CheckAttackInput()
    {
        if (Input.GetKey(KeyCode.Y))
        {
            if (isRight)
            {
                animator.SetTrigger("rightFight");
                attack.Play();
            }
            else if (isLeft)
            {
                animator.SetTrigger("leftFight");
                attack.Play();
            }
            else if (isUp)
            {
                animator.SetTrigger("upFight");
                attack.Play();
            }
            else if (isDown)
            {
                animator.SetTrigger("downFight");
                attack.Play();
            }
        }
    }
    bool CheckCollisionWithDock(Vector3 position)
    {
        
        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, 1.0f); // Adjust the radius as needed

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("dock"))
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    player.SetActive(false);
                    shipScript.moveOk = true;

                }
            }
        }

        return false; // No collision with dock or "SpawnPos" not found
    }
}
