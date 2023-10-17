using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public float FollowSpeed = 2f;
    public Transform target;

    // Update is called once per frame
    void Update()
    {
       Vector3 newpos= new Vector3(target.position.x,0, 
       -10f);
       transform.position = Vector3.Slerp(transform.position,newpos,
       FollowSpeed*Time.deltaTime); 
    }
}
