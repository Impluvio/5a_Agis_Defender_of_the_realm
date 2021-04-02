using System;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoints = 5;
    int currentHitpoints = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        currentHitpoints = maxHitPoints;
    }

    // Update is called once per frame
    void OnParticleCollision (GameObject other)
    {
        processHit();
    }

    private void processHit()
    {
        currentHitpoints--;
        if (currentHitpoints <= 0) 
        {
            Destroy(gameObject);
        }
    }
}
