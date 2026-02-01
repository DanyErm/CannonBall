using UnityEngine;
using System.Collections.Generic;

public class MazeSpawner : MonoBehaviour
{
    public Cell CellPrefab;
    public Vector3 CellSize = new Vector3(1, 1, 0);

    public int mazeWidth = 20;
    public int mazeHeight = 20;
    [SerializeField] private int debuffFrequency = 10;

    [SerializeField] private List<GameObject> debuffList = new List<GameObject>();

    public Maze maze;

    private void Start()
    {
        MazeGenerator generator = new MazeGenerator(mazeWidth, mazeHeight);
        maze = generator.GenerateMaze();

        for (int x = 0; x < maze.cells.GetLength(0); x++)
        {
            for (int y = 0; y < maze.cells.GetLength(1); y++)
            {
                Cell c = Instantiate(CellPrefab, new Vector3(x * CellSize.x, y * CellSize.y, y * CellSize.z), Quaternion.identity);
                
                c.WallLeft.SetActive(maze.cells[x, y].WallLeft);
                c.WallBottom.SetActive(maze.cells[x, y].WallBottom);
                c.Floor.SetActive(maze.cells[x, y].Floor);



                var rand = new System.Random();
                int tempRand = -2;


                if (rand.Next(debuffFrequency) == debuffFrequency - 1 && !(x == 0 && y == 0) && !(x == (maze.cells.GetLength(0) - 1) || y == (maze.cells.GetLength(1) - 1)))
                {
                    tempRand = rand.Next(debuffList.Count);

                    Instantiate(debuffList[tempRand], new Vector3(x * CellSize.x + (CellSize.x / 2), y * CellSize.y - 0.4f, y * CellSize.z + (CellSize.z / 2)), Quaternion.identity);
                }
            }
        }
    }
}