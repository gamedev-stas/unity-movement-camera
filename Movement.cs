using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] private InputActionReference move;
    [SerializeField] private InputActionReference jump;

    public float speed = 5f;
    public float jumpForce = 10f;

    private Rigidbody rb;
    private bool isGrounded;
    Vector2 input = Vector2.zero;
    bool jumpPressed = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        move.action.Enable();
        jump.action.Enable();
    }

    private void Update()
    {
        input = move.action.ReadValue<Vector2>();

        if (jump.action.WasPressedThisFrame())
            jumpPressed = true;
    }

    private void FixedUpdate()
    {
        Vector3 direction;
        direction.x = input.x * speed;
        direction.y = rb.linearVelocity.y;
        direction.z = input.y * speed;

        rb.linearVelocity = direction;

        if (jumpPressed)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumpPressed = false;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = true;
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}