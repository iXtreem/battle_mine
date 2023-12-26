using UnityEngine;

namespace Assets.Weapon
{
    internal class BaseWeaponController : WeaponController
    {
        public BaseWeaponController(Weapon weapon, WeaponConfig weaponConfig) : base(weapon, weaponConfig)
        {

        }

        public override void HandleInput()
        {
            base.HandleInput();

            if (Input.GetKey(KeyCode.Mouse0))
            {
                Shoot();
            }
        }
    }
}