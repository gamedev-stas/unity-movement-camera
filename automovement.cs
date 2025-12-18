using UnityEngine;
using UnityEngine.InputSystem;

public class AutoMovement : MonoBehaviour
{
    [SerializeField] private InputActionReference move;

    public float forwardSpeed = 5f;
    public float sideSpeed = 5f;

    private Rigidbody rb;
    private Vector2 input;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        move.action.Enable();
    }

    private void Update()
    {
        input = move.action.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        Vector3 direction = rb.linearVelocity;

        direction.z = forwardSpeed;

        direction.x = input.x * sideSpeed;

        rb.linearVelocity = direction;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}