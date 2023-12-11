using System;
using UnityEngine;

[Serializable]
public class RunningStateConfig
{
    [SerializeField, Range(0, 100)] private float _speed;

    public float Speed => _speed;
}