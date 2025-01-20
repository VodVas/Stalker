using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;

    private Vector3 _moveDirection;
    private CharacterController _characterController;
    private InputHandler _inputHandler;
    private GravityApplier _gravityApplier;
    private Mover _mover;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _inputHandler = new InputHandler();
        _gravityApplier = new GravityApplier();
        _mover = new Mover(_moveSpeed);
    }

    private void Update()
    {
        ProcessInput();
        ApplyGravity();
        Move();
    }

    private void OnValidate()
    {
        if (_moveSpeed < 0)
        {
            _moveSpeed = 0;
        }
    }

    private void ProcessInput()
    {
        Vector3 inputDirection = _inputHandler.GetInputVector(transform);

        SetMoveDirection(inputDirection);
    }

    private void SetMoveDirection(Vector3 direction)
    {
        _moveDirection.x = direction.x;
        _moveDirection.z = direction.z;
    }

    private void ApplyGravity()
    {
        float verticalVelocity = _gravityApplier.ApplyGravity(_characterController);
        _moveDirection.y = verticalVelocity;
    }

    private void Move()
    {
        _mover.Move(_characterController, _moveDirection);
    }
}