using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionBehaviour : MonoBehaviour
{

    public Transform objectPosition;

    void Start()
    {
        transform.localPosition = new Vector3(objectPosition.localPosition.x, objectPosition.localPosition.y, objectPosition.localPosition.z);
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector3(objectPosition.localPosition.x, objectPosition.localPosition.y, objectPosition.localPosition.z);
    }
}
