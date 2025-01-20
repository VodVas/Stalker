using UnityEngine;

public class InputHandler
{
    private const string Horizontal = "Horizontal";
    private const string Vertical = "Vertical";

    public Vector3 GetInputVector(Transform playerTransform)
    {
        float horizontalInput = Input.GetAxisRaw(Horizontal);
        float verticalInput = Input.GetAxisRaw(Vertical);

        Vector3 forwardMovement = playerTransform.forward * verticalInput;
        Vector3 rightMovement = playerTransform.right * horizontalInput;

        return (forwardMovement + rightMovement).normalized;
    }
}