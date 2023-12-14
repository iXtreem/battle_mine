using UnityEngine;

public class Weapon : MonoBehaviour, IWeapon, IWeaponInfo
{
    [SerializeField] private WeaponConfig _config;
    [SerializeField] private Transform _firePoint;

    private WeaponController _controller;
    public Transform FirePoint => _firePoint;
    public Transform Transform => transform;
    public Rigidbody2D Rigidbody2D => throw new System.NotImplementedException();
    public GameObject GameObject => transform.gameObject;

    private void Start()
    {
        _controller = new BaseWeaponController(this, _config);
    }

    private void Update()
    {
        _controller?.UpdateWeapon();
        Shoot();//TODO
    }

    public void Shoot() 
    {
        _controller?.Shoot();
    }
}

public enum WeaponType
{
    Base,
    Super,
}