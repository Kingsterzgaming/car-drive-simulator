using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 6f;
    public float jumpForce = 8f;
    public float gravity = -90.81f;
    public float velocityy = -2f;

    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        HandleMovement();
        HandleActions();
    }

    void HandleMovement()
    {
        // Check if grounded
        isGrounded = controller.isGrounded;

        if (isGrounded && velocity.y < 0)
            velocity.y = velocityy;

        // Get input
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Convert movement to world space
        Vector3 move = transform.right * x + transform.forward * z;

        // Move player
        controller.Move(move * moveSpeed * Time.deltaTime);

        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = jumpForce;
            Debug.Log("Jump!");
        }

        // Apply gravity
        velocity.y += gravity * Time.deltaTime;

        // Apply falling movement
        controller.Move(velocity * Time.deltaTime);
    }

    void HandleActions()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("Pressed E: Interact");

        }

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Left Mouse Click: Attack");
        }

        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Right Mouse Click: Secondary Action");
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Debug.Log("Shift Pressed: Sprinting!");
        }
    }
}
