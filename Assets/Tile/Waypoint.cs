using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;
    [SerializeField] bool isPlaceable;
    
    public bool IsPlaceable {get { return isPlaceable; } } 
    // Start is called before the first frame update
    void OnMouseDown()
    {
        if (isPlaceable)
        {
            bool isPlaced = towerPrefab.createTower(towerPrefab, transform.position);
            //Instantiate(towerPrefab, transform.position, Quaternion.identity);
            isPlaceable = !isPlaced;
        }
        
    }
}