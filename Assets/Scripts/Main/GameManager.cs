using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.Video;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private Vector2 playerPosition = Vector2.zero;

    [SerializeField] PlayerController playerController;
    UnityEngine.UI.Button selectButton;

    private int saveBestScore = 0;

    public void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public void StartMiniGame()
    {
        SavePlayerPosition();
        SceneManager.LoadScene("MiniGameScene");
    }

    public Vector2 OutPlayerPosition()
    {
        return playerPosition;
    }

    public void SavePlayerPosition()
    {
        playerPosition = playerController.transform.position;
    }

    public void SaveBestScore(int score)
    {
        saveBestScore = score;
    }
    public int OutBestScore()
    {
        return saveBestScore;
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // 씬이 로드된 후 실행되는 코드
        Debug.Log("씬 로드됨: " + scene.name);

        // 예: PlayerController 찾기
        playerController = FindObjectOfType<PlayerController>();
        if (playerController != null)
        {
            Debug.Log("PlayerController를 찾음!");
        }
        else
        {
            Debug.LogWarning("PlayerController를 찾을 수 없음!");
        }

        // 씬 로드 후 버튼 다시 찾기
        selectButton = FindObjectOfType<UnityEngine.UI.Button>();  // 씬 내에서 버튼 찾기

        if (selectButton != null)
        {
            Debug.Log("Button를 찾음!");
            selectButton.onClick.AddListener(StartMiniGame);  // 버튼 클릭 시 동작 추가
        }
        else
        {
            Debug.LogWarning("버튼을 찾을 수 없음!");
        }
    }

    //public void FindPlayer()
}
