using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    Text score;
    public GameManager manager;
    void Awake()
    {
        score = GetComponent<Text>();
    }

    void Update()
    {
        score.text = manager.score.ToString();
    }
}
