using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        if (Input.touches.Any(x=>x.phase==TouchPhase.Began) && maxJump > 0)
        {
            maxJump--;
            Jump();
        }
        else if (Input.touches.Any(x=>x.phase==TouchPhase.Began) && maxJump == 0 && isGrounded)
        {
            Jump();
        }

        if (isGrounded)
        {
            maxJump = maxJumpValue;
        }

        if (isGrounded == false)
        {
            FindObjectOfType<AudioManager>().Play("Land");
        } 
    }

    void Jump()
    {
        FindObjectOfType<AudioManager>().Play("Jump");
        rigidbody2D.velocity = Vector2.zero;
        rigidbody2D.AddForce(new Vector2(0, jumpSpeed));
    }
}
