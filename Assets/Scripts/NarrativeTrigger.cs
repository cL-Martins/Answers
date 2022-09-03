using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class NarrativeTrigger : MonoBehaviour
{
    AudioSource audioS;
    public AudioClip sound;
    // Start is called before the first frame update
    void Start()
    {
        audioS = GameObject.Find("Narrative").GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            audioS.PlayOneShot(sound);
            gameObject.SetActive(false);
        }
    }
}
