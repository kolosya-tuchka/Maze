using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeltaScoreText : MonoBehaviour
{
    Text deltaScore;
    public GameManager manager;
    void Start()
    {
        deltaScore = GetComponent<Text>();
    }

    void Update()
    {
        deltaScore.text = "+" + manager.levelScore.ToString();
    }
}
