using System.Collections;
using DG.Tweening;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Transform _spawnertransform;
    [SerializeField] private Projectile _projectilePrefab;

    private float _timer;
    
    private void Update()
    {
        _timer += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            StartCoroutine(Move());
        }
        
        if (_timer >= Random.Range(4, 7))
        {
            if(Random.Range(0, 2) == 0) 
            {
                int random = Random.Range(0, 2);
                _animator.SetTrigger(random == 0 ? "Cast Spell" : "Projectile Attack");
                Invoke(nameof(Attack), 0.3f);
            } 
            else 
            {
                StartCoroutine(Move());
            }
            _timer = 0;
        }
    }

    private IEnumerator Move()
    {
        Vector3 position = transform.localPosition;
        if (Random.Range(0, 2) == 1) {
            if (position.x == 16) {
                position.x -= 2;
            } else {
                position.x += 2;
            }
        } else {
            if (position.x == 0) {
                position.x += 2;
            } else {
                position.x -= 2;
            }
        }
        
        string animationName;
        animationName = transform.localPosition.x < position.x ? "Strafe Left" : "Strafe Right";
        _animator.SetBool(animationName, true);
        transform.DOMove(position, 2).SetEase(Ease.Linear);
        yield return new WaitForSeconds(2);
        _animator.SetBool(animationName, false);
        yield return null;
    }
    
    public void Attack()
    {
        Projectile projectile = Instantiate(_projectilePrefab, 
            _spawnertransform.position, Quaternion.identity);
        projectile.AddVelocity(5);
    }
}
