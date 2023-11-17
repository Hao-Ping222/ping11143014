using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroler : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    public float speed;
    public float checkRadius;
    float xVelocity;
    public LayerMask platform;
    public GameObject groundCheck;
    public bool isGround;
    bool playerDead;
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        anim= GetComponent<Animator>();
    }

    
    void Update()
    {
        isGround = Physics2D.OverlapCircle(groundCheck.transform.position,checkRadius,platform);
        anim.SetBool("isGround", isGround);
        Movement();      
    }
    void Movement() {
        xVelocity = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(xVelocity * speed, rb.velocity.y);
        anim.SetFloat("speed", Mathf.Abs(rb.velocity.x));
        if (xVelocity != 0) {
            transform.localScale = new Vector3(xVelocity, 1, 1);
        }
    }
    private void OnCollisionEnter2D(Collision2D other )
    {
        if (other.gameObject.CompareTag("Fan")) {
            rb.velocity = new Vector2(rb.velocity.x, 10f);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Spike"))
        {
            anim.SetTrigger("dead");
        }
    }
    public void PlayerDead() { 
        playerDead= true;
        AgainGameover.Gameover(playerDead);
    }

}
