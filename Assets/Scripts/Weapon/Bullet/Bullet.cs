using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public abstract class Bullet : MonoBehaviour, IBullet
{
    [SerializeField] private BulletConfig _config;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private BoxCollider2D _boxCollider;

    protected IMover Mover;
    protected Transform PlayerTransform;

    public BulletConfig Config => _config;
    public Rigidbody2D Rigidbody2D => _rb;
    public Transform Transform => transform;
    protected BoxCollider2D BoxCollider2D => _boxCollider;

    protected virtual void OnValidate()
    {
        _rb = GetComponent<Rigidbody2D>();
        _boxCollider = GetComponent<BoxCollider2D>();
    }

    protected virtual void Start()
    {
        _rb = _rb != null ? _rb : GetComponent<Rigidbody2D>();
        _boxCollider = _boxCollider!= null ? _boxCollider : GetComponent<BoxCollider2D>();

        StartCoroutine(DelayDestroy());
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out IDamagable damagable))
        {
            damagable.Damage(1);
        }

        DestroyBullet();
    }

    protected virtual IEnumerator DelayDestroy()
    {
        yield return new WaitForSeconds(_config.LifeTime);

        DestroyBullet();
    }

    public void DestroyBullet() 
    {
        Mover.StopMove();
        Destroy(gameObject);
    }
}

