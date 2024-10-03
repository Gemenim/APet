using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RigidbodyMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _stepRayUpper;
    [SerializeField] private Transform _stepRayLower;
    [SerializeField] private float _stepHeight;
    [SerializeField] private float _stepUp;

    private Transform _transform;
    private Rigidbody _rigidbody;

    private const float _distansHitLower = 0.1f;
    private const float _distansHitUpper = 0.2f;

    private void Awake()
    {
        _transform = transform;
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnValidate()
    {

        if (_speed < 0)
            _speed = 1;

        if (_stepHeight < 0)
            _stepHeight = 1;

        if (_stepUp < 0)
            _stepUp = 0.1f;

        _stepRayUpper.position = new Vector3(_stepRayUpper.position.x, _stepHeight, _stepRayUpper.position.z);
    }

    public void Move(Vector3 targetDirection)
    {
        Vector3 petSpeed = (targetDirection - _transform.position).normalized * _speed + Vector3.down;
        _rigidbody.velocity = petSpeed;
        Raise();
    }

    public void TurnTo(Vector3 target)
    {
        _transform.LookAt(target);
        _transform.rotation = new Quaternion(0, _transform.rotation.y, 0, _transform.rotation.w);
    }

    private void Raise()
    {
        if (Physics.Raycast(_stepRayLower.position, _transform.TransformDirection(Vector3.forward), out RaycastHit hitLower, _distansHitLower))
        {
            if (!Physics.Raycast(_stepRayUpper.position, _transform.TransformDirection(Vector3.forward), out RaycastHit hitUpper, _distansHitUpper))
            {
                _rigidbody.position += new Vector3(0, _stepUp, 0);
            }
        }

        if (Physics.Raycast(_stepRayLower.position, _transform.TransformDirection(1.5f, 0, 1), out RaycastHit hitLower45, _distansHitLower))
        {
            if (!Physics.Raycast(_stepRayUpper.position, _transform.TransformDirection(1.5f, 0, 1), out RaycastHit hitUpper45, _distansHitUpper))
            {
                _rigidbody.position += new Vector3(0, _stepUp, 0);
            }
        }

        if (Physics.Raycast(_stepRayLower.position, _transform.TransformDirection(-1.5f, 0, 1), out RaycastHit hitLowerMinus45, _distansHitLower))
        {
            if (!Physics.Raycast(_stepRayUpper.position, _transform.TransformDirection(-1.5f, 0, 1), out RaycastHit hitUpperMinuse45, _distansHitUpper))
            {
                _rigidbody.position += new Vector3(0, _stepUp, 0);
            }
        }
    }
}
