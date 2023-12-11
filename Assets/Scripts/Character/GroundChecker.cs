using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private LayerMask _groundLayerMask;

    [SerializeField, Range(0.01f, 1)] private float _distanceToCheck;

    public bool IsTouches { get; private set; }

    private void Update() => IsTouches = Physics2D.Raycast(transform.position, Vector2.down, _distanceToCheck, _groundLayerMask);
}