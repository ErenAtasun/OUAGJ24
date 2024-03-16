using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float velocity = 5f;
    public float jumpForce = 5f;
    public Rigidbody2D rb;
    public Sprite sprite1; // Birinci sprite
    public Sprite sprite2; // �kinci sprite

    bool jump = false;
    bool canJump = true; // Z�plama yetene�i kontrol�
    void Start()
    {
        // Oyun ba�lad���nda otomatik olarak 1. durumu ayarla
        GetComponent<SpriteRenderer>().sprite = sprite1;
        transform.localScale = new Vector3(1, 1, 1);
    }
    void Update()
    {
        // 1 tu�u kontrol�
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            // Sprite'� ve boyutu de�i�tir
            GetComponent<SpriteRenderer>().sprite = sprite1;
            transform.localScale = new Vector3(1, 1, 1); // Orjinal boyuta d�n
            canJump = true; // Z�plama yetene�ini a�
        }
        // 2 tu�u kontrol�
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            // Sprite'� ve boyutu de�i�tir
            GetComponent<SpriteRenderer>().sprite = sprite2;
            transform.localScale = new Vector3(0.5f, 0.5f, 1); // Boyutu yar�ya indir
            canJump = false; // Z�plama yetene�ini kapat
        }

        float HorizontalMove = Input.GetAxis("Horizontal");

        Vector2 move = new Vector2(HorizontalMove * velocity, rb.velocity.y);
        rb.velocity = move;

        // Z�plama yetene�ine g�re kontrol yap
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