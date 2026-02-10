using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;



public class S_PuzzlePart : MonoBehaviour
{
    Vector3 Pattren = new Vector3();

    int PattrenIndex = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PattrenIndex = Random.Range(0, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}