using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class NarrativeTrigger : MonoBehaviour
{
    AudioSource audioS;
    public AudioClip sound;
    public bool lockPlayer;
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
            if (lockPlayer)
            {
                GameController.mode = Phases.Narrative;
            }
            gameObject.SetActive(false);
        }
    }
}
