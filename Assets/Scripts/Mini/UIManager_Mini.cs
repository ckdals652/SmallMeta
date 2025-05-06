using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager_Mini : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI restartText;
    public Button RestartButton;
    public Button BackButton;

    public void Start()
    {
        if (restartText == null)
        {
            Debug.LogError("restart text is null");
        }

        if (scoreText == null)
        {
            Debug.LogError("scoreText is null");
            return;
        }

        restartText.gameObject.SetActive(false);
        RestartButton.gameObject.SetActive(false);
        BackButton.gameObject.SetActive(false);
    }

    public void SetRestart()
    {
        string bestScore = GameManager_Mini.Instance.BestScore().ToString();
        string nowScore = GameManager_Mini.Instance.NowScore().ToString();

        restartText.text = "BestScore : " + bestScore + "\nNow Score  : "+ nowScore;
        restartText.gameObject.SetActive(true);
        RestartButton.gameObject.SetActive(true);
        BackButton.gameObject.SetActive(true);
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }
}