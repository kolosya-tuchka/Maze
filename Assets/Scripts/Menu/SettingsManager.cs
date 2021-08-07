using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public Text volumeValue, sensivityValue;
    public GameObject graphicsMark;
    public PlayerStats stats;
    PlayerSettings settings;
    public GameObject postProcessing;
    void Start()
    {
        settings = stats.settings;
        OnVolumeChange();
        OnSensivityChange();
        OnGraphicsChange();
    }

    public void OnVolumeChange()
    {
        volumeValue.text = settings.volume.ToString();
        SaveManager.SavePlayerSettings(settings);
    }

    public void OnSensivityChange()
    {
        sensivityValue.text = settings.sensivity.ToString();
        SaveManager.SavePlayerSettings(settings);
    }

    public void OnGraphicsChange()
    {
        postProcessing.SetActive(settings.coolGraphics);
        graphicsMark.SetActive(settings.coolGraphics);
        SaveManager.SavePlayerSettings(settings);
    }
}
