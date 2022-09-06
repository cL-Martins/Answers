using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NotesInventory : MonoBehaviour
{
    public GameObject inventory, notes, notesButton;
    GameController gc;
    [SerializeField]
    GameObject[] notesList;
    // Start is called before the first frame update
    void Start()
    {
        gc = FindObjectOfType(typeof(GameController)) as GameController;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
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
            notesList[i] = Instantiate(notesButton, notes.transform);
            notesList[i].GetComponent<TextMeshProUGUI>().text = gc.NotesNames[i];
            notesList[i].GetComponent<NoteSelection>().Message = gc.NotesDescription[i];
        }
    }
}
