using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    [SerializeField] private PlayerMoved _playerMoved;
    [SerializeField] private GameController _gameController;
    [SerializeField] private Rigidbody2D _playerRigidbody;
    [SerializeField] private Camera _camera;
    [SerializeField] private float _speed = 10f;

    private void Update()
    {
        if(!_playerMoved.IsActive) return;
        //if(_gameController.IsTimeSlow) return;
        
        PlatformMoved();
    }

    private void PlatformMoved()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(Vector3.forward, Vector3.zero);
        plane.Raycast(ray, out float distance);
        Vector3 point = ray.GetPoint(distance);
        float posX = Mathf.Clamp(point.x, 0, 12 / _speed);
        transform.position = new Vector2(posX * _speed, 0);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponentInParent<PlayerMoved>())
        {
            Vector2 collisionNormal = collision.contacts[0].normal;
            Vector2 collisionVector = collisionNormal * -1f;
            _playerRigidbody.velocity = collisionVector * 30;
        }
    }
}
