using UnityEngine;

public class S_ButtonBehaviors : MonoBehaviour
{
    /* Hey! Jo here. These buttons are made so you can call a function, ToggleButton() that activates a light as an attached child object.
     * 
     * 
     * Here's the descriptions for all the functions and how to use em!
     * ToggleButton() is a public function that you can call from your player script, or from a manager
     */

    [SerializeField]
    GameObject connectedLight;

    private bool isOn;

    public void ToggleButton()
    {
        //swap boolean
        isOn = !isOn;

        connectedLight.SetActive(isOn);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("button triggered");
        //there's a million ways to ensure the object is the player, Dont use this one i'll edit the button with you all tomorrow
        if (other.gameObject == GameObject.Find("Player mockup"))
        {
            ToggleButton();
        }
    }

}
