using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Animator anim;
    public Rigidbody2D rb;
   [SerializeField]private float speed = 5f;
    private bool facingRight=true;

    private float movingInput;
   [SerializeField] private float jumpForce = 12;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius;
    [SerializeField]
    private LayerMask whatIsGround;
    private bool isGrounded;



    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        movingInput = Input.GetAxisRaw("Horizontal");

        

        AnimatorController();

        if(rb.velocity.x>0 && !facingRight)
        {
            Flip();
        }
        else if(rb.velocity.x<0 && facingRight)
        {
            Flip();
        }

        CollisionCheck();
    }

    private  void Jump()
    {
        if(isGrounded)
        
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(movingInput * speed, rb.velocity.y);
    }

    
    private void Flip()
    {
        facingRight =! facingRight;
        transform.Rotate(0, 180, 0);
    }
    
    private void AnimatorController()
    {
        bool isMoving = rb.velocity.x != 0;

        anim.SetBool("IsMoving", isMoving);
    }

    void CollisionCheck()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}

