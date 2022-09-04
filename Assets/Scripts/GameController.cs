using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    int ids;
    string[] names = new string[30];
    static GameController instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
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
