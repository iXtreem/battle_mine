using System.Collections.Generic;
using UnityEngine;

namespace Assets.Weapon
{
    internal class WeaponInventory
    {
        public IReadOnlyList<string> weaponIDs => new List<string>(_weaponMap.Keys);
        public int CurrentIndexWeapon => _currentIndexWeapon;

        private WeaponView _weaponView;

        public WeaponInventory(WeaponView weaponView)
        {
            _weaponView = weaponView;
            _weaponMap = new Dictionary<string, Weapon> ();
        }

        private Dictionary<string, Weapon> _weaponMap;
        private Weapon _currentWeapon;
        private Weapon _prevWeapon;

        
        private int _currentIndexWeapon = 0;

        public void HandleInput()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                SwitchNextWeapon();
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                SwitchPrevWeapon();
            }
            _currentWeapon?.HandleInput();
        }

        private void SwitchPrevWeapon()
        {
            SwitchWeapon(_prevWeapon.Config.ID);
        }

        private void SwitchNextWeapon()
        {
            if (_currentIndexWeapon >= weaponIDs.Count)
                _currentIndexWeapon = 0;

            SwitchWeapon(weaponIDs[_currentIndexWeapon]);
            _currentIndexWeapon++;
        }

        public void Update() => _currentWeapon?.UpdateWeapon();

        public void AddWeapon(WeaponConfig weaponConfig)
        {
            Weapon weapon = GetWeapon(weaponConfig);
            _weaponMap.Add(weaponConfig.ID, weapon);
        }

        public bool TryAddWeapon(WeaponConfig weaponConfig) 
        {
            if (!_weaponMap.ContainsKey(weaponConfig.ID))
            {
                Weapon weapon = GetWeapon(weaponConfig);

                _weaponMap.Add(weaponConfig.ID, weapon);
                EquipFirstGun(weaponConfig.ID);

                return true;
            }

            return false;
        }

        public bool TryGetWeapon(string ID, out Weapon weapon)
        {
            weapon = default;

            if (_weaponMap.ContainsKey(ID))
            {
                weapon = _weaponMap[ID];
                return true;
            }
            return false;
        }

        public bool SwitchWeapon(string ID)
        {
            if (_weaponMap.ContainsKey(ID))
            {
                _prevWeapon = _currentWeapon;
                _currentWeapon = _weaponMap[ID];

                UpdateWeaponView();

                return true;
            }

            return false;
        }

        private void UpdateWeaponView()
        {
            _weaponView.SpriteRenderer.sprite = _currentWeapon.Config.Sprite;
        }

        private void EquipFirstGun(string ID)
        {
            if (_currentWeapon == null)
            {
                SwitchWeapon(ID);
                _prevWeapon = _currentWeapon;
            }
        }

        private Weapon GetWeapon(WeaponConfig weaponConfig)
        {
            return new Weapon(_weaponView, weaponConfig);
        }
    }
}