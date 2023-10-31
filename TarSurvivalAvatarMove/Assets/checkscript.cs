using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkscript : MonoBehaviour
{
   // Start is called before the first frame update
        Rigidbody2D rd;
        GameObject targetObject; 
        public Vector3 targetPosition;
        Vector3 chestpos;

        void checkschest(){
                if (targetPosition == chestpos){
                        gameObject.SetActive(false);
                }
        }

        void Start ()
        {
                chestpos = rd.transform.localPosition.x;
                targetObject = GameObject.FindWithTag("player");
                targetPosition = targetObject.transform.position.x; 
                checkschest();
        }

        // // Update is called once per frame
        // void OnTriggerEnter2D(Collider2D other)
        // {
        
        //     if ((other.gameObject.CompareTag("player")) )
        //     {  
        //         if (Input.GetKey(KeyCode.P)){
        //             gameObject.SetActive(false);
        //         }
        //     }

        // }
        // Start is called before the first frame update
}
