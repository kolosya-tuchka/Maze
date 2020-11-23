using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public int time = 0;
    Text text;
    HoppersManager manager;
    void Start()
    {
        manager = GameObject.Find("Game Manager").GetComponent<HoppersManager>();
        text = GetComponent<Text>();
        StartCoroutine(Countdown());
    }

    void Update()
    {
        Mathf.Clamp(time, 0, 60);
        text.text = time.ToString();
    }

    IEnumerator Countdown()
    {
        while (!manager.IsGameOver())
        {
            yield return new WaitForSeconds(1);

            time--;
        }
    }

}
