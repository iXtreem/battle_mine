using UnityEngine;

public class WallChecker : MonoBehaviour
{
    [SerializeField] private LayerMask _wallLayerMask;

    [SerializeField, Range(0.01f, 1)] private float _distanceToCheck;

    public bool _isTouchesLeftWall { get; private set; }
    public bool _isTouchesRightWall { get; private set; }

    public bool IsTouchesWall => _isTouchesLeftWall || _isTouchesRightWall;

    private void Update()
    {
        _isTouchesLeftWall = IsTouches(Vector2.left);
        _isTouchesRightWall = IsTouches(Vector2.right); ;
    }

    private RaycastHit2D IsTouches(Vector2 vector)
    {
        return Physics2D.Raycast(transform.position, vector, _distanceToCheck, _wallLayerMask);
    }
}