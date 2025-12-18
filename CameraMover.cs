using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private Vector3 offset = new Vector3(0f, 15f, -3f);
    [SerializeField] private float speed = 10f;
    private Movement movement;

    private void Start()
    {
        movement = FindFirstObjectByType<Movement>();
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, movement.transform.position + offset) >= 0.1f)
            transform.position = Vector3.Lerp(transform.position, movement.transform.position + offset, speed * Time.deltaTime);
    }
}