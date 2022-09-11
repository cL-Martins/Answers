using UnityEngine;

public class gravofoneMusic : MonoBehaviour
{
    public AudioSource _gravophoneMusic;
    public bool _controllMusic;

    private void Awake()
    {
        _controllMusic = false;
}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && _controllMusic == true)
        {
            _gravophoneMusic.UnPause();
        }
        else if (other.gameObject.CompareTag("Player") && _controllMusic==false)
        {
            _gravophoneMusic.Play();
            _controllMusic = true;
        }       
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && _controllMusic == true)
        {
            _gravophoneMusic.Pause();
        }
    }
}
 