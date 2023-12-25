using UnityEngine;

internal class HandController
{
    private Transform _characerTransform;
    private Transform _handTransform;
    private Camera _camera;

    private const float Offset = 0f;
    private const float Angle = 90f;

    internal HandController(Camera camera, Transform characerTransform, Transform handTransform)
    {
        _characerTransform = characerTransform;
        _handTransform = handTransform;
        _camera = camera;
    }

    public void Update()
    {
        RotationHand();
    }

    private void RotationHand()
    {
        if (_handTransform != null)
        {
            float rotZ = GetAngleRotation();
            Vector3 localScale = GetLocalScale(rotZ);

            _handTransform.localScale = localScale;
            _handTransform.rotation = Quaternion.Euler(0, 0, rotZ + Offset);
        }
    }

    private static Vector3 GetLocalScale(float rotZ)
    {
        Vector3 localScale = Vector3.one;
        localScale.y = (rotZ > 90 || rotZ < -90) ? -1 : 1;

        return localScale;
    }

    private float GetAngleRotation()
    {
        Vector3 difference = _camera.ScreenToWorldPoint(Input.mousePosition) - _handTransform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        rotZ = _characerTransform.rotation.y < 0 ? Mathf.Clamp(Mathf.Abs(rotZ), Angle + 0.1f, 2 * Angle) * Mathf.Clamp(rotZ, -1, 1) : Mathf.Clamp(rotZ, -Angle, Angle);
        
        return rotZ;
    }
}