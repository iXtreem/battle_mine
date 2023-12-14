using System;
using UnityEngine;

[Serializable]
public class JumpingStateConfig
{
    [SerializeField, Range(0, 100)] private float _maxHeight;
    [SerializeField, Range(0, 100)] private float _timeToReachMaxHeight;
    [SerializeField, Range(0, 100f)] private float _cooldownJumping;
    [SerializeField, Range(0, 5f)] private float _minDirectionJumping;
    public float StartYVelocity => 2 * _maxHeight / _timeToReachMaxHeight;
    public float CooldownJumping => _cooldownJumping;
    public float MinDirectionJumping => _minDirectionJumping;
}