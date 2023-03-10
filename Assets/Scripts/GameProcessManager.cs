using System;
using UnityEngine;

public enum GameStatus
{
    Menu,
    Start,
    Active,
    Pause,
    Lose,
    Win
}

public class GameProcessManager : MonoBehaviour
{
    public static GameStatus CurrentGameStatus;
    [Header("Game Settings")]
    //[Tooltip("Количество собранных монет для победы")]
    //[SerializeField] private int _coinCountToWin = 10;
    [Tooltip("Время на сбор монет")]
    [SerializeField] private float _gameTime = 60f;

    [Header("Managers")]
    [SerializeField] private TimeManager _timeManager;

    //public delegate void CoinsCountToWin(int coinsCountToWin);
    //public event CoinsCountToWin SettingCoinsCountToWin;

    public delegate void GameTime (float gameTime);
    public event GameTime SettingGameTime;

    public event Action OnHome;
    public event Action OnSettings;
    public event Action OnLevels;
    public event Action OnWin;
    public event Action OnLose;
    public event Action OnPause;
    public event Action OnGame;
    public event Action OnResume;
    public event Action OnShop;
    public event Action OnAuthors;

    private void Awake()
    {
        //SettingCoinsCountToWin?.Invoke(_coinCountToWin);
        SettingGameTime?.Invoke(_gameTime);
  
        OnGame += _timeManager.StartTimer;
        OnWin += _timeManager.StopTimer;
        OnLose += _timeManager.StopTimer;
    }

    private void Start()
    {
        CurrentGameStatus = GameStatus.Start;
        OnHome?.Invoke();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    public void StartGame()
    {
        Time.timeScale = 1f;
        CurrentGameStatus = GameStatus.Active;
        OnGame?.Invoke();
    }

    private void OnEnable()
    {
        _timeManager.OnGameTimeOut += _timeManager_GameTimeOut;
    }
 
    private void OnDisable()
    {
        _timeManager.OnGameTimeOut -= _timeManager_GameTimeOut;
    }

    private void _timeManager_GameTimeOut()
    {
        Debug.Log("GameTimeOut");
        GameLose();
    }

    public void GameLose()
    {
        Time.timeScale = 1;
        CurrentGameStatus = GameStatus.Lose;
        OnLose?.Invoke();
    }

    public void GameWin()
    {
        Time.timeScale = 1;
        CurrentGameStatus = GameStatus.Win;
        OnWin?.Invoke();
    }
    
    public void PauseGame()
    {
        CurrentGameStatus = GameStatus.Pause;
        OnPause?.Invoke();
        Time.timeScale = 1;
    }

    public void Return()
    {
        CurrentGameStatus = GameStatus.Start;
        OnGame?.Invoke();
        Time.timeScale = 1;
    }

    public void Resume()
    {
        if (CurrentGameStatus == GameStatus.Win)
        {
            CurrentGameStatus = GameStatus.Start;
            OnResume?.Invoke();
            Time.timeScale = 1;
        }
        else
        {
            StartGame();
        }
    }
    public void ShowHome()
    {
        CurrentGameStatus = GameStatus.Menu;
        OnHome?.Invoke();
        Time.timeScale = 1;
    }

    public void ShowSettings()
    {
        CurrentGameStatus = GameStatus.Menu;
        OnSettings?.Invoke();
        Time.timeScale = 1;
    }

    public void ShowAuthors()
    {
        CurrentGameStatus = GameStatus.Menu;
        OnAuthors?.Invoke();
        Time.timeScale = 1;
    }
    public void ShowShop()
    {
        CurrentGameStatus = GameStatus.Menu;
        OnShop?.Invoke();
        Time.timeScale = 1;
    }
    public void ShowLevels()
    {
        CurrentGameStatus = GameStatus.Menu;
        OnLevels?.Invoke();
        Time.timeScale = 1;
    }

    public void Exit()
    {
        Application.Quit();
    }
}