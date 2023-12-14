using UnityEngine;

[CreateAssetMenu(fileName = "BulletConfig", menuName = "Configs/BulletConfig")]
public class BulletConfig : ScriptableObject
{
    public float Velocity => _velocity;
    public float LifeTime => _lifeTime;
    public float MinAngle => _minAngle;
    public float MaxAngle => _maxAngle;

    [SerializeField, Range(0.01f, 100)] private float _velocity = 10f;
    [SerializeField, Range(0.01f, 100)] private float _lifeTime = 5;

    [SerializeField, Range(-180, 0)] private float _minAngle;
    [SerializeField, Range(0, 180)] private float _maxAngle;
}

