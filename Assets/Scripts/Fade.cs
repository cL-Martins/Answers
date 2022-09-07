using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    public bool activeDestruction;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (activeDestruction)
        {
            Destroy(gameObject);
        }
    }
    public void FadeIn()
    {
        anim.SetTrigger("fade");
    }
}
