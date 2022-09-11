using UnityEngine;

public class radioHimmler : MonoBehaviour
{
    public AudioSource _radioHimmler;
    public bool _controllMusic;

    private void Awake()
    {
        _controllMusic = false;
    }

    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && _controllMusic == false)
        {
            _radioHimmler.Play();
            _controllMusic = true;

        }
    }
}
