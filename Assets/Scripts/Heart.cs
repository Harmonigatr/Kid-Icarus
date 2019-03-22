using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour {
    private Rigidbody2D rb2d;
    public int Value = 1;
    private bool isPicked;
    public Collider2D doesPick;
    public LayerMask isPickedLayer;
    public CountDisplay CD;

    void Start() {
        rb2d = GetComponent<Rigidbody2D>();
        //CD = GetComponent<CountDisplay>();
    }

    void Update() {
        isPicked = doesPick.IsTouchingLayers(isPickedLayer);

        if (isPicked) {
            Destroy(gameObject);
            CD.heart += Value;
            CD.IncrementScore(Value);
        }
    }

    /*private void OnCollisionEnter2D(Collision2D collision) {
        Player Player = collision.gameObject.GetComponent<Player>();
        if (Player == null) {return;}
        Destroy(gameObject);
    }*/
}
