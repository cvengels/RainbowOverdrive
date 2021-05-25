using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    public float MovementSpeed = 1f;
    public float JumpVelocity = 1f;

    private Rigidbody2D rb;

    //stuff for double/multi jumps, which aint working yet
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int jumps;
    public int jumpsAmount;

    void Start()
    {
        jumps = jumpsAmount;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed; //basic left/right stuff, TO DO: make char turn


        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        if(isGrounded == true)
        {
            jumps = jumpsAmount;
        }

        if (Input.GetButtonDown("Jump") && jumps > 0)
        {
            rb.velocity = Vector2.up * JumpVelocity;
            jumps --;
        }

        else if(Input.GetButtonDown("Jump") && jumps == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * JumpVelocity;
        }

    }
}
