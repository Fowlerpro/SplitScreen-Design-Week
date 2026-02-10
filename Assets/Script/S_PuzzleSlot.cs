using System.Globalization;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class S_PuzzleSlot : MonoBehaviour
{

    int[] Slots = new int[5];

    int[] NumSlots = { 1, 1, 2, 2, 3, 4 };

    // Randomize all needed pattrens
    void NewSlots()
    {
        Slots = new int[NumSlots[Random.Range(0, NumSlots.Length)]];

        for (int i = 0; i < Slots.Length; i++)
        {
            Slots[i] = Random.Range(0, 5);
        }
    }

    bool SlotPart(GameObject Part, int SlotIndex)
    {
        if (Part == null) return false;

        if (Part.GetComponent<S_PuzzlePart>().PattrenIndex == 0)//SlotIndex
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision == null) return;
        else
        {
            SlotPart(collision.gameObject, 0);
            
        }
    }
}

