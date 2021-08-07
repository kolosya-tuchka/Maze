using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject shop;
    public GameObject mainMenu;
    public GameObject selectGame;
    public GameObject settings;

    private void Start()
    {
        shop.SetActive(false);
        mainMenu.SetActive(true);
        selectGame.SetActive(false);
        settings.SetActive(false);
    }

    public void PlayMaze()
    {
       SceneManager.LoadScene(1);
    }
    public void PlayHoppers()
    {
        SceneManager.LoadScene(2);
    }

    public void SelectGameEnter()
    {
        mainMenu.SetActive(false);
        selectGame.SetActive(true);
    }
    public void SelectGameExit()
    {
        mainMenu.SetActive(true);
        selectGame.SetActive(false);
    }

    public void Shop()
    {
        shop.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void ExitShop()
    {
        shop.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void Settings()
    {
        settings.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void ExitSettings()
    {
        settings.SetActive(false);
        mainMenu.SetActive(true);
    }
}
