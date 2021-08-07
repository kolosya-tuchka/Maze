using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGameManager : GameManager
{
    GameObject player;
    public GameObject bomb;
    MazeSpawner spawner;
    void Awake()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        player = GameObject.FindGameObjectWithTag("Player");
        spawner = GetComponent<MazeSpawner>();
        postProcessing.SetActive(playerStats.settings.coolGraphics);
        StartCoroutine(ChangeLevel());
    }

    IEnumerator ChangeLevel()
    {
        while (true)
        {
            foreach (var obj in GameObject.FindGameObjectsWithTag("Cell"))
            {
                GameObject.Destroy(obj);
            }
            foreach (var obj in GameObject.FindGameObjectsWithTag("Bomb"))
            {
                GameObject.Destroy(obj);
            }
            map.transform.position = Vector3.zero;
            map.transform.eulerAngles = Vector3.zero;
            player.transform.position = new Vector3(5, 2.275f, 5);
            spawner.Spawn();
            levelScore = spawner.GetComponent<MazeGenerator>().distance / 5;
            level++;
            gameState = GameState.playing;
            playerStats.SetVolume(FindObjectsOfType<AudioSource>());

            yield return new WaitUntil(() => IsNextLevel);
        }
    }

    public override void SavePlayer()
    {
        if (score > playerStats.bestScoreMaze) playerStats.bestScoreMaze = score;
        base.SavePlayer();
    }

    public override void GameOver()
    {
        base.GameOver();
    }
}
