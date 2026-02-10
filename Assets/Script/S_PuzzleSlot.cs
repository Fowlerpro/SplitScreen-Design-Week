using System.Globalization;
using UnityEditor;
using UnityEngine;

public class S_PuzzleSlot : MonoBehaviour
{
    S_PuzzlePart jj;

    int[] Slots = new int[5];

    int[] NumSlots = {1,1,2,2,3,4};

    // Randomize all needed pattrens
    void NewSlots()
    {
        Slots = new int[NumSlots[Random.Range(0,NumSlots.Length)]];

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

