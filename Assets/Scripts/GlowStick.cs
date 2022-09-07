using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowStick : MonoBehaviour
{
    public float duration = 50;
    float timer, intensity = 1.5f;
    Light lightG;
    // Start is called before the first frame update
    void Start()
    {
        lightG = GetComponentInChildren<Light>();
        timer = duration;
    }

    // Update is called once per frame
    void Update()
    {
        print(lightG.intensity);
            timer -= Time.deltaTime;
            lightG.intensity = intensity * timer / duration;
            if(timer <= 0 && gameObject.layer == 6)
            {
            //GetComponent<Animator>().SetTrigger("New Trigger");
            //StartCoroutine("Off");
            TakeOff();
            
            }

    }
    public void TakeOff()
    {
        gameObject.AddComponent<BoxCollider>();//Adicionar um limitador ainda
        gameObject.AddComponent<Rigidbody>();
        Destroy(GetComponent<Animator>());
        gameObject.layer = 8;
        transform.SetParent(null);
    }
}
