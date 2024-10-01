using UnityEngine;


[RequireComponent(typeof(CharacterController))]
public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private CharacterController _controller;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }

    public void Move(float directionX, float directionZ, Vector3 forward, Vector3 right)
    {
        if (_controller.isGrounded)
        {
            Vector3 playerDirection = (forward * directionZ + right * directionX) * _speed * Time.deltaTime;
            _controller.Move(playerDirection + Vector3.down);
        }
        else
        {
            _controller.Move(_controller.velocity + Physics.gravity * Time.deltaTime);
        }
    }

}
