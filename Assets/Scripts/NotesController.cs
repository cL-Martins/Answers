using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class NotesController : MonoBehaviour
{
    TextMeshProUGUI tmP;
    public GameObject note;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && note.activeSelf)
        {
            note.SetActive(false);
            GameController.mode = Phases.Control;
        }
    }
    public void OpenNote(string txt)
    {
        GameController.mode = Phases.DontControl;
        note.SetActive(true);
        if(tmP == null)
        {
            tmP = GetComponentInChildren<TextMeshProUGUI>();
        }
        tmP.text = txt;
    }
}
