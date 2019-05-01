using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDisplay : MonoBehaviour {

    private static int _count;
    private static int _heart;
    private static int _health;
    private static int _score;
    public UnityEngine.UI.Text Heart;
    public UnityEngine.UI.Text Health;
    public UnityEngine.UI.Text Score;
    public int //start,
               //heart,
               //health,
               //score,
               choice;

    public void IncrementScore(int byAmount) {
        //_count += byAmount;
        if (choice == 0) {
            _heart += byAmount;
            Debug.Log("Heart = " + _heart);
        }
        else if (choice == 1) {
            _health -= byAmount;
            Debug.Log("Health = " + _health);
        }
        else if (choice == 2) {
            _score += byAmount;
            Debug.Log("Score = " + _score);
        }
    }

    void Start() {
        /*heart = health = score = new int();
        if (choice == 0) _heart = 0;
        if (choice == 1) _health = 5;
        if (choice == 2) _score = 0;*/
        _heart = 0;
        _health = 5;
        _score = 0;
    }

    private void Update() {
        //if (choice == 0) {
            //_count = heart;
            Heart.text = "X " + _heart.ToString();
        //}
        //if (choice == 1) {
            //_count = health;
            Health.text = "X " + _health.ToString();
        //}
        //if (choice == 2) {
            //_count = score;
            Score.text = "X " + _score.ToString();
        //}
        //Count.text = "X " + _count.ToString();
    }
}
