using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowStickPack : MonoBehaviour
{
    public int glowStickNumber = 20;
    public GameObject glowStick;
    GameObject tempPrefab;
    //GameObject[] gl
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2") && glowStickNumber > 0)
        {
            glowStickNumber--;
            if (tempPrefab)
            {
                tempPrefab.GetComponent<GlowStick>().TakeOff();
            }
            tempPrefab = Instantiate(glowStick, transform);
        }
    }
}
