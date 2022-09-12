using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Outline))]
[RequireComponent(typeof(SoundEffects))]
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
        GetComponent<SoundEffects>().PlaySound(0);
        anim.SetBool("open", !anim.GetBool("open"));
        gameObject.tag = "Default";
    }
}
