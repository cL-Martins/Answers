using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyBoardVisor : MonoBehaviour
{
    Image image;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        image.color = new Vector4(1, 1, 1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(image.sprite == null)
        {
            image.color = new Vector4(1, 1, 1, 0);
        } else
        {
            image.color = new Vector4(1, 1, 1, 1);
        }
    }
}
