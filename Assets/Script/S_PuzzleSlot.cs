using UnityEngine;

public class S_PuzzleSlot : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    bool SlotPart(GameObject Part) 
    {
        if (Part != null) 
        {
            Part.transform.position = transform.position;
            return true;
        }
                
        return false;
    }
}

