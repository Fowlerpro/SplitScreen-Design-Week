using System.Globalization;
using Unity.Multiplayer.Center.Common;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.LowLevelPhysics;

public class S_PuzzleSlot_Manager : MonoBehaviour
{

    int[] NumSlots = new int[5];

    int[] MaxNumSlots = { 1, 1, 2, 2, 3, 4 };

    public bool HasPart = false;

    GameObject CurPart;

    public GameObject GG;

    public int Index;

    public GameObject prefab;


    private GameObject[] Slots;

    // Randomizes all pattrens and array sizes
    void NewSlots()
    {

        if (Slots != null)
        {
            for (int i = 0; i < Slots.Length; i++)
            {
                if (Slots[i].GetComponent<S_PuzzlePart>() != null)//SlotIndex
                {
                    Slots[i].GetComponent<S_SoloPuzzleSlot>().Kill();
                }

            }
        }


        NumSlots = new int[MaxNumSlots[Random.Range(0, MaxNumSlots.Length)]];
        Slots = new GameObject[NumSlots.Length];

        for (int i = 0; i < NumSlots.Length; i++)
        {
            NumSlots[i] = Random.Range(0, 5);

            if (i == 0)
            {
                Slots[i] = Instantiate(prefab, transform.localPosition, transform.rotation);
            }
            else
            {
                int L = i - 1;
                if (L < 0)
                    L = 0;

                Slots[i] = Instantiate(prefab, Slots[L].transform.localPosition + Slots[L].transform.right * 50, transform.rotation);

            }


        }

    }

    // Takes a GameObject and checks if it has S_PizzlePart Script if so then does it have the right index
    bool SlotPart(GameObject Part, int SlotIndex)
    {
        if (Part.GetComponent<S_PuzzlePart>() == null) return false;

        if (Part.GetComponent<S_PuzzlePart>().PattrenIndex == SlotIndex)//SlotIndex
        {
            Part.transform.position = transform.position;

            Part.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;

            Part.GetComponent<Rigidbody>().Describe();
            

            CurPart = Part;
            HasPart = true;
            return true;
        }
        else
        {
            CurPart = null;
            HasPart = false;
            return false;

        }
    }

    // Collision Test
    private void OnCollisionEnter(Collision collision)
    {
        if (collision == null) return;
        else
        {
            bool can = SlotPart(collision.gameObject, Index);

            if (can == false)//NumSlots[0]
            {
                collision.gameObject.transform.position = transform.position + transform.up * 5;

                collision.gameObject.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;

                //NewSlots();
            }
            else
            {

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

