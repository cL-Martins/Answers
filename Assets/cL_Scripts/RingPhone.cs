using System.Collections;
using UnityEngine;

public class RingPhone : MonoBehaviour
{
    public AudioSource _RingPhone;
    public bool _controllMusic;
        
    private void Awake()
    {
        _controllMusic = false;

    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Player") && _controllMusic == false)
        {
            _RingPhone.Play();
            _controllMusic = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && _controllMusic == true)
        {
            StartCoroutine(RingPhoneTimer());
        }
    }

    IEnumerator RingPhoneTimer()
    {
        yield return new WaitForSeconds(6);
        _RingPhone.Stop();
    }

}
