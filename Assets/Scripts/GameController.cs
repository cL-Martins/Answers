using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Phases
{
    Control, DontControl
}
public class GameController : MonoBehaviour
{
    int ids;
    string[] names = new string[30];
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
