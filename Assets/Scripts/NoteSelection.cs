using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSelection : MonoBehaviour
{
    string message;
    NotesController controller;
    public string Message { get => message; set => message = value; }

    // Start is called before the first frame update
    void Start()
    {
        controller = FindObjectOfType(typeof(NotesController)) as NotesController;
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void OnMouseDown()
    {
        controller.OpenNote(message);
    }
}
