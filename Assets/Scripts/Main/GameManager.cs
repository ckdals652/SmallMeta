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
        // ���� �ε�� �� ����Ǵ� �ڵ�
        Debug.Log("�� �ε��: " + scene.name);

        // ��: PlayerController ã��
        playerController = FindObjectOfType<PlayerController>();
        if (playerController != null)
        {
            Debug.Log("PlayerController�� ã��!");
        }
        else
        {
            Debug.LogWarning("PlayerController�� ã�� �� ����!");
        }

        // �� �ε� �� ��ư �ٽ� ã��
        selectButton = FindObjectOfType<UnityEngine.UI.Button>();  // �� ������ ��ư ã��

        if (selectButton != null)
        {
            Debug.Log("Button�� ã��!");
            selectButton.onClick.AddListener(StartMiniGame);  // ��ư Ŭ�� �� ���� �߰�
        }
        else
        {
            Debug.LogWarning("��ư�� ã�� �� ����!");
        }
    }

    //public void FindPlayer()
}
