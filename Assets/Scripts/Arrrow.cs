using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrrow : MonoBehaviour {
    public Rigidbody2D rb2d;
    public Vector2 speedVector = new Vector2();
    public Vector2 riseVector = new Vector2();
    private SpriteRenderer SprtRndrr;
    private BoxCollider2D bxClldr;
    private bool isAlive = true;
    private const float ExistLim = 0.5f;
    private float speed = 10;
    private float Timer = 0.0f;
    public int Damage = 1;
    public void Flip(bool bby)   { if (SprtRndrr) { SprtRndrr.flipX = bby;  } }
    private bool isHit;
    public Collider2D doesHit;
    public LayerMask isHitLayer;

    void Start() {
        rb2d = GetComponent<Rigidbody2D>();
        SprtRndrr = GetComponent<SpriteRenderer>();
        bxClldr = GetComponent<BoxCollider2D>();
        speedVector.x = speed;//Player.AroSpeed;
        //speedVector.y = Player.AroSpeed;
        //transform.Rotate(Vector3.forward);
        //if (!Input.GetKeyDown(KeyCode.W)) {
        //rb2d.velocity = speedVector;
        //}
        /*if (Input.GetKeyDown(KeyCode.W)) {
            rb2d.velocity = riseVector;
        }*/
    }

    void Update() {
        Timer += Time.deltaTime;
        //if (!Input.GetKeyDown(KeyCode.W)) {
        rb2d.velocity = speedVector;
        //}
        /*if (Input.GetKeyDown(KeyCode.W)) {
            rb2d.velocity = riseVector;
        }*/
        isHit = doesHit.IsTouchingLayers(isHitLayer);

        if (isHit) {
            Destroy(gameObject);
        }

        if (Timer >= ExistLim) {
            Destroy(gameObject);
            if (!isAlive) { return; }
            isAlive = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        Player Player = collision.gameObject.GetComponent<Player>();
        if (Player == null) {
            Destroy(gameObject);
            if (!isAlive) { return; }
            isAlive = false;
            bxClldr.isTrigger = true;
        }
        else if (Player != null) {
            bxClldr.isTrigger = false;
        }
    }
}
