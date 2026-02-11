using UnityEngine;

public class DisplayChanges : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (Display.displays.Length > 1)
        {
            // Activate display 2 (zero-indexed).
            Display.displays[1].Activate();
        }
    }
}
