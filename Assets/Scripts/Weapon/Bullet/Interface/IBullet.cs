using UnityEngine;

public interface IBullet
{
    BulletConfig Config { get; }
    Transform Transform { get; }
    Rigidbody2D Rigidbody2D { get; }
}