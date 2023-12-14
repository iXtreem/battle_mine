using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponConfig", menuName = "Configs/WeaponConfig")]
public class WeaponConfig : ScriptableObject
{
    public WeaponType Type => _type;
    public IReadOnlyList<Bullet> BulletList => _bulletList;
    public float RateFire => _rateFire;
    public int MaxBulletCount => _maxBulletCount;

    [SerializeField, Range(0.01f, 100)] private float _rateFire = 5;
    [SerializeField] private List<Bullet> _bulletList;
    [SerializeField] private WeaponType _type;
    [SerializeField, Range(1, 999)] private int _maxBulletCount;
}
