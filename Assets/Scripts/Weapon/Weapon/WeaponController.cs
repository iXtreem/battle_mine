using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponController
{
    private readonly IWeaponInfo _info; 
    private readonly List<Bullet> _bulletPrefab;
    
    private WeaponControllerData _data;

    public WeaponController(IWeaponInfo info, WeaponConfig weaponConfig)
    {
        _info = info;
        _bulletPrefab = new List<Bullet>(weaponConfig.BulletList);
        _data = new WeaponControllerData(weaponConfig);
    }

    protected bool ShootIsReady() => _data.Time <= 0;
    protected bool WeaponIsEmpty => _data.BulletCount == 0;

    public virtual void Shoot()
    {
        if (ShootIsReady() && !WeaponIsEmpty)
        {
            _data.Time = _data.TimeShoot;

            if (_info.GameObject.activeSelf)
            {
                GameObject.Instantiate(_bulletPrefab[0].gameObject, _info.FirePoint.position, _info.FirePoint.rotation);
                _data.BulletCount--;
            }
        }
    }

    public virtual void UpdateWeapon()
    {
        _data.Time -= Time.deltaTime;
    }
}
