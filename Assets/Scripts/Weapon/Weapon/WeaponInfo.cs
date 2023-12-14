using UnityEngine;

public interface IWeaponInfo
{
    Transform Transform { get; }
    Rigidbody2D Rigidbody2D { get; }
    GameObject GameObject { get; }
    Transform FirePoint { get; }
}