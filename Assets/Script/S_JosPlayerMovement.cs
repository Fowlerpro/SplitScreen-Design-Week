using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

//new script for input system
public class JosPlayerMovement : MonoBehaviour
{
    // Current Move Speed
    float moveSpeed = 5f;
    // Max Move Speed
    public float MaxSpeed = 5f;
    // Target Move Speed
    float TargetSpeed = 0f;

    quaternion OldRot;
    quaternion TargetRot;

    // interpolate Speeds/Times
    float lerpTime = 0f;
    float lerpRotTime = 0f;

    float lerpSpeed = 5f;

    public S_CG_Animtion animP;

    private Rigidbody rb;
    private Vector2 moveInput;
    private InputAction moveAction, interactAction, interactAction2;
    bool isHolding;
    [SerializeField]
    ItemHolderBehaviors itemHolderRef;

    void Awake()
    {
        //replacing rigidbody2D for a 3D rigidbody
        rb = GetComponent<Rigidbody>();

        animP = GetComponentInChildren<S_CG_Animtion>();

        //assigning InputAction variable within this script so we can read whenever it's triggered in Update
        moveAction = InputSystem.actions.FindAction("Move");
        interactAction = InputSystem.actions.FindAction("Interact");
        interactAction2 = InputSystem.actions.FindAction("Jump");
    }
    private void Update()
    {

        //returns true if there is a movement action!


        if (interactAction.WasPressedThisFrame() || interactAction2.WasPressedThisFrame())
        {
            if (isHolding)
            {
                itemHolderRef.Drop();
                isHolding = !isHolding;
            }
            else
            {
                isHolding = itemHolderRef.TryPickupItem();
            }

        }

        // Smoolths out the move speed
        if (moveSpeed != TargetSpeed)
        {
            if (moveSpeed < TargetSpeed)
            {
                moveSpeed = math.lerp(0, TargetSpeed, lerpTime);
                lerpTime += lerpSpeed * Time.deltaTime;

            }
            if (moveSpeed > TargetSpeed)
            {
                moveSpeed = math.lerp(MaxSpeed, TargetSpeed, lerpTime);
                lerpTime += lerpSpeed * Time.deltaTime;

            }
        }
        else lerpTime = 0f;


        if (transform.rotation != TargetRot)
        {
            quaternion gg = Quaternion.Lerp(OldRot, TargetRot, lerpRotTime);

            transform.rotation = gg;

            lerpRotTime += 10 * Time.deltaTime;

            //Debug.Log(lerpRotTime);

            if (lerpRotTime >= 1)
            {
                OldRot = TargetRot;
                transform.rotation = TargetRot;
            }

        }
        else
        {
            lerpRotTime = 0f;
        }

        animP.SetSpeed(moveSpeed / MaxSpeed);
        animP.SetIsHolding(isHolding);
        Debug.Log(moveSpeed);
    }
    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        TargetSpeed = MaxSpeed;// Sets new Target Speed


        //Rotates player only when theyre moving
        float angle = Mathf.Atan2(moveInput.x, moveInput.y) * Mathf.Rad2Deg;

        if (TargetRot != Quaternion.Euler(0, angle, 0))
        OldRot = TargetRot;
        
        TargetRot = Quaternion.Euler(0, angle, 0);
        Debug.Log("ran Movement");
    }

        //private void DropItem()
        //{
        //    heldObjRB.useGravity = true;
        //    objectHolderSlot.DetachChildren();
        //}

        //private bool PickupItem()
        //{
        //    bool objectInRange = Physics.SphereCast(transform.position, pickupRange, transform.forward, out RaycastHit hitInfo, LayerMask.NameToLayer("Interactables"));
        //    if (objectInRange)
        //    {

        //        if (hitInfo.rigidbody.gameObject.CompareTag("Interactable"))
        //        {
        //            Debug.Log("Hit object, Interactable!");
        //            heldObjRB = hitInfo.rigidbody;
        //            heldObjRB.useGravity = false;
        //            hitInfo.rigidbody.transform.SetParent(objectHolderSlot);
        //            return true;
        //        }
        //        else
        //        {
        //            Debug.Log("Hit object, non interactable");
        //        }
        //    }
        //    //else
        //    return false;
        //}

        void FixedUpdate()
{

    //setting linear velocity is a good way to ensure physics applies, but a more complicated rb.AddForce can really take movement to the next level
    rb.linearVelocity = new Vector3(moveInput.x * moveSpeed, 0, moveInput.y * moveSpeed);

}

}