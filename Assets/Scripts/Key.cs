using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider))]
public class Key : MonoBehaviour
{
    [Tooltip("Colocar o mesmo nome que está no script da porta")]
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
        SoundEffects.PlaySound(SoundsList.CollectKey);
        GameController.CollectKey(doorName);
        gameObject.SetActive(false);
    }
}
