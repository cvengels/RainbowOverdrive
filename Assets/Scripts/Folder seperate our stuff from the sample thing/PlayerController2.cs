using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    public float MovementSpeed = 1f;
    public float JumpVelocity = 1f;

    private Rigidbody2D rb;

    //stuff for double/multi jumps
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    public int jumpsAmount;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed; //basic left/right stuff, TO DO: make char turn


        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);


        if (Input.GetButton("Jump")) //aint really working like this, sort of a placeholder
        {
        transform.position += new Vector3(0, 2, 0) * Time.deltaTime * JumpVelocity;
        }

    }
}
