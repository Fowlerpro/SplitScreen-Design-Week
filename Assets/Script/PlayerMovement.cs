using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;
    [Header("Player Settings")]
    [Tooltip("Set this to 1 for Player 1, 2 for Player 2, etc.")]
    public int playerIndex = 1;

    private Rigidbody2D rb;
    private Vector2 movementInput;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        ReadInput();
    }
    void FixedUpdate()
    {
        Move();
    }
    void ReadInput()
    {
        float horizontal = 0f;
        float vertical = 0f;

        //controller input
        horizontal += Input.GetAxisRaw("Horizontal_P" + playerIndex);
        vertical += Input.GetAxisRaw("Vertical_P" + playerIndex);

        //keyboard
        if (playerIndex == 1)
        {
            horizontal += Input.GetAxisRaw("Horizontal");
            vertical += Input.GetAxisRaw("Vertical");

        }
        else if (playerIndex == 2)
        {
            horizontal += Input.GetAxisRaw("Horizontal_Arrows");
            vertical += Input.GetAxisRaw("Vertical_Arrows");
        }
        movementInput = new Vector2(horizontal, vertical).normalized;

    }
    void Move()
    {
        rb.linearVelocity = movementInput * moveSpeed;
    }
}