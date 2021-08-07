using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameManager
{
    void GameOver();
    void SavePlayer();
}


public class GameManager : MonoBehaviour, IGameManager
{
    public GameState gameState;
    public GameObject map, postProcessing;
    public PlayerStats playerStats;

    public int score, money, levelScore, level;

    public bool IsGameOver
    {
        get { return gameState == GameState.gameOver; }
    }

    public bool IsNextLevel
    {
        get { return gameState == GameState.nextLevel; }
    }


    private void Start()
    {
        level = 0;
    }

    public enum GameState
    {
       playing, nextLevel, gameOver
    }

    public virtual void GameOver()
    {
        gameState = GameState.gameOver;
    }

    public virtual void SavePlayer()
    {
        playerStats.money += money;
        SaveManager.SavePlayerStats(playerStats);
    }
}
