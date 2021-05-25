using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    public float MovementSpeed = 1f;
    public float JumpVelocity = 1f;

    private Rigidbody2D rb;

    //stuff for multi jumps
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int jumpsLeft;
    public int jumpsMax;

    void Start()
    {
        jumpsLeft = jumpsMax;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed; //basic left/right stuff, TO DO: make char turn


        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        if(isGrounded == true) //restores jumps to max on ground contact
        {
            jumpsLeft = jumpsMax;
        }

        if (Input.GetButtonDown("Jump") && jumpsLeft > 0)
        {
            rb.velocity = Vector2.up * JumpVelocity;
            jumpsLeft --;
        }

        else if(Input.GetButtonDown("Jump") && jumpsLeft == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * JumpVelocity;
        }

        //idea for a dash move: uses up jumps -> moves distance fast, possibly with i-frames

    }
}
