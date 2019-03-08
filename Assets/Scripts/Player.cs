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
    public int Health = 5;
    public LayerMask isGroundedLayer;
    private Rigidbody2D rb2d;
    private Animator anim;
    private SpriteRenderer SprtRndrr;
    private bool isGrounded,
                 toRight = true,
                 tele = false;
    public GameObject arrow;
    public Collider2D ground;
    //public Arrrow arrow;

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

        if (Input.GetButtonDown("Jump") && isGrounded) {
            rb2d.AddForce(Vector3.up * 1000);
            anim.Play("Jumping");
        }
        if (rb2d.velocity.y <= 0 && !isGrounded){
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
        if ((rb2d.velocity.x < 0 && toRight) || (rb2d.velocity.x > 0 && !toRight)) {
            toRight = !toRight;
            SprtRndrr.flipX = !SprtRndrr.flipX;
        }
        if (Input.GetKeyDown(KeyCode.S)) {
            anim.Play("Shooting");
            Arrrow a = Instantiate(arrow, new Vector2(transform.position.x, transform.position.y), Quaternion.identity).GetComponent<Arrrow>();
            //Arrrow a = Instantiate(arrow, transform.localPosition, transform.localRotation) as Arrrow;
            //GameObject a = (GameObject) Instantiate(arrow, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
            if (!toRight) {
                //the if statement works, but the content doesn't.
                //Debug.Log("hello");
                //a.rb2d.velocity = -1 * a.speedVector;
                a.rb2d.velocity *= -1;
                //a.GetComponent<Arrrow>().Damage = 100;
                //a.GetComponent<Rigidbody2D>().velocity = new Vector2(a.GetComponent<Arrrow>().speedVector.x * -1000000, 0);
               //a.transform.Translate(a.rb2d.velocity * -1);
            }
        }
        if (Health == 0) {
            Destroy(gameObject);
        }

        if (rb2d.position.x <= -tp && tele == false) {
            teleVector.x = tp;
            rb2d.position = teleVector;
            tele = true;
        }
        if (rb2d.position.x >= tp && tele == false) {
            teleVector.x = -tp;
            rb2d.position = teleVector;
            tele = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        Enemy Enemy = collision.gameObject.GetComponent<Enemy>();
        if (Enemy == null) {return;}
        Health -= Enemy.Attack;
    }
}