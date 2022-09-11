using UnityEngine;

public class ShowerWaterTrigger : MonoBehaviour
{
    public AudioSource ShowerWaterTriggergravophoneMusic;
    public bool _controllMusic;

    private void Awake()
    {
        _controllMusic = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && _controllMusic == true)
        {
            ShowerWaterTriggergravophoneMusic.UnPause();
        }
        else if (other.gameObject.CompareTag("Player") && _controllMusic == false)
        {
            ShowerWaterTriggergravophoneMusic.Play();
            _controllMusic = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && _controllMusic == true)
        {
            ShowerWaterTriggergravophoneMusic.Pause();
        }
    }
}
