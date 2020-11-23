using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour {

    public int index;
    public Button BuyBtn, ActivateBtn;
    public GameObject mark;
    public bool IsBought;
    public int Cost;
    private int score;


    private void Update()
    {
        CheckButtons();
    }

    bool IsActive
    {
        get
        {
            return index == SM.ActiveSkinIndex;
        }
    }

    public ShopManager SM;

    public void CheckButtons()
    {
        BuyBtn.gameObject.SetActive(!IsBought);
        BuyBtn.interactable = CanBuy();

        ActivateBtn.gameObject.SetActive(IsBought);
        ActivateBtn.interactable = !IsActive;
        mark.SetActive(IsActive);

        SaveManager.Instance.SaveGame();
    }

    bool CanBuy()
    {
        return PlayerPrefs.GetInt("score") >= Cost;
    }

    public void BuyItem()
    {
        if (!CanBuy())
            return;

        IsBought = true;
        score = PlayerPrefs.GetInt("score");
        score -= Cost;
        PlayerPrefs.SetInt("score", score);

        CheckButtons();

        SaveManager.Instance.SaveGame();
    }

    public void ActivateItem()
    {
        SM.ActiveSkinIndex = index;
        SM.CheckItemButtons();
        PlayerPrefs.SetInt("Skin", index);

        SaveManager.Instance.SaveGame();
    }

}
