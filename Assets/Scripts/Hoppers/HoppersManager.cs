using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoppersManager : GameManager
{
    public int hoppers;
    public AudioSource boom, goal;
    Timer timer;

    void Awake()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        timer = FindObjectOfType<Timer>();
        timer.time = 15;
        postProcessing.SetActive(playerStats.settings.coolGraphics);
        StartCoroutine(ChangeLevel());
    }
    
    void Update()
    {
        if (gameState == GameState.playing)
        {
            if (timer.time <= 0)
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
            score += levelScore;
            level++;
            levelScore = level / 5;
            timer.time += Mathf.Clamp(hoppers, 1, 6) * 3;
            playerStats.SetVolume(FindObjectsOfType<AudioSource>());
            goal.Play();

            yield return new WaitUntil(() => IsNextLevel);
        }
    }

    public override void SavePlayer()
    {
        if (score > playerStats.bestScoreHoppers) playerStats.bestScoreHoppers = score;
        base.SavePlayer();
    }

    public override void GameOver()
    {
        boom.Play();
        SavePlayer();
        base.GameOver();
    }
}
