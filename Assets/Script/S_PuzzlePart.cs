using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;



public class S_PuzzlePart : MonoBehaviour
{
    Vector3[] Pattren = new Vector3[5];

    public int PattrenIndex = 0;

    public int GetPattrenSize()
    {
        return Pattren.Length;
    }

    public int RandomPattrenIndex()
    {
        PattrenIndex = Random.Range(0, Pattren.Length);
        return PattrenIndex;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RandomPattrenIndex();
    }

    // Update is called once per frame
    void Update()
    {

    }


}