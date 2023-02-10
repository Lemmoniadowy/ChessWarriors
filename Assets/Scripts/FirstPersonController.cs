using Cinemachine;
using UnityEngine;

public class FirstPersonController : MonoBehaviour {
    public float movementSpeed = 2;
    public float rotationSpeed = 2;
    public float jumpForce = 5;
    new CinemachineVirtualCamera camera;
    new Rigidbody rigidbody;

    void Awake() {
        rigidbody = GetComponent<Rigidbody>();
        camera = GetComponentInChildren<CinemachineVirtualCamera>();
    }

    int howManyTimesPlayerCanJump;
    
    void Update() {
        HandleWalking();
        HandleHorizontalRotation();
        HandleVerticalRotation();
        HandleJumping();
    }

    void HandleVerticalRotation() {
        var mouseVerticalRotation = Input.GetAxis("Mouse Y");
        var camRot = camera.transform.rotation.eulerAngles;
        camRot.x = camRot.x - mouseVerticalRotation*rotationSpeed;
        camera.transform.rotation = Quaternion.Euler(camRot);
    }

    void HandleHorizontalRotation() {
        var mouseHorizontalRotation = Input.GetAxis("Mouse X");
        var newRotation = transform.localRotation.eulerAngles;
        newRotation.y = newRotation.y + mouseHorizontalRotation*rotationSpeed;
        transform.localRotation = Quaternion.Euler(newRotation);
    }

    void HandleWalking() {
        var userKeyboardInput = new Vector3(
            Input.GetAxis("Horizontal"),
            0,
            Input.GetAxis("Vertical")
        );
        var velocity = transform.rotation * userKeyboardInput * movementSpeed;
        if (Input.GetKey(KeyCode.LeftShift)) velocity = velocity * 2;
        velocity.y = rigidbody.velocity.y;
        rigidbody.velocity = velocity;
    }
	
    void HandleJumping(){
        if (IsGrounded())
            howManyTimesPlayerCanJump = 1;
        if (howManyTimesPlayerCanJump > 0 && Input.GetKeyDown(KeyCode.Space)) {
            rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
            howManyTimesPlayerCanJump--;
        }
    }

    bool IsGrounded() {
        return Physics.Raycast(transform.position, Vector3.down, 1.1f);
    }
}