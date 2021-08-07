using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestResUI : MonoBehaviour
{
    public Text maze, hoppers;
    public PlayerStats stats;
    void Start()
    {
        maze.text = "Best result: " + stats.bestScoreMaze.ToString();
        hoppers.text = "Best result: " + stats.bestScoreHoppers.ToString();
    }
}
