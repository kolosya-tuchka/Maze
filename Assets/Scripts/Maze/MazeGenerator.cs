using System;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator: MonoBehaviour
{
    public int minWidth, maxWidth, minHeight, maxHeight, width, height;
  
    public Maze GenerateMaze()
    {
        height = UnityEngine.Random.Range(minHeight, maxHeight + 1);
        width = UnityEngine.Random.Range(minWidth, maxWidth + 1);

        MazeGeneratorCell[,] cells = new MazeGeneratorCell[width, height];

        for (int x = 0; x < cells.GetLength(0); x++)
        {
            for (int y = 0; y < cells.GetLength(1); y++)
            {
                cells[x, y] = new MazeGeneratorCell { X = x, Y = y };
            }
        }

        for (int x = 0; x < cells.GetLength(0); x++)
        {
            cells[x, height - 1].WallLeft = false;
        }

        for (int y = 0; y < cells.GetLength(1); y++)
        {
            cells[width - 1, y].WallBottom = false;
        }

        RemoveWallsWithBacktracker(cells);

        Maze maze = new Maze();

        maze.cells = cells;
        maze.finishPosition = PlaceMazeExit(cells);

        return maze;
    }

    private void RemoveWallsWithBacktracker(MazeGeneratorCell[,] maze)
    {
        MazeGeneratorCell current = maze[0, 0];
        current.Visited = true;
        current.DistanceFromStart = 0;

        Stack<MazeGeneratorCell> stack = new Stack<MazeGeneratorCell>();
        do
        {
            List<MazeGeneratorCell> unvisitedNeighbours = new List<MazeGeneratorCell>();

            int x = current.X;
            int y = current.Y;

            if (x > 0 && !maze[x - 1, y].Visited) unvisitedNeighbours.Add(maze[x - 1, y]);
            if (y > 0 && !maze[x, y - 1].Visited) unvisitedNeighbours.Add(maze[x, y - 1]);
            if (x < width - 2 && !maze[x + 1, y].Visited) unvisitedNeighbours.Add(maze[x + 1, y]);
            if (y < height - 2 && !maze[x, y + 1].Visited) unvisitedNeighbours.Add(maze[x, y + 1]);

            if (unvisitedNeighbours.Count > 0)
            {
                MazeGeneratorCell chosen = unvisitedNeighbours[UnityEngine.Random.Range(0, unvisitedNeighbours.Count)];
                RemoveWall(current, chosen);

                chosen.Visited = true;
                stack.Push(chosen);
                chosen.DistanceFromStart = current.DistanceFromStart + 1;
                current = chosen;
            }
            else
            {
                current = stack.Pop();
            }
        } while (stack.Count > 0);
    }

    private void RemoveWall(MazeGeneratorCell a, MazeGeneratorCell b)
    {
        if (a.X == b.X)
        {
            if (a.Y > b.Y) a.WallBottom = false;
            else b.WallBottom = false;
        }
        else
        {
            if (a.X > b.X) a.WallLeft = false;
            else b.WallLeft = false;
        }

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (x + 1 == width || y + 1 == height)
                {
                    b.Floor = true;
                }
            }
        }

        if (b.X + 1 != width && b.X != 0 && b.Y + 1 != height && b.Y != 0)
        {
            int d = UnityEngine.Random.Range(1, 3);
            if (d == 2)
            {
                d = UnityEngine.Random.Range(1, 3);
                switch (d)
                {
                    case (1): b.WallLeft = false; break;
                    case (2): b.WallBottom = false; break;
                }
            }

            d = UnityEngine.Random.Range(1, 10);
            if (d == 3) b.Money = !b.Exit;
        }

    }

    private Vector2Int PlaceMazeExit(MazeGeneratorCell[,] maze)
    {
        MazeGeneratorCell furthest = maze[0, 0];

        for (int x = 0; x < maze.GetLength(0); x++)
        {
            for (int y = 0; y < maze.GetLength(1); y++)
            {
                if (maze[x, y].DistanceFromStart > furthest.DistanceFromStart) furthest = maze[x, y];
            }
        }

        if (furthest.X != 0) { furthest.Floor = false; furthest.Exit = true; }
        else if (furthest.Y != 0) { furthest.Floor = false; furthest.Exit = true; }
        else if (furthest.X == width - 2) { maze[furthest.X + 1, furthest.Y].Floor = false; maze[furthest.X + 1, furthest.Y].Exit = true; }
        else if (furthest.Y == height - 2) { maze[furthest.X, furthest.Y + 1].Floor = false; maze[furthest.X, furthest.Y + 1].Exit = true; }

        return new Vector2Int(furthest.X, furthest.Y);
    }

}