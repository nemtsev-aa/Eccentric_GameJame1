using UnityEngine;

public class GameController : MonoBehaviour
{
    [Range(0, 1)]
    [SerializeField] private float _timeScale;

    private float _startTimeScale;
    private bool _isTimeSlow;

    public bool IsTimeSlow => _isTimeSlow;
    
    private void Start()
    {
        _startTimeScale = Time.timeScale;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!_isTimeSlow)
            {
                Time.timeScale = _timeScale;
                _isTimeSlow = true;
            }
            else
            {
                Time.timeScale = _startTimeScale;
                _isTimeSlow = false;
            }
        }
    }
}
