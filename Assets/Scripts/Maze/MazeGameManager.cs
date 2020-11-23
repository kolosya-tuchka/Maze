using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGameManager : GameManager
{
    GameObject player;
    public GameObject bomb;
    MazeSpawner spawner;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        spawner = GetComponent<MazeSpawner>();
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
            gameState = GameState.playing;

            yield return new WaitUntil(IsNextLevel);
        }
    }
}
