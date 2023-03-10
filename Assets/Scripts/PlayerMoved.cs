using UnityEngine;

public class PlayerMoved : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private int _force = 20;
    
    public bool IsActive { get; private set; }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            IsActive = true;
            Cursor.lockState = CursorLockMode.None;
            AdForce();
        }
    }

    
    private void AdForce()
    {
        _rigidbody2D.velocity = Vector2.up * _force;
    }
}
