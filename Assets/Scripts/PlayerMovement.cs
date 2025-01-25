using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float lookSpeed = 2f;

    private Rigidbody rb;
    private float rotationX = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked; // Locks the cursor for first-person view
    }

    void Update()
    {
        HandleMouseLook(); // Handle camera and player rotation
    }

    void FixedUpdate()
    {
        HandleMovement(); // Handle physics-based movement
    }

    void HandleMouseLook()
    {
        // Mouse look (rotates the player and the camera for first-person view)
        float mouseX = Input.GetAxis("Mouse X") * lookSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * lookSpeed;

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f); // Limit vertical look

        transform.Rotate(0, mouseX, 0); // Rotate player horizontally
        Camera.main.transform.localRotation = Quaternion.Euler(rotationX, 0, 0); // Rotate camera vertically
    }

    void HandleMovement()
    {
        // WASD Movement
        float moveX = Input.GetAxis("Horizontal"); // A/D or Left/Right
        float moveZ = Input.GetAxis("Vertical");   // W/S or Up/Down

        // Convert input to movement relative to the player's orientation
        Vector3 movement = transform.right * moveX + transform.forward * moveZ;

        // Apply movement using Rigidbody
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);//using addforce breaks this??

    }
}
