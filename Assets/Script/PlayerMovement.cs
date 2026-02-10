using UnityEngine; 
using UnityEngine.InputSystem;

//new script for input system
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }
    void FixedUpdate()
    {
        rb.linearVelocity = moveInput * moveSpeed;
    }
}