using UnityEngine;

public class S_CG_Animtion : MonoBehaviour
{
    public Animator anim;

    public GameObject[] Colorables;

    public GameObject[] PColorables;
     
    public GameObject[] SColorables;

    public Color[] PColors;
    public Color[] SColors;

    public int ColorIndex = 0;

    public void SetSpeed(float Speed)
    {
        anim.SetFloat("MoveSpeed", Speed);
    }

    public void SetIsHolding(bool Holding)
    {
        anim.SetBool("IsHolding", Holding);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        ColorIndex = Random.Range(0, Colorables.Length);

        for (int i = 0; i < Colorables.Length; i++)
        {
            var Rhair = Colorables[i].GetComponent<Renderer>();
            if (Rhair != null)
            {
                Rhair.material.SetColor("_BaseColor", PColors[ColorIndex]);
                Rhair.material.SetColor("_EmissionColor", SColors[ColorIndex]);
            }
        }

        for (int i = 0; i < PColorables.Length; i++)
        {
            var Rhair = PColorables[i].GetComponent<Renderer>();
            if (Rhair != null)
            {
                Rhair.material.SetColor("_EmissionColor", PColors[ColorIndex]);
            }
        }

        for (int i = 0; i < SColorables.Length; i++)
        {
            var Rhair = SColorables[i].GetComponent<Renderer>();
            if (Rhair != null)
            {
                Rhair.material.SetColor("_EmissionColor", SColors[ColorIndex]);
            }
        }

        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //anim.SetFloat ("MoveSpeed", 1);
        //anim.SetBool ("IsHolding", true);
    }
}
