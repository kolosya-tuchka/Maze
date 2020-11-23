using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour {

    public List<ShopItem> Items;
    public int ActiveSkinIndex;

    public void CheckItemButtons()
    {
        foreach (ShopItem item in Items)
        {
            item.SM = this;
            item.CheckButtons();
        }
    }
}
