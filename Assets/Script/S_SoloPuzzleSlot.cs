using UnityEngine;


public class S_SoloPuzzleSlot : S_PuzzleSlot_Manager
{

    public void Kill() 
    {
        GameObject.Destroy(gameObject);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Index = Random.Range(0, GG.GetComponent<S_PuzzlePart>().GetPattrenSize());

        Color[] Pattren = GG.GetComponent<S_PuzzlePart>().GetPattren();


        Renderer Rhair = GetComponent<Renderer>();

        Rhair.material.SetColor("_EmissionColor", Pattren[Index]);


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
