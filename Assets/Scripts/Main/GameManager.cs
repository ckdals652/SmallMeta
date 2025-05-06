using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public GameManager Instance
    {
        get
        {
            return instance;
        }
    }
    public void StartMiniGame()
    {
        SceneManager.LoadScene("MiniGameScene");
    }
}
