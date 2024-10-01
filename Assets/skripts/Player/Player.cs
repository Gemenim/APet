using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Mover _mover;
    [SerializeField] private CameraMover _cameraMover;

    private InputPlayer _inputPlayer;

    private void Awake()
    {
        _inputPlayer = new InputPlayer();
    }

    private void Update()
    {
        _cameraMover.Move(_inputPlayer.MouseX);
        _mover.Move(_inputPlayer.Horizontal, _inputPlayer.Vertical, _cameraMover.Forward, _cameraMover.Right);
    }
}
