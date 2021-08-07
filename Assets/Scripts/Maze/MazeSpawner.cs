using UnityEngine;

public class MazeSpawner : MonoBehaviour
{
    public Cell CellPrefab;
    public Vector3 CellSize = new Vector3(1, 1, 0);
    public Maze maze;
    MazeGameManager manager;

    private void Awake()
    {
        manager = GetComponent<MazeGameManager>();
    }

    public void Spawn()
    {
        MazeGenerator generator = GetComponent<MazeGenerator>();
        maze = generator.GenerateMaze();
        for (int i = 0; i < maze.cells.GetLength(1) * maze.cells.GetLength(0) / 30; i++)
        {
            var bomb = Instantiate(manager.bomb, new Vector3(Random.Range(3, maze.cells.GetLength(0)) * CellSize.x, 1.35f,
                       Random.Range(3, maze.cells.GetLength(1)) * CellSize.z), manager.bomb.transform.rotation);
            bomb.transform.SetParent(manager.map.transform, true);
        }

        for (int x = 0; x < maze.cells.GetLength(0); x++)
        {
            for (int y = 0; y < maze.cells.GetLength(1); y++)
            {
                Cell c = Instantiate(CellPrefab, new Vector3(x * CellSize.x, y * CellSize.y, y * CellSize.z), Quaternion.identity);
                c.WallLeft.SetActive(maze.cells[x, y].WallLeft);
                c.WallBottom.SetActive(maze.cells[x, y].WallBottom);
                c.Money.SetActive(maze.cells[x, y].Money);
                if (x != 0 || y != 0)
                {
                    c.Floor.SetActive(maze.cells[x, y].Floor);
                }
                c.Exit.SetActive(maze.cells[x, y].Exit);
                c.transform.SetParent(manager.map.transform, true);
            }
        }

        
    }
}