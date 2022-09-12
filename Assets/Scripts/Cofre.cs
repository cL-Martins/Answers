using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Outline))]
[RequireComponent(typeof(SoundEffects))]
public class Cofre : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Interaction()
    {
        gameObject.GetComponentInParent<Animator>().SetTrigger("cofre");
    }
}
