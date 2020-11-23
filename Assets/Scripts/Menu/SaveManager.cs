using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveManager : MonoBehaviour {

    public ShopManager SM;

    string filePath;

    public static SaveManager Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        filePath = Application.persistentDataPath + "data.gamesave";

        LoadGame();
        SaveGame();
    }

    public void SaveGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = new FileStream(filePath, FileMode.Create);

        Save save = new Save();
        save.ActiveSkinIndex = SM.ActiveSkinIndex;
        save.SaveBoughtItems(SM.Items);

        bf.Serialize(fs, save);
        fs.Close();
    }

    public void LoadGame()
    {
        if (!File.Exists(filePath))
            return;

        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = new FileStream(filePath, FileMode.Open);

        Save save = (Save)bf.Deserialize(fs);

        SM.ActiveSkinIndex = save.ActiveSkinIndex;

        for (int i = 0; i < save.BoughtItems.Count; i++)
            SM.Items[i].IsBought = save.BoughtItems[i];

        fs.Close();

    }

}

[System.Serializable]
public class Save
{
    public int ActiveSkinIndex;
    public List<bool> BoughtItems = new List<bool>();

    public void SaveBoughtItems(List<ShopItem> items)
    {
        foreach (var item in items)
            BoughtItems.Add(item.IsBought);
    }
}
