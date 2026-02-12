using UnityEngine;

public class S_LeverBehaviors : MonoBehaviour
{
    /* Same Code as the Button but with expanded variables to allow for multiple doors at once, also added a trigger exit when the player leaves the switch, 
    once we hook up controller buttons we can swap the input to the button 
     */


    [SerializeField] GameObject Door1;
    [SerializeField] GameObject Door2;
    [SerializeField] GameObject Door3;
    [SerializeField] GameObject Door4;
    [SerializeField] GameObject Door5;

    private bool isOpen = true;

    public void ToggleSwitch()
    {
        //swap boolean
        isOpen = !isOpen;

        Door1.SetActive(isOpen);
        Door2.SetActive(isOpen);
        Door3.SetActive(isOpen);
        Door4.SetActive(isOpen);
        Door5.SetActive(isOpen);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Lever Switched");
        //there's a million ways to ensure the object is the player, Dont use this one i'll edit the button with you all tomorrow
        if (other.gameObject.CompareTag("Player"))
        {
            ToggleSwitch();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Lever Deactivated");
        //whent he player leaves the trigger it turns it off, hopefully
        if (other.gameObject.CompareTag("Player"))
        {
            ToggleSwitch();
        }
    }

}
