using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;



public class S_PuzzlePart : MonoBehaviour
{
    public Color[] Pattren;

    public int Score = 1000;

    public int PattrenIndex = 0;

    public void Kill()
    {
        GameObject.Destroy(gameObject);
    }

    public int GetPattrenSize()
    {
        return Pattren.Length;
    }

    public Color[] GetPattren() 
    {
        return Pattren;
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

        Renderer Rhair = GetComponent<Renderer>();

        Rhair.material.SetColor("_EmissionColor", Pattren[PattrenIndex]);
    }

    // Update is called once per frame
    void Update()
    {

    }


}