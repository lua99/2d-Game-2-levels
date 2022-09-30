using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public PlayerController controller;

    float horizontalMove = 0f;

    public float runSpeed = 40f;

    bool jump = false;

    bool crouch = false;

    public Animator animator;

    private void Start()
    {
        
    }

   
    
    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }
    
    private void Update()
    {
        animator.SetFloat("Speed",Mathf.Abs (horizontalMove));
        
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }



    private void FixedUpdate()
    {
        //move

        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);

        jump = false;
    }



}


