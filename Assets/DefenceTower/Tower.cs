using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] int cost = 75;
    [SerializeField] float buildTime = 1f;

    private void Start()
    {
        StartCoroutine(build());
    }

    public bool createTower(Tower tower, Vector3 position)
    {
        Bank bank = FindObjectOfType<Bank>();

        if(bank == null)
        {
            return false;
        }

        if(bank.CurrentBalance >= cost)
        {
            Instantiate(tower.gameObject, position, Quaternion.identity);
            bank.Withdrawal(cost);
            return true;
        }

        return false; 
    }

    IEnumerator build()
    {
        foreach(Transform child in transform)
        {
            child.gameObject.SetActive(false);
            foreach(Transform grandchild in child)
            {
                grandchild.gameObject.SetActive(false);
            }
        }

        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);
            yield return new WaitForSeconds(buildTime);
            foreach (Transform grandchild in child)
            {
                grandchild.gameObject.SetActive(true);
            }
        }

    }
}
