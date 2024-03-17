using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float velocity = 5f;
    public float jumpForce = 5f;
    public Rigidbody2D rb;
    public Sprite sprite1; 
    public Sprite sprite2;
    public Sprite sprite3;

    bool jump = false;
    bool canJump = true; 
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = sprite1;
        transform.localScale = new Vector3(1.5f, 1.7f, 1);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            GetComponent<SpriteRenderer>().sprite = sprite1;
            transform.localScale = new Vector3(1.5f, 1.7f, 1); 
            canJump = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            GetComponent<SpriteRenderer>().sprite = sprite2;
            transform.localScale = new Vector3(1f, 1f, 1); 
            canJump = false; 
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            GetComponent<SpriteRenderer>().sprite = sprite3;
            transform.localScale = new Vector3(3f, 3f, 1);
            canJump = false;
        }

        float HorizontalMove = Input.GetAxis("Horizontal");

        Vector2 move = new Vector2(HorizontalMove * velocity, rb.velocity.y);
        rb.velocity = move;

        if (Input.GetButtonDown("Jump") && !jump && canJump)
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