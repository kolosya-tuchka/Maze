using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameState gameState;
    public GameObject map;
    public int score;
    public GameObject gameOverCanvas;

    private void Start()
    {
        gameOverCanvas.SetActive(false);
    }

    public enum GameState
    {
       playing, nextLevel, gameOver
    }
    public bool IsNextLevel()
    {
        return gameState == GameState.nextLevel;
    }

    public bool IsGameOver()
    {
        return gameState == GameState.gameOver;
    }

    public void GameOver()
    {
        gameOverCanvas.SetActive(true);
        gameState = GameState.gameOver;
        int allScore = PlayerPrefs.GetInt("score");
        allScore += score;
        PlayerPrefs.SetInt("score", allScore);
    }
}
