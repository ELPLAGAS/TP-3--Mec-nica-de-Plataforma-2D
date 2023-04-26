using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;

    private Rigidbody2D rb;
    private bool isGrounded;
    private bool isJumping;
    private bool gameOver;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!gameOver)
        {
            float moveDirection = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);

            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                isJumping = true;
                rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            }

            CheckIfPlayerIsOutOfBounds();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            GameManager.instance.AddCoin(1);
            Destroy(other.gameObject);
        }
    }

    private void CheckIfPlayerIsOutOfBounds()
    {
        if (transform.position.y < -22f)
        {
            gameOver = true;
            GameManager.instance.RestartGame();
        }
    }
}