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
        if (transform.parent)
        {
            timer -= Time.deltaTime;
        } else
        {
            if(gameObject.layer == 6)
            {
                gameObject.AddComponent<BoxCollider>();//Adicionar um limitador ainda
                gameObject.AddComponent<Rigidbody>();
            }
            gameObject.layer = 8;
        }
            lightG.intensity = intensity * timer / duration;
            if(timer <= 0)
            {
            //GetComponent<Animator>().SetTrigger("New Trigger");
            //StartCoroutine("Off");
            transform.SetParent(null);
            
            }

    }
    public IEnumerator Off()
    {
        yield return new WaitForSeconds(2);
        //glowStick.SetActive(false);
    }
}
