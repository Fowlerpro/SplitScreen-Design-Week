using UnityEngine;

public class S_PuzzleSlot : MonoBehaviour
{
    int[] Slots = new int[5];

    //Jo Branch, Commenting this out, error is occuring and says my c# isn't version 12 or above,
    //so feel free to merge over this if it causes a merge error!
    //int[] NumSlots = [4,4];

    // Randomize all needed pattrens
    void NewSlots()
    {
        Slots = new int[Random.Range(0, 5)];

        for (int i = 0; i < Slots.Length; i++)
        {
            Slots[i] = Random.Range(0, 5);
        }
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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


}

