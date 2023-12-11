using System;
using UnityEngine;

[Serializable]
public class JumpingStateConfig
{
    [SerializeField, Range(0, 100)] private float _maxHeight;
    [SerializeField, Range(0, 100)] private float _timeToReachMaxHeight;

    public float StartYVelocity => 2 * _maxHeight / _timeToReachMaxHeight;
}