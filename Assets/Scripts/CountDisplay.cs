using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDisplay : MonoBehaviour {

    private static int _score;
    public UnityEngine.UI.Text Score;
    public int start = 0,
               health,
               heart,
               score,
               choice;

    public void IncrementScore(int byAmount) {
        _score += byAmount;
        for (int i = 0; i <= 20; i++) {
            Debug.Log(heart);
        }
    }

    void Start() {
        health = heart = score = new int();
        if (choice == 0) health = start;
        else if (choice == 1) heart = start;
        else if (choice == 2) score = start;
    }

    private void Update() {
        if (choice == 0) _score = health;
        else if (choice == 1) _score = heart;
        else if (choice == 2) _score = score;
        Score.text = "X " + _score.ToString();
    }
}
