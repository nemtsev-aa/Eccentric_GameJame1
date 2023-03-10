using System;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;
    [SerializeField] private GameObject _destroyPrefab;
    [Range(0f, 1f)]
    [SerializeField] private float _fadeStart = 0.25f;
    [Range(0f, 1f)]
    [SerializeField] private float _fade = 0.25f;
    
    private Color _color;
    
    private void Start()
    {
        _color = _renderer.material.color;
        Fade(_fadeStart);
    }

    void AddFade(float fade)
    {
        if(_color.a == 1) return;
        _color.a += fade;
        _renderer.material.color = _color;
    }
    void Fade(float fade)
    {
        _color.a = fade;
        _renderer.material.color = _color;
    }

    public void TakeDamage(float damage)
    {
        if (damage > _color.a)
        {
            Fade(0.1f);
            Instantiate(_destroyPrefab, transform.position, Quaternion.identity);
            Invoke(nameof(Destroy), 0.4f);
        }
        else
        {
            _color.a -= damage;
            _renderer.material.color = _color;
        }
    }
    
    public void Destroy()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.rigidbody.TryGetComponent(out PlayerMoved playerMoved))
        {
            AddFade(_fade);
        }
    }

}
