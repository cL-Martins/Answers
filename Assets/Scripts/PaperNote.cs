using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperNote : MonoBehaviour
{
    NotesController notes;

    public string nameNote, message;
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
        GameController.RegisterNote(nameNote, message);
        notes.OpenNote(message);
        gameObject.SetActive(false);
    }
}
