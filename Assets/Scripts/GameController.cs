using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Phases
{
    Control, DontControl, MouseActive, Load
}
public class GameController : MonoBehaviour
{

    int ids; //Id da ultima chave
    string[] names = new string[30]; //Lista de Chaves
    string[] notesDescription = new string[50];
    string[] notesNames = new string[50];
    int idsNotes;
    NotesInventory notesInventory;
    static GameController instance;
    public static Phases mode;

    public int IdsNotes { get => idsNotes; set => idsNotes = value; }
    public string[] NotesNames { get => notesNames; set => notesNames = value; }
    public string[] NotesDescription { get => notesDescription; set => notesDescription = value; }

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        mode = Phases.Load;
        notesInventory = FindObjectOfType(typeof(NotesInventory)) as NotesInventory;
    }

    // Update is called once per frame
    void Update()
    {
        switch (mode)
        {
            case Phases.Control:
                
                if (notesInventory.inventory.activeSelf)
                {
                    mode = Phases.MouseActive;
                } else
                {
                    Cursor.visible = false;
                    Cursor.lockState = CursorLockMode.Locked;
                }
                break;
            case Phases.DontControl:
                break;
            case Phases.MouseActive:
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                break;
            case Phases.Load:
                if (Input.GetButtonDown("Jump"))
                {
                    mode = Phases.Control;
                }
                break;
        }
    }
    public static void RegisterNote(string name, string description)
    {
        instance.notesNames[instance.idsNotes] = name;
        instance.notesDescription[instance.idsNotes] = description;
        instance.idsNotes++;
    }
    public static void CollectKey(string doorName)
    {
        instance.names[instance.ids] = doorName;
        instance.ids++;
    }
    public static bool CheckKey(string name)
    {
        bool haveKey = false;
        for(int i = 0; i < instance.names.Length; i++)
        {
            haveKey = name.Equals(instance.names[i]);
            if (haveKey)
                break;
        }
        return haveKey;
    }
    public void SetMode(int phase)
    {
        switch (phase)
        {
            case 1:
                mode = Phases.DontControl;
                break;
            case 0:
                mode = Phases.Control;
                break;
            case 2:
                mode = Phases.MouseActive;
                break;
        }
        
    }
}
