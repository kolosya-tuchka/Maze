using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoppers : MonoBehaviour
{
    public bool Floor = true;
    public bool BBorder = false;
    public bool TBorder = false;
    public bool LBorder = false;
    public bool RBorder = false;
    public bool Money = false;
    public bool Sphere = false;
    public bool Hopper = false;
}

public class HopArray
{
    public Hoppers[,] hoppers;
}
