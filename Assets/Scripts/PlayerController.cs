using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class PlayerController : MonoBehaviour
{
    private Vector3 _direction = new Vector2();
    private const float _defaultSpeed = 4;
    private float _currentSpeed = _defaultSpeed;

    public Vector3 Velocity
    {
        get { return _direction * _currentSpeed; }
    }

    private void Awake()
    {
        InputSystem.actions.FindAction("Move").performed += OnMovePressed;
        InputSystem.actions.FindAction("Move").canceled += OnMoveReleased;
    }

    private void OnMovePressed(CallbackContext ctx)
    {
        _direction = ctx.ReadValue<Vector2>();
    }

    private void OnMoveReleased(CallbackContext ctx)
    {
        _direction = Vector2.zero;
    }

    private void FixedUpdate()
    {
        float dt = Time.deltaTime;
        transform.position += dt * Velocity;
    }
}
