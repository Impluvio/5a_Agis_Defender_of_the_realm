using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    
    [SerializeField] [Range(0f, 5f)] float speed = 1f;

    List<Node> path = new List<Node>();
    
    Enemy enemy;
    GridManager gridManager;
    PathFinder pathFinder;

    void Awake()
    {
        enemy = GetComponent<Enemy>();
        gridManager = FindObjectOfType<GridManager>();
        pathFinder = FindObjectOfType<PathFinder>();
    }

    void OnEnable()
    {
        findPath();
        returnToStart();
        StartCoroutine (followPath());
    }

    private void Start()
    {
        
    }

    void findPath()
    {
        path.Clear();
        path = pathFinder.getNewPath();  
      
    }

    void returnToStart()
    {
        transform.position = gridManager.getPositionFromCoordinates(pathFinder.StartCoordinates);
    }

    void finishPath()
    {
       enemy.stealGold();
       gameObject.SetActive(false);
    }

    IEnumerator followPath()
    {
        for(int counter = 0; counter < path.Count; counter++)
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = gridManager.getPositionFromCoordinates(path[counter].coordinates);
            float travelPercent = 0f;

            transform.LookAt(endPosition);

            while(travelPercent < 1f)
            {
                travelPercent += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                yield return new WaitForEndOfFrame();
            }
            
        }

        finishPath();
    }
   
}
