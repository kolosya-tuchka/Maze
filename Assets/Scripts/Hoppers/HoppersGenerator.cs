using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoppersGenerator : Generator
{
    public int hoppers;

    public HopArray GenerateHoppers()
    {
        moneyCount = 0;
        int x, y;
        height = UnityEngine.Random.Range(minHeight, maxHeight + 1) + manager.level / 4;
        width = UnityEngine.Random.Range(minWidth, maxWidth + 1) + manager.level / 4;

        hoppers = UnityEngine.Random.Range(2, 5) + manager.level / 4;
        hoppers = Mathf.Clamp(hoppers, 2, 10);
        height = Mathf.Clamp(height, 5, 15);
        width = Mathf.Clamp(width, 5, 15);

        Hoppers[,] cells = new Hoppers[width, height];
        int allHops = 0;
        int allBalls = 0;
        for (int i = 0; i < cells.GetLength(0); i++)
        {
            for (int j = 0; j < cells.GetLength(1); j++)
            {
                cells[i, j] = new Hoppers();
                if (i == 0) cells[i, j].LBorder = true;
                if (i == width - 1) cells[i, j].RBorder = true;
                if (j == 0) cells[i, j].BBorder = true;
                if (j == height - 1) cells[i, j].TBorder = true;
            }
        }

        while (allHops < hoppers)
        {
            x = UnityEngine.Random.Range(1, width);
            y = UnityEngine.Random.Range(1, height);

            if (cells[x, y].Floor)
            {
                cells[x, y].Floor = false;
                cells[x, y].Hopper = true;
                allHops++;
            }
        }

        for (int i = 0; i < cells.GetLength(0); i++)
        {
            for (int j = 0; j < cells.GetLength(1); j++)
            {
                if (UnityEngine.Random.Range(1, 20) == 10 && cells[i, j].Floor && moneyCount < 5)
                {
                    cells[i, j].Money = true;
                    moneyCount++;
                }
            }
        }

        while (allBalls < hoppers)
        {
            x = UnityEngine.Random.Range(1, width);
            y = UnityEngine.Random.Range(1, height);

            if (cells[x, y].Floor && !cells[x, y].Money && !cells[x, y].Sphere)
            {
                cells[x, y].Sphere = true;
                allBalls++;
            }
        }

        GetComponent<HoppersManager>().hoppers = hoppers;
        HopArray level = new HopArray();
        level.hoppers = cells;
        return level;

    }
}
