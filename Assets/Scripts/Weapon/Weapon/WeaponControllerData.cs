using System;

internal class WeaponControllerData
{
    private int _bulletCount;
    private float _rateFire;

    public WeaponControllerData(WeaponConfig config)
    {
        _bulletCount = config.MaxBulletCount;
        _rateFire = config.RateFire;
    }

    public int BulletCount 
    {
        get 
        { 
            return _bulletCount; 
        }
        set 
        { 
            if (value< 0)
                throw new ArgumentOutOfRangeException(nameof(value));

            _bulletCount = value; 
        }
    }
    public float TimeShoot => (1 / _rateFire);

    public float Time { get; set; } 
}