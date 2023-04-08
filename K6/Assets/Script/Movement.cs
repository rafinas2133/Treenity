using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //FIELDS
    public Animator animator;
    public AudioSource jumpSfx;
    private Rigidbody2D rb;
    public float speed;
    public float jumpForce;
    [SerializeField] private float moveInput;
    private bool isFacingRight = true;
    public Transform wallCheck;
    public Transform groundCheck;
    public LayerMask whatIsGround;

    //Cek jika ditanah gak
    private bool isGrounded;
    public float checkRadius;
    

    //Hold for higher jump
    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;

    //Cek jika nyentuk tembok gak
    private bool isTouchingWall;
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
        //untuk jalan kanan kiri
        moveInput = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(moveInput));
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        
        

    }

    void Update(){

        //Untuk mengecek ditanah atau di tembok dan mengembalikan nilai true atau false
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        isTouchingWall = Physics2D.OverlapCircle(wallCheck.position, 0.5f, whatIsGround);

        //Untuk ngisi waktu coyote timenya
        if(isGrounded){
            coyoteTimeCounter = coyoteTime;
        }else{
            coyoteTimeCounter -= Time.deltaTime;
        }

        //Playernya menghadap sesuai arahnya
        if(moveInput > 0 && !isFacingRight){
            //transform.eulerAngles = new Vector3(0, 0, 0);
            Flip();
        }else if (moveInput < 0 && isFacingRight){
            //transform.eulerAngles = new Vector3(0, 180, 0);
            Flip();
        }


        //Mekanisme jumpnya menggunakan coyote time 
        if (coyoteTimeCounter > 0f && Input.GetButtonDown("Jump")){
            isJumping = true;
            jumpTimeCounter = jumpTime;
            coyoteTimeCounter = 0f;
            rb.velocity = Vector2.up * jumpForce;
            
            
        }

        //Sistem untuk hold for higher jump
        if (Input.GetButton("Jump") && isJumping == true){
            animator.SetBool("isJumping", true);
            jumpSfx.Play();
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
        //Untuk merestart value ke awal ketika menyentuh tanah
        if(isGrounded){
            jumpCounter = 1;
            rb.gravityScale = 5;
            animator.SetBool("isJumping", false);
        }

        //Sistem Wall Jump
        if(isTouchingWall == true && isGrounded == false && moveInput != 0 && jumpCounter > 0){
            if(Input.GetButtonDown("Jump")){
            rb.velocity = Vector2.up * jumpForce;
            isJumping = true;
            jumpTimeCounter = jumpTime;
            jumpCounter--;
            }
        }
        
        


    }
    void Flip(){
        isFacingRight = !isFacingRight;
        transform.Rotate(0f, 180f, 0f);
    }

}