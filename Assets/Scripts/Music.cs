using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    AudioSource audioS;
    // Start is called before the first frame update
    void Start()
    {
        audioS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
     if(!GameController.mode.Equals(Phases.Load) && !audioS.isPlaying)
        {
            audioS.Play();
        }   
    }
}
