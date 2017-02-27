using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContoller : MonoBehaviour {

    public float maxSpeed = 5f;
    bool grounded = false;
    float groundRadius = 0.2f;
    public float jumpForce = 300f;

    public Transform groundCheck;
    public LayerMask whatIsGround;

    Animator animator;
    Rigidbody2D rigidBody;
    SpriteRenderer spriteRenderer;

    // Use this for initialization
    void Start() {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        float movement = Input.GetAxis("Horizontal");
        rigidBody.velocity = new Vector3(movement * maxSpeed, rigidBody.velocity.y);

        if (movement < 0 && !spriteRenderer.flipX) Flip();
        else if (movement > 0 && spriteRenderer.flipX) Flip();

        animator.SetFloat("Speed", Mathf.Abs(movement));
        animator.SetFloat("VSpeed", rigidBody.velocity.y);
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        animator.SetBool("Grounded", grounded);
    }

    // Update is called once per frame
    void Update() {
        if(grounded && Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("Grounded", false);
            rigidBody.AddForce(new Vector2(0, jumpForce));
        }
    }

    void Flip()
    {
        spriteRenderer.flipX = !spriteRenderer.flipX;
    }
}
