using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalScoreText : MonoBehaviour
{
    public Text score;
    GameManager manager;
    void Start()
    {
        manager = GetComponent<GameManager>();
    }

    void Update()
    {
        if (manager.IsGameOver)
        {
            score.text = "Your score: " + manager.score.ToString();
            Destroy(this);
        }
    }
}
