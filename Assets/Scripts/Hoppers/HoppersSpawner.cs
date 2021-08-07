using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoppersSpawner : Spawner
{
    public HopperPrefab hopperPrefab;
    HoppersManager manager;
   
    public HopArray level;

    private void Awake()
    {
        manager = GetComponent<HoppersManager>();
    }

    public void Spawn()
    {
        HoppersGenerator generator = GetComponent<HoppersGenerator>();
        level = generator.GenerateHoppers();

        for (int x = 0; x < level.hoppers.GetLength(0); x++)
        {
            for (int y = 0; y < level.hoppers.GetLength(1); y++)
            {
                HopperPrefab cell = Instantiate(hopperPrefab, new Vector3(x * CellSize.x, y * CellSize.y, y * CellSize.z), Quaternion.identity);
                cell.Bottom.SetActive(level.hoppers[x, y].BBorder);
                cell.Top.SetActive(level.hoppers[x, y].TBorder);
                cell.Right.SetActive(level.hoppers[x, y].RBorder);
                cell.Left.SetActive(level.hoppers[x, y].LBorder);
                cell.Money.SetActive(level.hoppers[x, y].Money);
                cell.Floor.SetActive(level.hoppers[x, y].Floor);
                cell.Sphere.SetActive(level.hoppers[x, y].Sphere);
                cell.Hopper.SetActive(level.hoppers[x, y].Hopper);
                cell.HopTop.SetActive(false);
                cell.transform.SetParent(manager.map.transform, true);
            }
        }
    }
}
