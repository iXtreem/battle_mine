using UnityEngine;

namespace Assets.Weapon
{
    internal class PistolWeaponController : WeaponController
    {
        public PistolWeaponController(Weapon weapon, WeaponConfig weaponConfig) : base(weapon, weaponConfig)
        {
        }

        public override void HandleInput()
        {
            base.HandleInput();

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Shoot();
            }
        }
    }
}