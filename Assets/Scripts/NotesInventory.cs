using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NotesInventory : MonoBehaviour
{
    public GameObject inventory, notesButton;
    public GameObject[] notes;
    GameController gc;
    NotesController notesController;
    [SerializeField]
    GameObject[] notesList;
    // Start is called before the first frame update
    void Start()
    {
        gc = FindObjectOfType(typeof(GameController)) as GameController;
        notesController = FindObjectOfType(typeof(NotesController)) as NotesController;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && !notesController.note.activeSelf)
        {
            GetComponent<SoundEffects>().PlaySound(0);
            inventory.SetActive(!inventory.activeSelf);
            if (inventory.activeSelf) 
            {
                OpenInventory();
                GameController.mode = Phases.MouseActive;
            } else 
            {
                GameController.mode = Phases.Control;
            }
        }
    }
    void OpenInventory()
    {
        for (int i = 0; i < gc.IndiceNotes; i++)
        {
            notesList = new GameObject[gc.IndiceNotes];
            if(i <= 3)
            {
                notesList[i] = Instantiate(notesButton, notes[0].transform);
                notesList[i].GetComponent<NoteSelection>().id = gc.IdsNotes[i];
            } else if(i <= 6)
            {
                notesList[i] = Instantiate(notesButton, notes[1].transform);
                notesList[i].GetComponent<NoteSelection>().id = gc.IdsNotes[i];
            } else if(i <= 9)
            {
                notesList[i] = Instantiate(notesButton, notes[2].transform);
                notesList[i].GetComponent<NoteSelection>().id = gc.IdsNotes[i];
            } else
            {
                notesList[i] = Instantiate(notesButton, notes[3].transform);
                notesList[i].GetComponent<NoteSelection>().id = gc.IdsNotes[i];
            }
        }
    }
}
