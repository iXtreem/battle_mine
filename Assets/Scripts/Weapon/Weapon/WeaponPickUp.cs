using UnityEngine;

namespace Assets.Weapon
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class WeaponPickUp : MonoBehaviour
    {
        [SerializeField] private WeaponConfig _config;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private BoxCollider2D _boxCollider2D;
        private void OnValidate()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _boxCollider2D = GetComponent<BoxCollider2D>();
        }

        private void Start()
        {
            _boxCollider2D = _boxCollider2D != null ? _boxCollider2D : GetComponent<BoxCollider2D>();
            _spriteRenderer = _spriteRenderer != null ? _spriteRenderer : GetComponent<SpriteRenderer>();
            _spriteRenderer.sprite = _config.Sprite;

            _boxCollider2D.isTrigger = true;
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Character character))
            {
                //if (Input.GetKeyDown(KeyCode.E))
                {
                    character.SetWeapon(_config);
                    Destroy(gameObject);
                }
            }
        }
    }
}
