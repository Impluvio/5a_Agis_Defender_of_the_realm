using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GridManager : MonoBehaviour
{
   [SerializeField] Vector2Int gridSize;
   [SerializeField] [Tooltip("world grid size should match unity snap settings")] int unityGridSize = 10;
    public int UnityGridSize { get { return unityGridSize; } }
    Dictionary<Vector2Int, Node> grid = new Dictionary<Vector2Int, Node>();
    public Dictionary<Vector2Int, Node> Grid { get{ return grid; } }



    void Awake()
    {
        createGrid();
    }

    public Node getNode(Vector2Int coordinates)
    {
        
        if (grid.ContainsKey(coordinates))
        {
            return grid[coordinates];
        }

        return null;
    }

    public void blockNode(Vector2Int coordinates)
    {
        if (grid.ContainsKey(coordinates)) 
        {
            grid[coordinates].isTraversable = false;        
        }
    }

    public void resetNodes()
    {
        foreach(KeyValuePair<Vector2Int, Node> entry in grid)
        {
            entry.Value.connectedTo = null;
            entry.Value.isExplored = false;
            entry.Value.isPath = false;
        }
    }

    public Vector2Int getCoordinatesFromPosition(Vector3 position)
    {
        Vector2Int coordinates = new Vector2Int();
        
        coordinates.x = Mathf.RoundToInt(position.x / unityGridSize);
        coordinates.y = Mathf.RoundToInt(position.z / unityGridSize);
        
        return coordinates;
    }

    public Vector3 getPositionFromCoordinates(Vector2Int coordinates)
    {

        Vector3 position = new Vector3();
        position.x = coordinates.x * unityGridSize;
        position.z = coordinates.y * unityGridSize;

        return position;
    }

    void createGrid()
    {
        for(int x = 0; x <gridSize.x; x++)
        {
            for(int y = 0; y <gridSize.y; y++)
            {
                Vector2Int coordinates = new Vector2Int(x, y);
                grid.Add(coordinates, new Node(coordinates, true));
                // Debug.Log(grid[coordinates].coordinates + " = " + grid[coordinates].isTraversable); //this prints all the coords of the grid.
            }
        }
    }
}
