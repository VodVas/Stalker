using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BotMovement : MonoBehaviour
{
    [SerializeField] private Transform _targetPosition;
    [SerializeField] private float _moveSpeed = 3f;
    [SerializeField] private float _offSet = 1f;

    private bool _isMoving = false;
    private Rigidbody _rigidBody;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        ProcessMovement();
    }

    private void OnValidate()
    {
        if (_moveSpeed < 0)
        {
            _moveSpeed = 0;
        }
    }

    private void Stop()
    {
        _isMoving = false;
    }

    private void ProcessMovement()
    {
        if (_targetPosition == null)
        {
            return;
        }

        if (_isMoving == false && (transform.position - _targetPosition.position).sqrMagnitude > _offSet * _offSet)
        {
            _isMoving = true;
        }

        if (_isMoving == false)
        {
            return;
        }

        Vector3 direction = (_targetPosition.position - transform.position).normalized;
        Vector3 movement = new Vector3(direction.x, 0, direction.z) * _moveSpeed * Time.deltaTime;

        if ((transform.position - _targetPosition.position).sqrMagnitude <= _offSet * _offSet)
        {
            Stop();
        }
        else
        {
            Move(movement);
        }
    }

    private void Move(Vector3 movement)
    {
        _rigidBody.MovePosition(transform.position + movement);
    }
}