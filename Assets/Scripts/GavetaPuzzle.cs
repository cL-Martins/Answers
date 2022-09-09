using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GavetaPuzzle : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInParent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Interaction()
    {
        anim.SetBool("open", !anim.GetBool("open"));
    }
}
