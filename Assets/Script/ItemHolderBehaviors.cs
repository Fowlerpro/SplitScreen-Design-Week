using UnityEngine;

public class ItemHolderBehaviors : MonoBehaviour
{
    [SerializeField]
    float pickupRange;

    GameObject heldObject;
    public bool TryPickupItem()
    {
        GameObject[] AllPickupItems = GameObject.FindGameObjectsWithTag("Interactable");

        GameObject closestObject = null;
        foreach (GameObject item in AllPickupItems)
        {
            float distanceToCurrent = (transform.position - item.transform.position).magnitude;
            if (distanceToCurrent <= pickupRange)
            {
                if (closestObject != null)
                {
                    if (distanceToCurrent < (transform.position - closestObject.transform.position).magnitude)
                    {
                        closestObject = item;
                    }
                }
                else
                {
                    closestObject = item;
                }
            }
        }
        if (closestObject != null)
        {
            closestObject.transform.position = transform.position;
            closestObject.transform.SetParent(transform);
            closestObject.GetComponent<Rigidbody>().useGravity = false;
            heldObject = closestObject;
            return true;
        }

        return false;
    }
    public void Drop()
    {
        transform.DetachChildren();
        heldObject.GetComponent<Rigidbody>().useGravity = true ;
        heldObject = null;
    }
    private void Update()
    {
        if (heldObject != null)
        {
            heldObject.transform.position = transform.position;
            heldObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, pickupRange);
    }
}
