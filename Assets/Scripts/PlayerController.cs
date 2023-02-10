using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody rigidbody;
    [SerializeField] Transform camera;

    [SerializeField] float speed = 3;
    [SerializeField] float rotationSpeed = 2;

    void Update()
    {
        HandleMovement();
        HandleHorizontalRotation();
        HandleVerticalRotation();
        HandleJump();
    }

    void HandleMovement()
    {
        var input = new Vector3
            (
            Input.GetAxis("Horizontal"),
            0,
            Input.GetAxis("Vertical")
            );

        if (Input.GetKey(KeyCode.LeftShift))
            input *= 2;

        var velocity = transform.rotation * input * speed;
        velocity.y = rigidbody.velocity.y;
        rigidbody.velocity = velocity;
    }

    void HandleHorizontalRotation()
    {
        var input = Input.GetAxis("Mouse X");
        var rotation = transform.localRotation.eulerAngles;
        rotation.y += input * rotationSpeed;
        transform.localRotation = Quaternion.Euler(rotation);
    }

    void HandleVerticalRotation()
    {
        var input = Input.GetAxis("Mouse Y");
        var rotation = camera.localRotation.eulerAngles;
        rotation.x -= input * rotationSpeed;
        camera.localRotation = Quaternion.Euler(rotation);
    }

    void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            var velocity = rigidbody.velocity;
            velocity.y = 5;
            rigidbody.velocity = velocity;

        }
    }

    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1.2f);
    }
}
