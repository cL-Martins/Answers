using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Outline))]
[RequireComponent(typeof(SoundEffects))]
[RequireComponent(typeof(BoxCollider))]
public class PaperNote : MonoBehaviour
{
    NotesController notes;
    public int id;
    // Start is called before the first frame update
    void Start()
    {
        notes = FindObjectOfType(typeof(NotesController)) as NotesController;
    }

    // Update is called once per frame
    void Update()
    {
    }
    void Interaction()
    {
        GetComponent<SoundEffects>().PlaySound(0);
        GameController.RegisterNote(id);
        notes.OpenNote(id);
        gameObject.SetActive(false);
    }
}
