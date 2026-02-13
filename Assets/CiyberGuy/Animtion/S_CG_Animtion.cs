using UnityEngine;

public class S_CG_Animtion : MonoBehaviour
{
    public Animator anim;

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
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //anim.SetFloat ("MoveSpeed", 1);
        //anim.SetBool ("IsHolding", true);
    }
}
