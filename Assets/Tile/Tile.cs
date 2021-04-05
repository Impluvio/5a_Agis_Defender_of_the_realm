using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Tile : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;
    [SerializeField] bool isPlaceable;
    public bool IsPlaceable {get { return isPlaceable; } }
    GridManager gridManager;
    PathFinder pathFinder;
   
    Vector2Int coordinates = new Vector2Int();

    void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
        pathFinder = FindObjectOfType<PathFinder>();
    }

    void Start()
    {
       if(gridManager != null)
        {
            coordinates = gridManager.getCoordinatesFromPosition(transform.position);

            if (!isPlaceable)
            {
                gridManager.blockNode(coordinates);
            }
        } 
    }

    void OnMouseDown()
    {
        if (gridManager.getNode(coordinates).isTraversable && !pathFinder.willBlockPath(coordinates))
        {
            bool isPlaced = towerPrefab.createTower(towerPrefab, transform.position);
            //Instantiate(towerPrefab, transform.position, Quaternion.identity);
            isPlaceable = !isPlaced;
            gridManager.blockNode(coordinates);
        }
        
    }
}