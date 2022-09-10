using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class SoundEffects : MonoBehaviour
{
    public AudioClip[] sounds;//Lista de sons
    AudioSource audioS;
    // Start is called before the first frame update
    void Awake()
    {
        audioS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlaySound(int soundEffectId)
    {
        audioS.PlayOneShot(sounds[soundEffectId]);
    }
}

