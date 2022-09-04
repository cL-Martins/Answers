using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider))]
public class Key : MonoBehaviour
{
    public string doorName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Interaction()
    {
        GameController.CollectKey(doorName);
        gameObject.SetActive(false);
    }
}
