using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float followSpeed = 2f;
    public float yOffSet = 1f;
    public Transform target;
    Vector3 newPos;
    void Awake()
    {
        newPos = target.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Mathf.Abs(target.transform.position.x - gameObject.transform.position.x) > 4 || Mathf.Abs(target.transform.position.y - gameObject.transform.position.y) > 2f){
            newPos = new Vector3(target.position.x, target.position.y + yOffSet, -10f);
            transform.position = Vector3.Slerp(transform.position, newPos, followSpeed*Time.fixedDeltaTime);
        }
    }
}