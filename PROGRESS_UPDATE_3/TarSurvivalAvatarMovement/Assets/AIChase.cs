using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIChase : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public float distanceBtween;
    private float distance;
    public Animator animator;

    //public int health = 100;
    public int curr_health;

    // Start is called before the first frame update
    void Start()
    {
        //curr_health = health;

        
    }

    public void TakeDamage(int damage){
        curr_health -= damage;

        if(curr_health <= 0){
            Die();
        }
        print(curr_health);
    }

    void Die(){

        //Die animation
        animator.SetTrigger("death");
        distanceBtween = -1; 

        // Disable enemy
        Invoke("Disable", 2f);
         
    }

    void Disable(){
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if(distance < distanceBtween){
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            //transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        }
        

    }
}
