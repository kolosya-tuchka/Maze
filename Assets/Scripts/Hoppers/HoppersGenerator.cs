using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoppersGenerator : Generator
{

    public int hoppers;

    public HopArray GenerateHoppers()
    {
        int x, y;
        height = UnityEngine.Random.Range(minHeight, maxHeight);
        width = UnityEngine.Random.Range(minWidth, maxWidth);
        hoppers = UnityEngine.Random.Range(2, 5);

        Hoppers[,] cells = new Hoppers[width, height];
        int allHops = 0;
        int allBalls = 0;
        for (int i = 0; i < cells.GetLength(0); i++)
        {
            for (int j = 0; j < cells.GetLength(1); j++)
            {
                cells[i, j] = new Hoppers();
            }
        }

        for (int i = 0; i < cells.GetLength(0); i++)
        {
            for (int j = 0; j < cells.GetLength(1); j++)
            {
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
                if (UnityEngine.Random.Range(1, 11) == 10 && cells[i, j].Floor) cells[i, j].Money = true;
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
