using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] [Range(0, 50)] int poolSize = 5;
    [SerializeField] [Range(0.1f, 30f)]float spawnTimer = 1f;

    GameObject[] pool;

    void Awake()
    {
        populatePool();
    }

    void Start()
    {
        StartCoroutine(spawnEnemy());
    }

    void populatePool()
    {
        pool = new GameObject[poolSize];

        for(int counter = 0; counter < pool.Length; counter++)
        {
            pool[counter] = Instantiate(enemyPrefab, transform);
            pool[counter].SetActive(false);
        } 
    }

    void enableObjectInPool()
    {
        for( int counter = 0; counter < pool.Length; counter++)
        {
            if(pool[counter].activeInHierarchy == false)
            {
                pool[counter].SetActive(true);
                return;
            }
        }
    }


    IEnumerator spawnEnemy()
    {
        while (true)
        {
            enableObjectInPool();
            yield return new WaitForSeconds(spawnTimer);
        }
    }
}
