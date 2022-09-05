using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesInventory : MonoBehaviour
{
    public GameObject inventory;
    // Start is called before the first frame update
    void Start()
    {
       // for(int i = 0)
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            inventory.SetActive(!inventory.activeSelf);
        }
    }
}
