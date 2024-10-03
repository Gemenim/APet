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

    private void OnValidate()
    {
        if (_speed < 0)
            _speed = 1;
    }

    public void Move(float speedX, float speedZ, Vector3 forward, Vector3 right)
    {
        if (_controller.isGrounded)
        {
            Vector3 playerSpeed = (forward * speedZ + right * speedX) * _speed * Time.deltaTime;
            _controller.Move(playerSpeed + Vector3.down);
        }
        else
        {
            _controller.Move(_controller.velocity + Physics.gravity * Time.deltaTime);
        }
    }
}
