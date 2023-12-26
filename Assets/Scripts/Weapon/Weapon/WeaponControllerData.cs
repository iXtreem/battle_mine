using System;

internal class WeaponControllerData
{
    public WeaponControllerData(WeaponConfig config)
    {
        _bulletCount = config.MaxBulletCount;
        _rateFire = config.RateFire;
        _currentMagazineCapacity = config.AmmoСapacity;
        AmmoСapacity = config.AmmoСapacity;
        TimeReloading = config.ReloadTime;
    }
    public int AmmoСapacity { get; private set; }

    public int CurrentMagazineCapacity
    {
        get 
        { 
            return _currentMagazineCapacity; 
        }
        set 
        { 
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value));

            _currentMagazineCapacity = value; 
        }
    }

    public int BulletCount
    {
        get
        {
            return _bulletCount;
        }
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value));

            _bulletCount = value;
        }
    }

    public float TimeShoot => (1 / _rateFire);
    public float TimeLastShot { get; set; }
    public bool IsReloading { get; set; }
    public float TimeReloading { get; private set; }

    private int _bulletCount;
    private int _currentMagazineCapacity;
    private float _rateFire;
    
}