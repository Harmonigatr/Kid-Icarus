using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour {
    private Rigidbody2D rb2d;
    public int Value = 1;
    private bool isPicked, dead = false;
    public Collider2D doesPick;
    public LayerMask isPickedLayer;
    public CountDisplay CD;
    private AudioSource Audio;
    public AudioClip added;

    void Start() {
        rb2d = GetComponent<Rigidbody2D>();
        Audio = GetComponent<AudioSource>();
        //CD = GetComponent<CountDisplay>();
    }

    void Update() {
        isPicked = doesPick.IsTouchingLayers(isPickedLayer);

        if (isPicked && !dead) {
            dead = true;
            Audio.clip = added;
            Audio.Play();
            Debug.Log("added");
            transform.position = Vector3.one * 9999f;
            Destroy(gameObject, Audio.clip.length);
            CD.choice = 0;
            //CD.heart += Value;
            CD.IncrementScore(Value);
        }
    }

    /*private void OnCollisionEnter2D(Collision2D collision) {
        Player Player = collision.gameObject.GetComponent<Player>();
        if (Player == null) {return;}
        Destroy(gameObject);
    }*/
}
