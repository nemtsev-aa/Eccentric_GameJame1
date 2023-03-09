using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Tooltip("Менеджер игрового процесса")]
    [SerializeField] private GameProcessManager _gameProcessManager;
    
    [Header("Sound Effects")]
    [Tooltip("Источник звуковых эффектов")]
    [SerializeField] private AudioSource _soundEffectsSourse;
    [Tooltip("Звук сбора монеты")]
    [SerializeField] private AudioClip _coinPicSound;
    [Tooltip("Звук неудачного окончания игры")]
    [SerializeField] private AudioClip _fallingSound;
    [Tooltip("Звук удачного окончания игры")]
    [SerializeField] private AudioClip _winSound;
    
    /// Подписка на события 
    private void OnEnable()
    {
        _gameProcessManager.OnWin += _gameProcessManager_OnWin;
        _gameProcessManager.OnLose += _gameProcessManager_OnLose;
    }

    /// Отписка от события 
    private void OnDisable()
    {
        _gameProcessManager.OnWin -= _gameProcessManager_OnWin;
        _gameProcessManager.OnLose -= _gameProcessManager_OnLose;
    }

    private void СollectingСoins()
    {
        _soundEffectsSourse.PlayOneShot(_coinPicSound, 1f);
    }

    private void _gameProcessManager_OnWin()
    {
        _soundEffectsSourse.PlayOneShot(_winSound, 1f);
    }

    private void _gameProcessManager_OnLose()
    {
        _soundEffectsSourse.PlayOneShot(_fallingSound, 1f);
    }
}
