using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _horizontalTurnSensitivity;

    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }


    public Vector3 Forward => Vector3.ProjectOnPlane(_transform.forward, Vector3.up).normalized;
    public Vector3 Right => Vector3.ProjectOnPlane(_transform.right, Vector3.up).normalized;

    public void Move(float cameraDirection)
    {
        _player.Rotate(Vector3.up * _horizontalTurnSensitivity * cameraDirection);
    }
}
