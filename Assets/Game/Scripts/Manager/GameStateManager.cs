using System;
using System.Net.NetworkInformation;
using UnityEngine;

public enum GameStates
{
    Ready,
    Run,
    Paint,
    Lose
}

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance;
    public GameStates CurrentState;
    public bool isGameStart = false;
    [SerializeField] private CameraManager _cameraManager;
    [SerializeField] private GameObject paint;
    [SerializeField] private EnemyManager _enemyManager;
    [SerializeField] private GameObject _controller;
    [SerializeField] private Player _player;
    private void Awake()
    {
        if (Instance == null || !Instance || !Instance.gameObject)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Debug.LogError($"Another instance of {GetType()} already exist! Destroying self...");
            Destroy(this);
        }
    }

    private void Start()
    {
        SetGameState(GameStates.Ready);
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && !isGameStart)
        {
            SetGameState(GameStates.Run);
        }
    }

    public EnemyManager GetEnemyManager()
    {
        return _enemyManager;
    }

    public void SetGameState(GameStates gameStates)
    {
        CurrentState = gameStates;

        switch (CurrentState)
        {
            case GameStates.Ready:
                _player.RestartPlayer();
                UIManager.Instance.SetUIPage(UIPages.Start);
                _cameraManager.SetRunCamera();
                paint.SetActive(false);
                SetController(false);
                Time.timeScale = 0;
                break;
            case GameStates.Run:
                Time.timeScale = 1;
                UIManager.Instance.SetUIPage(UIPages.Run);
                SetController(true);
                isGameStart = true;
                break;
            case GameStates.Paint:
                SetController(false);
                _enemyManager.StopEnemies();
                paint.SetActive(true);
                UIManager.Instance.SetUIPage(UIPages.Paint);
                _cameraManager.SetPaintCamera();
                SetController(false);
                break;
            case GameStates.Lose:
                UIManager.Instance.SetUIPage(UIPages.Lose);
                Time.timeScale = 0;
                SetController(false);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public void RestartGame()
    {
        _enemyManager.RestartEnemies();
        SetGameState(GameStates.Ready);
        Instance.isGameStart = false;
        _player.RestartPlayer();
    }

    private void SetController(bool setting)
    {
        _controller.SetActive(setting);
    }
}