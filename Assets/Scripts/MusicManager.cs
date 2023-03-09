using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [Tooltip("Менеджер игрового процесса")]
    [SerializeField] private GameProcessManager _gameProcessManager;
       
    [Header("Music")]
    [Tooltip("Источник музыки")]
    [SerializeField] private AudioSource _musicSource;
    [Tooltip("Mузыка в меню")]
    [SerializeField] private AudioClip _uiMusicClip;
    [Tooltip("Музыка в игре")]
    [SerializeField] private AudioClip _gameMusicClip;

    /// Подписка на события 
    private void OnEnable()
    {
        _gameProcessManager.OnHome += PlayUIMusic;
        _gameProcessManager.OnSettings += PlayUIMusic;
        _gameProcessManager.OnAuthors += PlayUIMusic;
        _gameProcessManager.OnLevels += PlayUIMusic;
        _gameProcessManager.OnPause += PlayUIMusic;
        _gameProcessManager.OnGame += PlayGameMusic;
        _gameProcessManager.OnWin += _gameProcessManager_OnWin;
        _gameProcessManager.OnLose += _gameProcessManager_OnLose;
    }

    /// Отписка от события 
    private void OnDisable()
    {
        _gameProcessManager.OnHome -= PlayUIMusic;
        _gameProcessManager.OnSettings -= PlayUIMusic;
        _gameProcessManager.OnAuthors -= PlayUIMusic;
        _gameProcessManager.OnLevels -= PlayUIMusic;
        _gameProcessManager.OnPause -= PlayUIMusic;
        _gameProcessManager.OnGame -= PlayGameMusic;
        _gameProcessManager.OnWin -= _gameProcessManager_OnWin;
        _gameProcessManager.OnLose -= _gameProcessManager_OnLose;
    }

    private void _gameProcessManager_OnWin()
    {
        _musicSource.Stop();
    }

    private void _gameProcessManager_OnLose()
    {
        _musicSource.Stop();
    }

    private void PlayUIMusic()
    {
        _musicSource.clip = _uiMusicClip;
        if (!_musicSource.isPlaying)
        {
            _musicSource.Play();
        } 
    }

    private void PlayGameMusic()
    {
        _musicSource.clip = _gameMusicClip;
        if (!_musicSource.isPlaying)
        {
            _musicSource.Play();
        }
    }

}
