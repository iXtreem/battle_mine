using UnityEngine;

public class BaseBulletMovement : IMover
{ 
    private readonly IBullet _bullet;

    public BaseBulletMovement(IBullet bullet)
    {
        _bullet = bullet;
        Initialize();
    }

    private void Initialize()
    {
        _bullet.Rigidbody2D.velocity = BulletDirection * _bullet.Config.Velocity;
    }

    protected virtual IBullet Bullet => _bullet;
    protected virtual Vector2 BulletDirection => _bullet.Transform.right;

    public void StartMove() 
    {
        Rotate();
    }

    private void Rotate()
    {
        _bullet.Transform.rotation = GetRotation();
    }

    private Quaternion GetRotation()
    {
        float angle = Mathf.Atan2(_bullet.Rigidbody2D.velocity.y, _bullet.Rigidbody2D.velocity.x) * Mathf.Rad2Deg;
        angle -= 90;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        return rotation;
    }

    public void StopMove()
    {
    }
}
