using System;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoints = 5;
    [SerializeField] int difficultyRamp = 1;
    int currentHitpoints = 0;

    Enemy enemy;
    // Start is called before the first frame update
    void OnEnable()
    {
        currentHitpoints = maxHitPoints;
    }

    void Start()
    {
        enemy = GetComponent<Enemy>();
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
            gameObject.SetActive(false);
            maxHitPoints += difficultyRamp;
            enemy.rewardGold();
        }
    }
}
