using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField] [Range(0f, 5f)] float speed = 1f;


    Enemy enemy;


    void OnEnable()
    {
        findPath();
        returnToStart();
        StartCoroutine (followPath());
    }

    private void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    void findPath()
    {
        path.Clear();
        
        GameObject[] waypoints = GameObject.FindGameObjectsWithTag("Path");

        foreach(GameObject waypoint in waypoints)
        {
            path.Add(waypoint.GetComponent<Waypoint>());
        }
    }

    void returnToStart()
    {
        transform.position = path[0].transform.position;
    }

    IEnumerator followPath()
    {
        foreach(Waypoint waypoint in path)
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = waypoint.transform.position;
            float travelPercent = 0f;

            transform.LookAt(endPosition);

            while(travelPercent < 1f)
            {
                travelPercent += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                yield return new WaitForEndOfFrame();
            }
            
        }
       enemy.stealGold();
       gameObject.SetActive(false);
       
    }
   
}
