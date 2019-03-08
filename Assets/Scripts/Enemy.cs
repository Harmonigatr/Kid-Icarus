using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour{
    private Rigidbody2D rb2d;
    public int Health = 2;
    public int Attack = 1;
    private Animator anim;
    public GameObject heart;

    void Start() {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update() {
        if (Health == 0) {
            Destroy(gameObject);
            Heart h = Instantiate(heart, new Vector2(transform.position.x, transform.position.y), Quaternion.identity).GetComponent<Heart>();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        Arrrow Arrow = collision.gameObject.GetComponent<Arrrow>();
        if (Arrow == null) {return;}
        Health -= 1;
    }
}
