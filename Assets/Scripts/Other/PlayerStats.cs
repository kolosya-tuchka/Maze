using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int money, bestScoreMaze, bestScoreHoppers;
    public GameObject skin, trail;
    public PlayerSettings settings;

    AudioSource[] sounds;
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        sounds = FindObjectsOfType<AudioSource>();
        SetVolume(sounds);
    }

    public void ChangeSensivity(int value)
    {
        settings.sensivity += value;
        settings.sensivity = Mathf.Clamp(settings.sensivity, 1, 15);
    }

    public void ChangeVolume(int value)
    {
        settings.volume += value;
        settings.volume = Mathf.Clamp(settings.volume, 0, 15);
        SetVolume(sounds);
    }

    public void ChangeGraphics()
    {
        settings.coolGraphics = !settings.coolGraphics;
    }

    public void SetVolume(AudioSource[] sounds)
    {
        float volume = settings.volume / 15f;
        foreach (var sound in sounds)
        {
            if (volume > 0) sound.volume /= volume * volume;
            sound.volume *= volume * volume;
        }
    }

}

[System.Serializable]
public class PlayerSettings
{
    public int sensivity = 5, volume = 5;
    public bool coolGraphics = true;
}

