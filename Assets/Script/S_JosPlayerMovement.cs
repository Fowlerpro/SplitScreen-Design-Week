using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

//new script for input system
public class JosPlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody rb;
    private Vector2 moveInput;
    private InputAction moveAction;
    void Awake()
    {
        //replacing rigidbody2D for a 3D rigidbody
        rb = GetComponent<Rigidbody>();

        //assigning InputAction variable within this script so we can read whenever it's triggered in Update
        moveAction = InputSystem.actions.FindAction("Move");
    }
    private void Update()
    {
        //returns true if there is a movement action!
        if (moveAction.IsInProgress())
        {
            moveInput = moveAction.ReadValue<Vector2>();

            //Rotates player only when theyre moving
            float angle = Mathf.Atan2(moveInput.x, moveInput.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, angle, 0);
        }
        //else, stop!
        else moveInput = new Vector2(0, 0);
    }

    // I'm not familiar with this method of getting a movement value from the input system! I commented it out for my mockup
    //void OnMove(InputValue value)
    //{
    //    moveInput = value.Get<Vector2>();
    //}
    void FixedUpdate()
    {
        //setting linear velocity is a good way to ensure physics applies, but a more complicated rb.AddForce can really take movement to the next level
        rb.linearVelocity = new Vector3(moveInput.x * moveSpeed, 0, moveInput.y * moveSpeed);
    }
}