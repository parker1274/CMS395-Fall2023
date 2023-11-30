using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Ship shipScript;
    public float FollowSpeed = 2f;
    public GameObject target1;
    public GameObject target2;
    GameObject currentTarget;
    // Start is called before the first frame update
    void Start()
    {
        GameObject shipObject = GameObject.Find("YourShipObjectName");

        // Get the Ship script component from the GameObject
        shipScript = shipObject.GetComponent<Ship>();

        // Now you can access the isShipActive variable
        
    }


    // Update is called once per frame
    void Update()
    {
        bool isShipActiveValue = shipScript.moveOk;
        if (isShipActiveValue == true)
        {
            currentTarget = target1;
        } else {
            currentTarget = target2;
        }


        Vector3 newpos = new Vector3(currentTarget.transform.position.x, currentTarget.transform.position.y, currentTarget.transform.position.z - 10);
        transform.position = Vector3.Slerp(transform.position, newpos, FollowSpeed * Time.deltaTime);
    }
}
