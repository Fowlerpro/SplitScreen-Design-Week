using System.Globalization;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.LowLevelPhysics;

public class S_PuzzleSlot : MonoBehaviour
{

    int[] Slots = new int[5];

    int[] NumSlots = { 1, 1, 2, 2, 3, 4 };

    S_PuzzlePart GG;


    Vector3[] SlotLocations = new Vector3[5];

    // Randomizes all pattrens and array sizes
    void NewSlots()
    {
        Slots = new int[NumSlots[Random.Range(0, NumSlots.Length)]];

        SlotLocations = new Vector3[Slots.Length];

        for (int i = 0; i < Slots.Length; i++)
        {
            Slots[i] = Random.Range(0, GG.GetPattrenSize());
            if (i == 0)
                SlotLocations[0] = transform.position + transform.right * 20;
            else
                SlotLocations[i] = SlotLocations[i - 1] + transform.right * 20;
            //Instantiate(, gameObject.transform.localPosition, Quaternion.identity);
        }
    }

    // Takes a GameObject 
    bool SlotPart(GameObject Part, int SlotIndex)
    {
        if (Part.GetComponent<S_PuzzlePart>() == null) return false;

        if (Part.GetComponent<S_PuzzlePart>().PattrenIndex == SlotIndex)//SlotIndex
        {
            Part.transform.position = transform.position;
            return true;
        }
        else
            return false;
    }

    // Collision Test
    private void OnCollisionEnter(Collision collision)
    {
        if (collision == null) return;
        else
        {

            if (!SlotPart(collision.gameObject, Slots[0]))
            {
                collision.gameObject.transform.position = transform.position + transform.up * 5;
                collision.gameObject.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;

                collision.gameObject.GetComponent<S_PuzzlePart>().RandomPattrenIndex();
            }
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        NewSlots();
    }

    // Update is called once per frame
    void Update()
    {

    }


}

