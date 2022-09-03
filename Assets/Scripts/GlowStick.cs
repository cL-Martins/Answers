using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowStick : MonoBehaviour
{
    public int glowStickNumber = 20;
    public float duration = 50;
    float timer, intensity = 1.5f;
    public GameObject glowStick;
    Light light;
    // Start is called before the first frame update
    void Start()
    {
        light = glowStick.GetComponentInChildren<Light>();
        timer = duration;
    }

    // Update is called once per frame
    void Update()
    {
        if (glowStick)
        {
            timer -= Time.deltaTime;
            light.intensity = intensity * timer / duration;
            if(timer <= 0)
            {
                glowStick.GetComponent<Animator>().SetTrigger("New Trigger");
                StartCoroutine("Off");
            }
        }
        if (Input.GetButtonDown("Fire2") && glowStickNumber > 0)
        {
            timer = duration;
            glowStick.SetActive(true);
            light.intensity = intensity;
            glowStickNumber--;
        }
    }
    public IEnumerator Off()
    {
        yield return new WaitForSeconds(2);
        glowStick.SetActive(false);
    }
}
