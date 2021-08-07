using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float time = 0;
    Text text;
    HoppersManager manager;
    void Start()
    {
        manager = FindObjectOfType<HoppersManager>();
        text = GetComponent<Text>();
    }

    void Update()
    {
        if (manager.IsGameOver) return;
        time -= Time.deltaTime;
        text.text = Mathf.CeilToInt(time).ToString();
    }

}
