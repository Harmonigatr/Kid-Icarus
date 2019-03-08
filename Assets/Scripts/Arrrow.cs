using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrrow : MonoBehaviour {
    public Rigidbody2D rb2d;
    public Vector2 speedVector = new Vector2();
    public Vector2 riseVector = new Vector2();
    private SpriteRenderer SprtRndrr;
    private bool isAlive = true;
    private const float ExistLim = 0.5f;
    private float speed = 10;
    private float Timer = 0.0f;
    public int Damage = 1;

    void Start() {
        rb2d = GetComponent<Rigidbody2D>();
        //rb2d = this.GetComponent<Rigidbody2D>();
        SprtRndrr = GetComponent<SpriteRenderer>();
        speedVector.x = speed;
        riseVector.y = speed;
        transform.Rotate(Vector3.forward);
        rb2d.velocity = speedVector;
    }

    void Update() {
        Timer += Time.deltaTime;
        if (isAlive) {
            if (Input.GetKeyDown(KeyCode.W)) {
                rb2d.velocity = riseVector;
            }
            if (!Input.GetKeyDown(KeyCode.W)) {
                
                //transform.Translate(speedVector, 0);
                Player Player = gameObject.GetComponent<Player>();
                //if (Player.currentState != PlayerStates.Flip) {
                //    SprtRndrr.flipX = !SprtRndrr.flipX;
                //rb2d.velocity = speedVector;
                //}
                //if (Player.currentState == PlayerStates.Flip) {
                //    SprtRndrr.flipX = !SprtRndrr.flipX;
                //    rb2d.velocity = -speedVector;  
                //}
            }
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
        }
    }
}
