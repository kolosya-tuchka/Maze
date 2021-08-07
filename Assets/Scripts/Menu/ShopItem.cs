using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour {

    public GameObject itemObject;
    public int index;
    public Button BuyBtn, ActivateBtn;
    public GameObject mark;
    public bool IsBought;
    public int Cost;
    public Text costText;
    private int score;

    private void Start()
    {
        SetIndex();
        CheckButtons();
        costText.text = Cost.ToString();
    }

    bool IsActive
    {
        get
        {
            return index == SM.ActiveIndex;
        }
    }

    public ShopManager SM;

    void SetIndex()
    {
        for (int i = 0; i < SM.Items.Capacity; ++i)
        {
            if (this == SM.Items[i])
            {
                index = i;
                return;
            }
        }
    }

    public void CheckButtons()
    {
        BuyBtn.gameObject.SetActive(!IsBought);
        BuyBtn.interactable = CanBuy();

        ActivateBtn.gameObject.SetActive(IsBought);
        ActivateBtn.interactable = !IsActive;
        mark.SetActive(IsActive);

        SaveManager.SaveShop(SM);
    }

    bool CanBuy()
    {
        return SM.stats.money >= Cost;
    }

    public void BuyItem()
    {
        if (!CanBuy())
            return;

        IsBought = true;
        SM.stats.money -= Cost;
        SM.BuySound.Play();

        CheckButtons();

        SaveManager.SavePlayerStats(SM.stats);
        SaveManager.SaveShop(SM);
    }

    public void ActivateItem()
    {
        SM.ActiveIndex = index;
        SM.CheckItemButtons();

        switch (SM.shopType)
        {
            case (ShopManager.ShopType.skins):
                SM.stats.skin = itemObject;
                break;
            case (ShopManager.ShopType.trails):
                SM.stats.trail = itemObject;
                break;
        }

        SaveManager.SaveShop(SM);
    }

}
