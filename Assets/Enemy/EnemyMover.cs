using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField] float waitTime = 1.0f;
    
    void Start()
    {
        
        StartCoroutine (followPath());
        
    }

    IEnumerator followPath()
    {
        foreach(Waypoint waypoint in path)
        {

            transform.position = waypoint.transform.position; 
            
            yield return new WaitForSeconds(waitTime);
        }
    }
   
}
