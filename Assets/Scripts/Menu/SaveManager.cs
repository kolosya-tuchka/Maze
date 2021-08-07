using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveManager : MonoBehaviour {

    public ShopManager SM, trails;
    public PlayerStats playerStats;

    private void Awake()
    {
        LoadGame();
        SaveGame();
    }

    public void SaveGame()
    {
        SaveShop(SM);
        SaveShop(trails);
        SavePlayerStats(playerStats);
        SavePlayerSettings(playerStats.settings);
    }

    public static void SaveShop(ShopManager shop)
    {
        string filePath = Application.persistentDataPath;
        switch (shop.shopType)
        {
            case (ShopManager.ShopType.skins):
                filePath += "skins.save";
                break;
            case (ShopManager.ShopType.trails):
                filePath += "trails.save";
                break;
        }

        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = new FileStream(filePath, FileMode.Create);

        ShopSave skins = new ShopSave();
        skins.ActiveSkinIndex = shop.ActiveIndex;
        skins.SaveBoughtItems(shop.Items);

        bf.Serialize(fs, skins);
        fs.Close();
    }

    public static void SavePlayerStats(PlayerStats player)
    {
        string filePath = Application.persistentDataPath + "stats.save";

        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = new FileStream(filePath, FileMode.Create);
        PlayerStatsSave stats = new PlayerStatsSave(player);

        bf.Serialize(fs, stats);
        fs.Close();
    }

    public static void SavePlayerSettings(PlayerSettings settings)
    {
        string filePath = Application.persistentDataPath + "settings.save";

        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = new FileStream(filePath, FileMode.Create);

        bf.Serialize(fs, settings);
        fs.Close();
    }

    public void LoadGame()
    {
        string filePath = Application.persistentDataPath + "skins.save",
               filePathPlayer = Application.persistentDataPath + "stats.save",
               filePathSettings = Application.persistentDataPath + "settings.save",
               filePathTrails = Application.persistentDataPath + "trails.save";

        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs;

        if (File.Exists(filePath))
        {
            fs = new FileStream(filePath, FileMode.Open);
            ShopSave shop = (ShopSave)bf.Deserialize(fs);

            SM.ActiveIndex = shop.ActiveSkinIndex;

            for (int i = 0; i < shop.BoughtItems.Count; i++)
                SM.Items[i].IsBought = shop.BoughtItems[i];

            fs.Close();
        }
        playerStats.skin = SM.Items[SM.ActiveIndex].itemObject;

        if (File.Exists(filePathTrails))
        {
            fs = new FileStream(filePathTrails, FileMode.Open);
            ShopSave shop = (ShopSave)bf.Deserialize(fs);

            trails.ActiveIndex = shop.ActiveSkinIndex;

            for (int i = 0; i < shop.BoughtItems.Count; i++)
                trails.Items[i].IsBought = shop.BoughtItems[i];

            playerStats.trail = trails.Items[trails.ActiveIndex].itemObject;

            fs.Close();
        }


        if (File.Exists(filePathPlayer))
        {
            fs = new FileStream(filePathPlayer, FileMode.Open);

            PlayerStatsSave stats = (PlayerStatsSave)bf.Deserialize(fs);
            playerStats.money = stats.money;
            playerStats.bestScoreHoppers = stats.bestScoreHoppers;
            playerStats.bestScoreMaze = stats.bestScoreMaze;
            fs.Close();
        }

        if (File.Exists(filePathSettings))
        {
            fs = new FileStream(filePathSettings, FileMode.Open);

            PlayerSettings settings = (PlayerSettings)bf.Deserialize(fs);
            playerStats.settings = settings;
            fs.Close();
        }
    }

}

[System.Serializable]
public class ShopSave
{
    public int ActiveSkinIndex;
    public List<bool> BoughtItems = new List<bool>();

    public void SaveBoughtItems(List<ShopItem> items)
    {
        foreach (var item in items)
            BoughtItems.Add(item.IsBought);
    }
}

[System.Serializable]
public class PlayerStatsSave
{
    public int money;
    public int bestScoreMaze;
    public int bestScoreHoppers;

    public PlayerStatsSave(PlayerStats stats)
    {
        this.money = stats.money;
        this.bestScoreMaze = stats.bestScoreMaze;
        this.bestScoreHoppers = stats.bestScoreHoppers;
    }
}

