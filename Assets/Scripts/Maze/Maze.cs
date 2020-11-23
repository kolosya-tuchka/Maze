using UnityEngine;

public class Maze
{
    public MazeGeneratorCell[,] cells;
    public Vector2Int finishPosition;
}

public class MazeGeneratorCell: MonoBehaviour
{
    public int X;
    public int Y;

    public bool WallLeft = true;
    public bool WallBottom = true;
    public bool Floor = false;
    public bool Money = false;
    public bool Exit = false;

    public bool Visited = false;
    public int DistanceFromStart;
}
