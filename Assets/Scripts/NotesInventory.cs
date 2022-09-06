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
        for (int i = 0; i < gc.IdsNotes; i++)
        {
            notesList = new GameObject[gc.IdsNotes];
            if(i <= 12)
            {
                notesList[i] = Instantiate(notesButton, notes[0].transform);
            } else if(i <= 24)
            {
                notesList[i] = Instantiate(notesButton, notes[1].transform);
            } else if(i <= 36)
            {
                notesList[i] = Instantiate(notesButton, notes[2].transform);
            } else
            {
                notesList[i] = Instantiate(notesButton, notes[3].transform);
            }
            notesList[i].GetComponent<TextMeshProUGUI>().text = gc.NotesNames[i];
            notesList[i].GetComponent<NoteSelection>().Message = gc.NotesDescription[i];
        }
    }
}
