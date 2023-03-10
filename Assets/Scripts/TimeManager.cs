using System;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [Tooltip("Менеджер игрового процесса")]
    [SerializeField] private GameProcessManager _gameProcessManager;
    [Tooltip("Статус таймера")]
    [SerializeField] private bool _status;
    [Tooltip("Время уровня")]
    [SerializeField] private float _gameTime;
    [Tooltip("Значение таймера (текст)")]
    [SerializeField] private string _textValue;

    public delegate void GameTimeValue(float timeValue, float gameTime);
    public event GameTimeValue TikGameTime;

    public delegate void GameTimeOut();
    public event GameTimeOut OnGameTimeOut;

    private float _time = 0;

    private void OnEnable()
    {
        _gameProcessManager.SettingGameTime += _gameProcessManager_SettingGameTime;
        _gameProcessManager.OnPause += PauseTimer;
        _gameProcessManager.OnResume += _gameProcessManager_OnResume;
        _gameProcessManager.OnWin += StopTimer;
        _gameProcessManager.OnLose += StopTimer;
    }

    private void OnDisable()
    {
        _gameProcessManager.SettingGameTime -= _gameProcessManager_SettingGameTime;
        _gameProcessManager.OnPause -= PauseTimer;
        _gameProcessManager.OnResume -= _gameProcessManager_OnResume;
        _gameProcessManager.OnWin -= StopTimer;
        _gameProcessManager.OnLose -= StopTimer;
    }

    private void _gameProcessManager_SettingGameTime(float gameTime)
    {
        _gameTime = gameTime;
        Debug.Log(gameTime);
    }

    private void _gameProcessManager_OnResume()
    {
        StopTimer();
    }

    public void StartTimer()
    {
        _status = true;
        
    }
    public void PauseTimer()
    {
        _status = false;
    }
    
    public void StopTimer()
    {
        _status = false;
        _time = 0;
        _textValue = _time.ToString("0");
    }

    void Update()
    {
        if (_status)
        {
            //Время с начала уровня
            _time += Time.deltaTime;
            _textValue = _time.ToString("0.00");
            TikGameTime?.Invoke(_time, _gameTime);
            
            if (_time > _gameTime)
            {
                OnGameTimeOut?.Invoke();
                _time = 0;
            }
        }
    }
}
