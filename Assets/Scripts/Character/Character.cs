using Assets.Weapon;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
[RequireComponent(typeof(CharacterView))]
public class Character : MonoBehaviour
{
    [SerializeField] private CharacterView _view;
    [SerializeField] private GroundChecker _groundChecker;
    [SerializeField] private WallChecker _wallChecker;
    [SerializeField] private CharacterConfig _config;
    [SerializeField] private Transform _handTransform;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private WeaponView _weaponView;

    private CharacterStateMachine _stateMachine;
    private HandController _handController;
    private WeaponInventory _weaponInventory;
    public Rigidbody2D Rigidbody => _rigidbody;
    public CharacterView View => _view;
    public CharacterConfig Config => _config;
    public GroundChecker GroundChecker => _groundChecker;
    public WallChecker WallChecker => _wallChecker;

    public void SetWeapon(WeaponConfig weaponConfig) 
    {
        if (!_weaponInventory.TryAddWeapon(weaponConfig))
        {
            if (_weaponInventory.TryGetWeapon(weaponConfig.ID, out Weapon weapon)) 
            {
                weapon.AddBullet();
            }
        }
    }

    private void OnValidate()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _view = GetComponent<CharacterView>();
    }

    private void Awake()
    {
        _view.Initialize();
        _rigidbody = _rigidbody != null ? _rigidbody: GetComponent<Rigidbody2D>();
        _view = _view != null ? _view : GetComponent<CharacterView>();

        _stateMachine = new CharacterStateMachine(this);
        _handController = new HandController(Camera.main, transform, _handTransform);
        _weaponInventory = new WeaponInventory(_weaponView);
    }

    private void Update()
    {
        _weaponInventory.HandleInput();
        _stateMachine.HandleInput();
        _stateMachine.Update();
        _weaponInventory.Update();
        _handController.Update();
    }

    private void FixedUpdate()
    {
        _stateMachine.FixedUpdate();
    }
}