using UnityEngine;

public class monument : MonoBehaviour
{
    public AudioSource _monument;
    public bool _controllMusic;


    private void Awake()
    {
        _controllMusic = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && _controllMusic == true)
        {
            _monument.UnPause();
        }
        else if (other.gameObject.CompareTag("Player") && _controllMusic == false)
        {
            _monument.Play();
            _controllMusic = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && _controllMusic == true)
        {
            _monument.Pause();
        }
    }
}
