using UnityEngine;

[CreateAssetMenu(fileName = "BulletConfig", menuName = "Configs/BulletConfig")]
public class BulletConfig : ScriptableObject
{
    public float Velocity => _velocity;
    public float LifeTime => _lifeTime;

    [SerializeField, Range(0.01f, 100)] private float _velocity = 10f;
    [SerializeField, Range(0.01f, 100)] private float _lifeTime = 5;
}

