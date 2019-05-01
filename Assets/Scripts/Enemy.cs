using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour{
    private Rigidbody2D rb2d;
    public int Health = 1,
               Attack = 1,
               Value = 100;
    private bool isArrowed;
    public Collider2D doesArrow;
    public LayerMask isArrowedLayer;
    public GameObject heart;
    public CountDisplay CD;
    private Animator anim;
    private AudioSource Audio;
    public AudioClip ded;

    void Start() {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        Audio = GetComponent<AudioSource>();
        //CD = GetComponent<CountDisplay>();
    }

    void Update() {
        isArrowed = doesArrow.IsTouchingLayers(isArrowedLayer);

        if (isArrowed) {
            Health -= 1;
        }

        if (Health == 0) {
            Health--;
            Audio.clip = ded;
            Audio.Play();
            Debug.Log("ded");
            Heart h = Instantiate(heart, new Vector2(transform.position.x, transform.position.y), Quaternion.identity).GetComponent<Heart>();
            transform.position = Vector3.one * 9999f;
            Destroy(gameObject, Audio.clip.length);
            CD.choice = 2;
            //CD.score += Value;
            CD.IncrementScore(Value);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        Arrrow Arrow = collision.gameObject.GetComponent<Arrrow>();
        if (Arrow == null) {return;}
        Health -= 1;
    }
}
