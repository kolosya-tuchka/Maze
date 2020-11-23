using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject shop;
    public GameObject mainMenu;
    public GameObject Cart;
    public GameObject Exit;
    public GameObject selectGame;
    private RectTransform rectTransform1;
    private RectTransform rectTransform2;

    private void Start()
    {
        shop.SetActive(false);
        mainMenu.SetActive(true);
        selectGame.SetActive(false);
        rectTransform1 = Cart.GetComponent<RectTransform>();
        rectTransform2 = Exit.GetComponent<RectTransform>();
    }
    public void PlayMaze()
    {
        if (Input.GetMouseButtonUp(0)) SceneManager.LoadScene(1);
    }
    public void PlayHoppers()
    {
        if (Input.GetMouseButtonUp(0)) SceneManager.LoadScene(2);
    }

    public void SelectGameEnter()
    {
        if (Input.GetMouseButtonUp(0))
        {
            mainMenu.SetActive(false);
            selectGame.SetActive(true);
        }
    }
    public void SelectGameExit()
    {
        if (Input.GetMouseButtonUp(0))
        {
            mainMenu.SetActive(true);
            selectGame.SetActive(false);
        }
    }

    public void Menu()
    {
        if (Input.GetMouseButtonUp(0)) SceneManager.LoadScene(0);
    }

    public void Shop()
    {
        rectTransform2.localScale = new Vector3(1, 1, 1);
        shop.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void ExitShop()
    {
        rectTransform1.localScale = new Vector3(1, 1, 1);
        shop.SetActive(false);
        mainMenu.SetActive(true);
    }
}
