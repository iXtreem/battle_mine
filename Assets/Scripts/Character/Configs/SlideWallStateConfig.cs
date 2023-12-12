using System;
using UnityEngine;

[Serializable]
public class SlideWallStateConfig
{
    [SerializeField, Range(-10, 0)] private float _speed;

    public float Speed => _speed;
}