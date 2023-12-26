
using UnityEngine;

namespace Assets.Weapon
{
    internal class Weapon 
    {
        internal WeaponControllerData Data => _data;
        internal WeaponView View => _view;
        internal WeaponConfig Config => _config;

        private WeaponConfig _config;
        private WeaponView _view;
        private WeaponController _controller;
        private WeaponControllerData _data;
        internal Weapon(WeaponView view, WeaponConfig weaponConfig)
        {
            _config = weaponConfig;
            _view = view;

            _controller = GetWeaponController();
            _data = new WeaponControllerData(weaponConfig);
        }

        private WeaponController GetWeaponController()
        {
            if (_config.WeaponShootType == WeaponShootType.SingleShots)
             return new PistolWeaponController(this, _config);
            else
                return new BaseWeaponController(this, _config);
        }

        public void HandleInput()
        {
            _controller.HandleInput();

            if (Input.GetKeyDown(KeyCode.R)) 
            {
                _controller.ReloadWeapon();
            }
        }
        
        public void UpdateWeapon() => _controller.UpdateWeapon();
        public void AddBullet() => _controller.AddBullet();
    }
}