using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Controller control; 

    public float moveSpeed = 40f;
    float horizontalMove   = 0f;
    bool jump =  false;
    bool crouch = false;

    // Update is called once per frame
    void Update()
    {

        horizontalMove = Input.GetAxisRaw("Horizontal") * moveSpeed;
        if(Input.GetButtonDown("Jump")){
            jump = true;
        }
        if(Input.GetButton("Crouch")){
            crouch = true;
            
        }
        
    }
    void FixedUpdate(){
        //Move Character
        control.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
        crouch = false;
    }
}
