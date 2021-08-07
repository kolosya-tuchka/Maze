using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour {

    public List<ShopItem> Items;
    public int ActiveIndex;
    public PlayerStats stats;
    public AudioSource BuySound;

    public ShopType shopType;
    public enum ShopType
    {
        skins, trails
    }


    public void CheckItemButtons()
    {
        foreach (ShopItem item in Items)
        {
            item.SM = this;
            item.CheckButtons();
        }
    }
}
