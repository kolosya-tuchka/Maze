using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoppersManager : GameManager
{
    public int hoppers;
    Timer timer;

    void Start()
    {
        gameOverCanvas.SetActive(false);
        timer = GameObject.Find("Timer").GetComponent<Timer>();
        timer.time = 15;
        StartCoroutine(ChangeLevel());
    }
    
    void Update()
    {
        if (gameState == GameState.playing)
        {
            if (timer.time == 0)
                GameOver();

            if (hoppers == 0)
                gameState = GameState.nextLevel;
        }
    }

    IEnumerator ChangeLevel()
    {
        while (true)
        {
            foreach (var obj in GameObject.FindGameObjectsWithTag("Cell"))
            {
                GameObject.Destroy(obj);
            }
            map.transform.position = Vector3.zero;
            map.transform.eulerAngles = Vector3.zero;
            GetComponent<HoppersSpawner>().Spawn();
            gameState = GameState.playing;
            timer.time += hoppers * 3;

            yield return new WaitUntil(IsNextLevel);
        }
    }
}
