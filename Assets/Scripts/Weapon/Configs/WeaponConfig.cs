using Assets.Weapon;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponConfig", menuName = "Configs/WeaponConfig")]
public class WeaponConfig : ScriptableObject
{
    public string ID => _id;
    public Sprite Sprite => _sprite;
    public WeaponType Type => _type;
    public WeaponShootType WeaponShootType => _weaponShootType;
    public IReadOnlyList<Bullet> BulletList => _bulletList;
    public float RateFire => _rateFire;
    public float ReloadTime => _reloadTime;
    public int MaxBulletCount => _maxBulletCount;
    public int Ammo—apacity => _ammo—apacity;

    [SerializeField] private string _id;
    [SerializeField] private Sprite _sprite;
    [SerializeField, Range(0.01f, 100)] private float _rateFire = 5;
    [SerializeField, Range(0.01f, 10)] private float _reloadTime;
    [SerializeField] private List<Bullet> _bulletList;
    [SerializeField] private WeaponType _type;
    [SerializeField] private WeaponShootType _weaponShootType;
    [SerializeField, Range(1, 999)] private int _maxBulletCount;
    [SerializeField, Range(1, 999)] private int _ammo—apacity;
    

}

public enum WeaponType
{
    Base,
    Super,
}

public enum WeaponShootType
{
    SingleShots,
    BurstShooting,
}