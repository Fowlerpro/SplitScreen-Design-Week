using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody rb;
    private Vector2 moveInput;

    void Start()
    {

        rb = GetComponent<Rigidbody>();
    }
    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();

    }
    void FixedUpdate()
    {
        Vector3 move = new Vector3(moveInput.x, 0f, moveInput.y);
        rb.linearVelocity = move * moveSpeed;
    }
}
