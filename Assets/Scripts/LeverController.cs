using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverController : MonoBehaviour
{
    int battery, door, alarm, gas;

    public int Alarm { get => alarm; set => alarm = value; }
    public int Gas { get => gas; set => gas = value; }
    public int Battery { get => battery; set => battery = value; }
    public int Door { get => door; set => door = value; }
    AudioSource alarmAudio;
    //ParticleSystem gasParticle;
    public GameObject gasParticle;
    public Monster boss;
    public Animator glassDoor;

    // Start is called before the first frame update
    void Start()
    {
        alarmAudio = GetComponent<AudioSource>();
        battery = 0;
        door = 0;
        alarm = 0;
        gas = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(alarm == 1)
        {
            if (!alarmAudio.isPlaying)
            {
                boss.Ia = States.FullChase;
                alarmAudio.Play();
            }
        }
        if(gas == 1)
        {
            if (!gasParticle.activeSelf)
            {
                gasParticle.SetActive(true);
            }
        }
        if(battery == 2)
        {
            
            if (door == 2)
            {
                glassDoor.SetTrigger("open");
            }
        }
    }
}
