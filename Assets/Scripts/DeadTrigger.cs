using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(SoundEffects))]
public class DeadTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            transform.position = other.transform.position;
            GetComponent<Animator>().SetTrigger("activate");
            GameController.mode = Phases.Die;
        }
        
    }
    public void Particles()
    {
        GetComponentInChildren<ParticleSystem>().Play();
    }
    public void JumpScare()
    {
        GetComponent<SoundEffects>().PlaySound(0);
    }
    public void Death()
    {
        SceneManager.LoadScene("GameOver");
    }
}
