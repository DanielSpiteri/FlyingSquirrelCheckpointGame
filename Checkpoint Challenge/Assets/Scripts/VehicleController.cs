using UnityEngine;
using UnityEngine.InputSystem;

public class VehicleController : MonoBehaviour
{
    [Header("Vehicle Settings")]
    [SerializeField] private float moveSpeed = 8f;
    [SerializeField] private float turnSpeed = 120f;

    [Header("Input")]
    [SerializeField] private InputActionReference moveAction;

    private Rigidbody rb;

    private float moveInput;
    private float turnInput;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        moveAction.action.Enable();
    }

    private void OnDisable()
    {
        moveAction.action.Disable();
    }

    private void Update()
    {
        Vector2 input = moveAction.action.ReadValue<Vector2>();

        turnInput = input.x;
        moveInput = input.y;
    }

    private void FixedUpdate()
    {
        Move();
        Turn();
    }

    private void Move()
    {
        Vector3 movement =
            transform.forward * moveInput * moveSpeed;

        rb.MovePosition(
            rb.position + movement * Time.fixedDeltaTime
        );
    }

    private void Turn()
    {
        if (Mathf.Abs(moveInput) < 0.01f)
            return;

        float turnAmount =
            turnInput * turnSpeed * Time.fixedDeltaTime;

        Quaternion turnRotation =
            Quaternion.Euler(0f, turnAmount, 0f);

        rb.MoveRotation(
            rb.rotation * turnRotation
        );
    }

    private void OnValidate()
    {
        moveSpeed = Mathf.Max(0f, moveSpeed);
        turnSpeed = Mathf.Max(0f, turnSpeed);
    }
}