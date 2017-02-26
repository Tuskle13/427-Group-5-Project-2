using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContoller : MonoBehaviour {

    public float maxSpeed = 2f;
    bool grounded = true;

    public Transform groundCheck;
    float groundRadius = 0.2f;
    public LayerMask whatIsGround;
    public float jumpForce = 500f;

    Animator animator;
    Rigidbody2D rigidBody;
    SpriteRenderer spriteRenderer;

    // Use this for initialization
    void Start() {
        //animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        float movement = Input.GetAxis("Horizontal");
        rigidBody.velocity = new Vector3(movement * maxSpeed, rigidBody.velocity.y);

        if (movement < 0 && !spriteRenderer.flipX) Flip();
        else if (movement > 0 && spriteRenderer.flipX) Flip();
    }

    // Update is called once per frame
    void Update() {
        if(grounded && Input.GetKeyDown(KeyCode.Space))
        {
            rigidBody.AddForce(new Vector2(0, jumpForce));
        }
    }

    void Flip()
    {
        spriteRenderer.flipX = !spriteRenderer.flipX;
    }
}
