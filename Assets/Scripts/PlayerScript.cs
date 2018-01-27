using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    public float Speed = 10.0f;
    public float Jump = 0.3f;
    public LayerMask GroundLayer;

    private Animator animator;
    private Transform groundCheck;

    private Rigidbody2D rb2d;

    private bool isGrounded;

    void Start()
    {
        animator = GetComponent<Animator>();
        groundCheck = transform.Find("GroundCheck");
        rb2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        bool isGrounded = Physics2D.OverlapPoint(groundCheck.position, GroundLayer);

        if (Input.GetButton("Jump"))
        {
            if (isGrounded)
            {
                rb2d.AddForce(Vector2.up * Jump, ForceMode2D.Impulse);
            }
        }

        animator.SetBool("isGrounded", isGrounded);

        float hSpeed = Input.GetAxis("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(hSpeed));

        if (hSpeed > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (hSpeed < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        this.GetComponent<Rigidbody2D>().velocity = new Vector2(hSpeed * Speed, this.GetComponent<Rigidbody2D>().velocity.y);
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            if (isGrounded)
            {
                isGrounded = false;
            }
        }

    }

}