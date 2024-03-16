using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float velocity = 5f; 
    public float jumpForce = 5f;
    public Rigidbody2D rb; 

    bool jump = false; 

    void Update()
    {

        float HorizontalMove = Input.GetAxis("Horizontal");


        Vector2 move = new Vector2(HorizontalMove * velocity, rb.velocity.y);
        rb.velocity = move;


        if (Input.GetButtonDown("Jump") && !jump)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            jump = true;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Ground"))
        {
            jump = false;
        }
    }
}
