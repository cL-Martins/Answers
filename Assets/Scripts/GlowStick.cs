using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowStick : MonoBehaviour
{
    public float duration = 50;
    float timer, intensity = 1.5f;
    Light light;
    // Start is called before the first frame update
    void Start()
    {
        light = GetComponentInChildren<Light>();
        timer = duration;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.parent)
        {
            timer -= Time.deltaTime;
        } else
        {
            gameObject.layer = 8;
        }
            light.intensity = intensity * timer / duration;
            if(timer <= 0)
            {
            //GetComponent<Animator>().SetTrigger("New Trigger");
            //StartCoroutine("Off");
            transform.SetParent(null);
            gameObject.AddComponent<BoxCollider>();//Adicionar um limitador ainda
            gameObject.AddComponent<Rigidbody>();
            }

    }
    public IEnumerator Off()
    {
        yield return new WaitForSeconds(2);
        //glowStick.SetActive(false);
    }
}
