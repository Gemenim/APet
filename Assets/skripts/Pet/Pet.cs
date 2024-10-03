using UnityEngine;

[RequireComponent(typeof(RigidbodyMover))]
public class Pet : MonoBehaviour
{    
    [SerializeField] private float _friendzone;
    [SerializeField] private LayerMask _layerMask;    

    private Transform _transform;
    private RigidbodyMover _mover;
    private Transform _target;

    private void Awake()
    {
        _transform = transform;
        _mover = GetComponent<RigidbodyMover>();
    }

    private void OnValidate()
    {
        if (_friendzone < 0)
            _friendzone = 1;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
            _target = other.transform;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
            _target = null;
    }

    private void Update()
    {
        if (_target == null)
            return;

        RaycastHit hit = GetRaycastHit();
        _mover.TurnTo(hit.point);

        if (hit.distance > _friendzone)
        {
            _mover.Move(hit.point);
        }
    }

    private RaycastHit GetRaycastHit()
    {
        Physics.Linecast(_transform.position, _target.position, out RaycastHit hit, _layerMask);

        return hit;
    }
}
