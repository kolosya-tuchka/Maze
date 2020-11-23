using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private int score = 0;
    Text scoreText;
    void Start()
    {
        scoreText = GetComponent<Text>();
        score = PlayerPrefs.GetInt("score", score);
    }

    void Update()
    {
        scoreText.text = score.ToString();
    }
}
