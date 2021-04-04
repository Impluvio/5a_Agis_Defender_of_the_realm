using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance = 250;
    [SerializeField] int currentBalance;

    public int CurrentBalance { get { return currentBalance; } }


    void Awake()
    {

        currentBalance = startingBalance;
    }

    public void Deposit(int amount)
    {
        currentBalance += Mathf.Abs(amount);
    }

    public void Withdrawal(int amount)
    {
        currentBalance -= Mathf.Abs(amount);
        if(currentBalance < 0)
        {
            reloadScene();
        }
    }

    void reloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }

}
