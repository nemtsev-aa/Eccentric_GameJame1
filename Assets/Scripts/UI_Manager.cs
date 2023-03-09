using UnityEngine;
using TMPro;
using System;
using System.Collections.Generic;

public enum PageName
{
    Home,
    Levels,
    Settings,
    Authors,
    Shop,
    Game,
    Pause,
    Win,
    Lose
}

public class UI_Manager : MonoBehaviour
{
    [Tooltip("Менеджер игрового процесса")]
    [SerializeField] private GameProcessManager _gameProcessManager;
    [Tooltip("Номер активного окна UI")]
    [SerializeField] int _currentPageNumber = 0;
    [Tooltip("Список окон UI")]
    [SerializeField] private List<Page> _pages = new List<Page>();
    
    [Tooltip("Менеджер игрового времени")]
    [SerializeField] private TimeManager _timeManager;
    [Tooltip("Метка для отображения времени")]
    [SerializeField] private TextMeshProUGUI _gameTimeText;

    private int _closePageNumber;
    void Start()
    {
        ShowPage(_currentPageNumber);
    }

    private void OnEnable()
    {
        _gameProcessManager.OnHome += _gameProcessManager_OnHome;
        _gameProcessManager.OnSettings += _gameProcessManager_OnSettings;
        _gameProcessManager.OnLevels += _gameProcessManager_OnLevels;   
       _gameProcessManager.OnGame += _gameProcessManager_OnGame;
        _gameProcessManager.OnPause += _gameProcessManager_OnPause;
        _gameProcessManager.OnWin += _gameProcessManager_OnWin;
        _gameProcessManager.OnLose += _gameProcessManager_OnLose;
        _gameProcessManager.OnAuthors += _gameProcessManager_OnAuthors;
        _gameProcessManager.OnShop += _gameProcessManager_OnShop;
        _timeManager.TikGameTime += _timeManager_TikGameTime;
        
    }

    private void OnDisable()
    {
        _gameProcessManager.OnHome -= _gameProcessManager_OnHome;
        _gameProcessManager.OnSettings -= _gameProcessManager_OnSettings;
        _gameProcessManager.OnLevels -= _gameProcessManager_OnLevels;
        _gameProcessManager.OnGame -= _gameProcessManager_OnGame;
        _gameProcessManager.OnPause -= _gameProcessManager_OnPause;
        _gameProcessManager.OnWin -= _gameProcessManager_OnWin;
        _gameProcessManager.OnLose -= _gameProcessManager_OnLose;
        _gameProcessManager.OnAuthors += _gameProcessManager_OnAuthors;
        _gameProcessManager.OnShop += _gameProcessManager_OnShop;
        _timeManager.TikGameTime -= _timeManager_TikGameTime;
    }

    /// <summary>
    /// Обновление времени игры
    /// </summary>
    private void _timeManager_TikGameTime(float timeValue, float gameTime)
    {
        string _textValue = Mathf.RoundToInt(timeValue).ToString();
        _gameTimeText.text = $"{_textValue}/{gameTime}";
    }
    private void _gameProcessManager_OnHome()
    {
        HidePage(_currentPageNumber);
        ShowPage(0);
    }
    private void _gameProcessManager_OnLevels()
    {
        HidePage(_currentPageNumber);
        ShowPage(1);
    }

    private void _gameProcessManager_OnSettings()
    {
        HidePage(_currentPageNumber);
        ShowPage(2);
    }

    private void _gameProcessManager_OnPause()
    {
        HidePage(_currentPageNumber);
        ShowPage(6);
    }

    private void _gameProcessManager_OnGame()
    {
        HidePage(_currentPageNumber);
        ShowPage(5);
    }

    private void _gameProcessManager_OnWin()
    {
        HidePage(_currentPageNumber);
        ShowPage(7);
    }

    private void _gameProcessManager_OnLose()
    {
        HidePage(_currentPageNumber);
        ShowPage(8);
    }
    private void _gameProcessManager_OnShop()
    {
        HidePage(_currentPageNumber);
        ShowPage(4);
    }

    private void _gameProcessManager_OnAuthors()
    {
        HidePage(_currentPageNumber);
        ShowPage(3);
    }

    public void HidePage(int pageNumber)
    {
        _closePageNumber = pageNumber;
        _pages[pageNumber].PanelFaseOut();
    }

    public void ShowPage(int PageNumber)
    {
        _currentPageNumber = PageNumber;
        _pages[PageNumber].PanelFadeIn();
        
        if (PageNumber == 7)
        {
            _pages[PageNumber].gameObject.GetComponent<WinResult>().StartWinAnimation();
        }
        else if (PageNumber == 8)
        {
            _pages[PageNumber].gameObject.GetComponent<LoseResult>().StartLoseAnimation();
        }
    }

    public void ComeBackPage()
    {
        int number = _closePageNumber;
        HidePage(_currentPageNumber);
        _closePageNumber =_currentPageNumber;

        _currentPageNumber = number;
        ShowPage(_currentPageNumber);

    }
}
