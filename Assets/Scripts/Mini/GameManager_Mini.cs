using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager_Mini : MonoBehaviour
{
    static GameManager_Mini gameManager_Mini;

    UIManager_Mini uiManager_Mini;

    public UIManager_Mini UIManager_Mini
    {
        get { return uiManager_Mini; }
    }
    public static GameManager_Mini Instance
    {
        get { return gameManager_Mini; }
    }

    public GameManager gameManager;

    private int currentScore = 0;
    private int bestScore = 0;

    private void Awake()
    {
        gameManager_Mini = this;
        uiManager_Mini = FindObjectOfType<UIManager_Mini>();
        gameManager = GameManager.Instance;
    }
    private void Start()
    {
        bestScore = gameManager.OutBestScore();
        uiManager_Mini.UpdateScore(0);
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        uiManager_Mini.SetRestart();
    }

    public void RestartGame()
    {
        gameManager.SaveBestScore(bestScore);
        SceneManager.LoadScene("MiniGameScene");
    }

    public void AddScore(int score)
    {
        currentScore += score;
        uiManager_Mini.UpdateScore(currentScore);
        //Debug.Log("Score: " + currentScore);
    }
    public int BestScore()
    {
        if (currentScore >= bestScore)
        {
            bestScore = currentScore;
        }

        return bestScore;
    }

    public int NowScore()
    {
        return currentScore;
    }

    public void CloseGame()
    {
        gameManager.SaveBestScore(bestScore);
        SceneManager.LoadScene("MainScene");
    }
}