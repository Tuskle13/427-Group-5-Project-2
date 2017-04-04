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

    private bool stop = false;
    private int count = 0;
    private bool timeToDisco = false;

    Animator animator;
    Rigidbody2D rigidBody;
    SpriteRenderer spriteRenderer;
    public GameObject discoBall;
    Transform discoBallTransform;
    SpriteRenderer discoBallSprite;

    // Use this for initialization
    void Start() {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        discoBallTransform = discoBall.GetComponent<Transform>();
        discoBallSprite = discoBall.GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        float movement = 0;
        if(!stop){
            movement = Input.GetAxis("Horizontal");
        }
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
        if(!stop && grounded && Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("Grounded", false);
            rigidBody.AddForce(new Vector2(0, jumpForce));
        }
        else if (stop ){
            if(discoBallTransform.localPosition.y > 1.45f){
                float step = 2 * Time.deltaTime;
                Vector3 position = discoBallTransform.position;
                discoBallTransform.position = Vector3.MoveTowards(position, new Vector3(position.x,1.45f,position.z), step);
            }else timeToDisco = true;

            if(count % 10 == 0) discoBallSprite.flipX = !discoBallSprite.flipX;

            if(timeToDisco && count == 25){
                spriteRenderer.flipX = !spriteRenderer.flipX;
                count = 0;
            }else if (timeToDisco)
                count++;

            if(timeToDisco && !GetComponentInChildren<ParticleSystem>().isPlaying){
                GetComponentInChildren<ParticleSystem>().Play();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "FinishLine"){
            stop = true;
            //GetComponentInChildren<ParticleSystem>().Play();
            //GetComponent<ParticleSystem>().Play();
        }
    }

    void Flip()
    {
        spriteRenderer.flipX = !spriteRenderer.flipX;
    }
}
