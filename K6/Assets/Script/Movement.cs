using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public float jumpForce;
    public float moveInput;
    //cek jika ditanah atau tidak
    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;

    //hold for higher
    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;

    //cek jika nyentuk tembok gak
    private bool isTouchingWall;
    public Transform wallCheck;
    public int jumpCounter = 1;

    //Coyote time
    private float coyoteTime = 0.1f;
    private float coyoteTimeCounter;

    void Start()
    {
      rb = GetComponent<Rigidbody2D>();
      
    }

    void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

    }

    void Update(){
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
        isTouchingWall = Physics2D.OverlapCircle(wallCheck.position, 0.5f, whatIsGround);

        if(isGrounded){
            coyoteTimeCounter = coyoteTime;
        }else{
            coyoteTimeCounter -= Time.deltaTime;
        }

        if(moveInput > 0){
            transform.eulerAngles = new Vector3(0, 0, 0);
        }else if (moveInput < 0){
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        if (coyoteTimeCounter > 0f && Input.GetButtonDown("Jump")){
            isJumping = true;
            jumpTimeCounter = jumpTime;
            coyoteTimeCounter = 0f;
            rb.velocity = Vector2.up * jumpForce;
        }
        if (Input.GetButton("Jump") && isJumping == true){
            if (jumpTimeCounter > 0){
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }else {
                isJumping = false;
                rb.gravityScale = 10;
            }
        }
        if(Input.GetButtonUp("Jump")){
            isJumping = false;
        }
        if(isGrounded){
            jumpCounter = 1;
            rb.gravityScale = 5;
        }

        if(isTouchingWall == true && isGrounded == false && moveInput != 0 && jumpCounter > 0){
            if(Input.GetButtonDown("Jump")){
            rb.velocity = Vector2.up * jumpForce;
            isJumping = true;
            jumpTimeCounter = jumpTime;
            jumpCounter--;
            }
        }
    }

    

}