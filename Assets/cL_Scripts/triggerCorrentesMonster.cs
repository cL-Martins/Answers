using UnityEngine;

public class triggerCorrentesMonster : MonoBehaviour
{
    public AudioSource _triggerCorrentesMonster;
    public bool _controllMusic;


    private void Awake()
    {
        _controllMusic = false;
    }
       

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && _controllMusic == false)
        {
            _triggerCorrentesMonster.Play();
            _controllMusic = true;
        }
    }
}
