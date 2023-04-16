using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float jumpSpeed;
    private Rigidbody2D rigidbody2D;

    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    public bool isGrounded;

    public int maxJumpValue;
    int maxJump;

    private void Start()
    {
        maxJump = maxJumpValue;
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        if (Input.GetMouseButtonDown(0) && maxJump > 0)
        {
            maxJump--;
            Jump();
        }
        else if (Input.GetMouseButtonDown(0) && maxJump == 0 && isGrounded)
        {
            Jump();
        }

        if (isGrounded)
        {
            maxJump = maxJumpValue;
        }
    }

    void Jump()
    {
        rigidbody2D.velocity = Vector2.zero;
        rigidbody2D.AddForce(new Vector2(0, jumpSpeed));
    }
}
