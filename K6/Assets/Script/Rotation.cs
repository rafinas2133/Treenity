using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{

    [SerializeField] private float speed = 2f;

    
    void Update()
    {
        //Memutar trap saw
        transform.Rotate(0, 0, 360 * this.speed * Time.deltaTime);
    }
}
