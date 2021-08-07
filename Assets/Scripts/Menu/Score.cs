using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private int score = 0;
    public PlayerStats stats;
    Text scoreText;
    void Start()
    {
        scoreText = GetComponent<Text>();
    }

    void Update()
    {
        score = stats.money;
        scoreText.text = score.ToString();
    }
}
