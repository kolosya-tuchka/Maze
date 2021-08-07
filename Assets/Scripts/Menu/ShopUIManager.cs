using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUIManager : MonoBehaviour
{
    public GameObject skins, trails;

    private void Start()
    {
        SwitchShop(skins);
    }

    public void SwitchShop(GameObject shop)
    {
        skins.SetActive(false);
        trails.SetActive(false);

        shop.SetActive(true);
    }
}
