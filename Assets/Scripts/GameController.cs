using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Phases
{
    Control, DontControl
}
public class GameController : MonoBehaviour
{

    int ids; //Id da ultima chave
    string[] names = new string[30]; //Lista de Chaves
    string[] notesDescription = new string[50];
    string[] notesNames = new string[50];
    int idsNotes;
    static GameController instance;
    public static Phases mode;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        mode = Phases.Control;
    }

    // Update is called once per frame
    void Update()
    {
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
}
