using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Phases
{
    Control, DontControl, MouseActive, Die, Narrative
}
public class GameController : MonoBehaviour
{

    int ids; //Id da ultima chave
    string[] names = new string[30]; //Lista de Chaves
    int[] idsNotes = new int[8]; 
    int indiceNotes = 0;
    NotesInventory notesInventory;
    AudioSource audioS;
    static GameController instance;
    public static Phases mode;


    public int[] IdsNotes { get => idsNotes; set => idsNotes = value; }
    public int IndiceNotes { get => indiceNotes; set => indiceNotes = value; }

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        mode = Phases.Control;
        notesInventory = FindObjectOfType(typeof(NotesInventory)) as NotesInventory;
        audioS = GameObject.Find("Narrative").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        print(mode);
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
            case Phases.Narrative:
                if (!audioS.isPlaying)
                {
                    mode = Phases.Control;
                }
                break;
        }
    }
    public static void RegisterNote(int id)
    {
        instance.IdsNotes[instance.IndiceNotes] = id;
        instance.IndiceNotes++;
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
