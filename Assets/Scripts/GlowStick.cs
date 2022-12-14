using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowStick : MonoBehaviour
{
    public float duration = 50;
    float timer, range = 10f;
    Light lightG;
    // Start is called before the first frame update
    void Start()
    {
        lightG = GetComponentInChildren<Light>();
        timer = duration;
        GetComponent<SoundEffects>().PlaySound(0);
    }

    // Update is called once per frame
    void Update()
    {
            timer -= Time.deltaTime;
            lightG.range = range * timer / duration;
            if(timer <= 0 && gameObject.layer == 6)
            {
            TakeOff();
            
            }

    }
    public void TakeOff()
    {
        GetComponent<SoundEffects>().PlaySound(1);
        gameObject.AddComponent<BoxCollider>();
        gameObject.GetComponentInChildren<SphereCollider>().radius = lightG.intensity/100;
        gameObject.AddComponent<Rigidbody>();
        Destroy(GetComponent<Animator>());
        gameObject.layer = 8;
        transform.SetParent(null);
    }
}
