using UnityEngine;

namespace Assets.Weapon
{
    internal class WeaponView : MonoBehaviour
    {
        internal SpriteRenderer SpriteRenderer => _spriteRenderer;
        internal Transform FirePoint => _firePoint;
        internal GameObject GameObject => transform.gameObject;

        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Transform _firePoint;
    }
}
