using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Weapon
{
    internal abstract class WeaponController
    {
        protected WeaponControllerData Data => _weapon.Data;

        private readonly Weapon _weapon;
        private readonly List<Bullet> _bulletPrefab;

        internal WeaponController(Weapon weapon, WeaponConfig weaponConfig)
        {
            _weapon = weapon;
            _bulletPrefab = new List<Bullet>(weaponConfig.BulletList);
        }

        public virtual void HandleInput() 
        {
        }

        public virtual void UpdateWeapon()
        {
            Data.TimeLastShot -= Time.deltaTime;
        }

        protected bool MagazineIsEmpty => Data.CurrentMagazineCapacity == 0;
        protected bool ShootIsReady() => Data.TimeLastShot <= 0; 
        protected bool CanShoot() => ShootIsReady() && !MagazineIsEmpty && !Data.IsReloading;

        public virtual void Shoot()
        {
            if (CanShoot())
            {
                Data.TimeLastShot = Data.TimeShoot;

                GameObject.Instantiate(_bulletPrefab[0].gameObject, _weapon.View.FirePoint.position, _weapon.View.GameObject.transform.rotation);
                Data.CurrentMagazineCapacity--;
            }
        }

        public void AddBullet()
        {
            Data.BulletCount += Data.AmmoÑapacity * 2;
        }


        public void ReloadWeapon()
        {
            Data.IsReloading = true;
            CoroutineController.StartCoroutine(ReloadingCoroutine(()=> Data.IsReloading = false));
            if (Data.CurrentMagazineCapacity != Data.AmmoÑapacity)
            {
                int necessaryRoundsLoadMagazine = Data.AmmoÑapacity - Data.CurrentMagazineCapacity;

                if (Data.BulletCount >= necessaryRoundsLoadMagazine)
                {
                    Data.CurrentMagazineCapacity = Data.AmmoÑapacity;
                    Data.BulletCount -= necessaryRoundsLoadMagazine;
                }
                else
                {
                    Data.CurrentMagazineCapacity = Data.BulletCount;
                    Data.BulletCount -= Data.BulletCount;
                }
            }
        }

        private IEnumerator ReloadingCoroutine(Action callback) 
        {
            yield return new WaitForSeconds(Data.TimeReloading);

            callback?.Invoke();
        }
    }
}
