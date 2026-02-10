using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;



public class S_PuzzlePart : MonoBehaviour
{
    List Pattren = new List();

    int PattrenIndex = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (Display.displays.Length > 1)
        {
            // Activate display 2 (zero-indexed).
            Display.displays[1].Activate();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}