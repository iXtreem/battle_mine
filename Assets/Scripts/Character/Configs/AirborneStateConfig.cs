using System;
using UnityEngine;

[Serializable]
public class AirborneStateConfig
{
    [SerializeField] private JumpingStateConfig _jumpingStateConfig;
    [SerializeField, Range(0, 100)] private float _speed;

    public JumpingStateConfig JumpingStateConfig => _jumpingStateConfig;

    public float Speed => _speed;
}