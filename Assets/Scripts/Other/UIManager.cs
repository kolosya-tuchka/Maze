using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameManager manager;
    public GameObject game, gameOver, pause;
    bool isPaused;

    void Start()
    {
        isPaused = false;
        SwitchWindow(game);
    }

    void Update()
    {
        if (manager.IsGameOver)
        {
            SwitchWindow(gameOver);
        }    
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                SwitchWindow(game);
            }
            else
            {
                SwitchWindow(pause);
            }
        }
    }

    public void SwitchWindow(GameObject window)
    {
        isPaused = window == pause;
        Time.timeScale = isPaused ? 0 : 1;

        game.SetActive(false);
        gameOver.SetActive(false);
        pause.SetActive(false);

        window.SetActive(true);
    }

    public void Menu()
    {
        manager.SavePlayer();
        Destroy(manager.playerStats.gameObject);
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
