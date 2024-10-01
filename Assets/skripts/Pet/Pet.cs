using UnityEngine;

[RequireComponent(typeof(Mover))]
public class Pet : MonoBehaviour
{
    [SerializeField] private float _friendzone;
    [SerializeField] private LayerMask _layerMask;

    private Transform _transform;
    private Mover _mover;
    private Transform _target;

    private void Awake()
    {
        _transform = transform;
        _mover = GetComponent<Mover>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
            _target = other.transform;
    }

    private void OnTriggerExit(Collider other)
    {
        _target = null;
    }

    private void Update()
    {
        if (_target == null)
            return;

        RaycastHit hit = GetRaycastHit();
        _transform.LookAt(hit.point);

        if (hit.distance > _friendzone)
        {
            Vector3 direction = (hit.point - _transform.position).normalized;
            _mover.Move(direction.x, direction.z, Vector3.forward, Vector3.right);
        }
    }

    private RaycastHit GetRaycastHit()
    {
        Physics.Linecast(_transform.position, _target.position, out RaycastHit hit, _layerMask);

        return hit;
    }
}
