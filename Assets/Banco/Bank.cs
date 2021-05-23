using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance = 250;
    [SerializeField] int currentBalance;
    [SerializeField][Tooltip("gold must be higher than starting balance")] int goldToWin = 300;

    public int CurrentBalance { get { return currentBalance; } }

    [SerializeField] TextMeshProUGUI displayBalance;
    

    void Awake()
    {
        currentBalance = startingBalance;
        updateDisplay();
        
    }

    public void Deposit(int amount)
    {
        currentBalance += Mathf.Abs(amount);
        victoryConditions();
        updateDisplay();
    }

    public void Withdrawal(int amount)
    {
        currentBalance -= Mathf.Abs(amount);
        updateDisplay();
        if (currentBalance < 0)
        {
            reloadScene();
        }
    }

    void updateDisplay()
    {
        displayBalance.text = "Gold: " + currentBalance;
    }

    void reloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }

    void victoryConditions()
    {
        if (currentBalance >=  goldToWin)
        {
            Scene currentScene = SceneManager.GetActiveScene();
            Debug.Log(currentScene);
            SceneManager.LoadScene(currentScene.buildIndex + 1);
        }
    }
}
