using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    GameManager manager;
    Text scoreText;
    void Start()
    {
        manager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        scoreText = GetComponent<Text>();
    }

    void Update()
    {
        scoreText.text = manager.score.ToString();
    }
}
