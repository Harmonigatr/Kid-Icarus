using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    private Vector2 speedVector = new Vector2();
    private Vector2 stopVector = new Vector2();
    private Vector2 fallVector = new Vector2();
    private Vector2 teleVector = new Vector2();
    public float JumpForce = 5,
                 stop = 0,
                 speed = -10,
                 fall = -1,
                 tp = 8,
                 groundCheckRadious;
    public int Health = 5,
               AroSpeed = 10;
    public LayerMask isGroundedLayer;
    private Rigidbody2D rb2d;
    private Animator anim;
    private SpriteRenderer SprtRndrr;
    private bool isGrounded,
                 toRight = true;
    public GameObject arrow;
    public Collider2D ground;
    private Arrrow a;

    void Start() {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        SprtRndrr = GetComponent<SpriteRenderer>();
        
        speedVector = rb2d.velocity;
        stopVector = rb2d.velocity;
        fallVector = rb2d.velocity;
        teleVector = rb2d.position;
    }

    void Update() {
        speedVector = rb2d.velocity;
        stopVector = rb2d.velocity;
        fallVector = rb2d.velocity;
        teleVector = rb2d.position;

        isGrounded = ground.IsTouchingLayers(isGroundedLayer);
        //Physics2D.OverlapArea(new Vector2(transform.position.x - groundCheckRadious, transform.position.y - groundCheckRadious),
        //new Vector2(transform.position.x + groundCheckRadious, transform.position.y - groundCheckRadious), isGroundedLayer);

        if (rb2d.position.x <= -tp) {
            teleVector.x = tp;
            transform.position = teleVector;
        }
        if (rb2d.position.x >= tp) {
            teleVector.x = -tp;
            transform.position = teleVector;
        }

        if (Input.GetButtonDown("Jump") && isGrounded) {
            rb2d.AddForce(Vector3.up * 1000);
            anim.Play("Jumping");
        }
        if (rb2d.velocity.y <= 0 && !isGrounded) {
            //rb2d.AddForce(Vector3.down * 10);
            //fallVector.y = fall;
            rb2d.velocity = fallVector;
            anim.Play("Falling");
            if (rb2d.velocity.y <= 0 && isGrounded){
                anim.Play("Idle");
            }
        }
        if (Input.GetKeyDown(KeyCode.A)) {
            speedVector.x = speed;
            rb2d.velocity = speedVector;
            if (isGrounded) {
                anim.Play("Walking");
            }
        }
        if (Input.GetKeyUp(KeyCode.A)) {
            stopVector.x = stop;
            rb2d.velocity = stopVector;
            if (isGrounded) {
                anim.Play("Idle");
            }
        }
        if (Input.GetKeyDown(KeyCode.D)) {
            speedVector.x = -speed;
            rb2d.velocity = speedVector;
            if (isGrounded) {
                anim.Play("Walking");
            }
        }
        if (Input.GetKeyUp(KeyCode.D)) {
            stopVector.x = stop;
            rb2d.velocity = stopVector;
            if (isGrounded) {
                anim.Play("Idle");
            }
        }
        
        if (Input.GetKeyDown(KeyCode.S)) {
            anim.Play("Shooting");
            a = Instantiate(arrow, new Vector2(transform.position.x, transform.position.y), Quaternion.identity).GetComponent<Arrrow>();
        }

        if ((rb2d.velocity.x < 0 && toRight) || (rb2d.velocity.x > 0 && !toRight)) {
            toRight = !toRight;
            SprtRndrr.flipX = !SprtRndrr.flipX;
        }

        a.speedVector.x = -speed;
        if (!toRight) {
            a.Flip(SprtRndrr.flipX);
            a.speedVector.x *= -1;
        }

        /*if (!toRight) {
            AroSpeed *= -1;
        }
        if (toRight) {
            AroSpeed = 10;
        }*/

        if (Health == 0) {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        Enemy Enemy = collision.gameObject.GetComponent<Enemy>();
        if (Enemy == null) {return;}
        Health -= Enemy.Attack;
    }
}