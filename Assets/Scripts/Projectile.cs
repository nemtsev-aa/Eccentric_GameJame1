using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [Range(0, 1)]
    [SerializeField] private float _damage;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.TryGetComponent(out Block block))
        {
            block.TakeDamage(_damage);
            Destroy(gameObject);
        }
    }

    public void AddVelocity(int speed)
    {
        _rigidbody2D.velocity = Vector2.down * speed;
    }
}
