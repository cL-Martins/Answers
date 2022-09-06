using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class NotesController : MonoBehaviour
{
    TextMeshProUGUI tmP;
    public GameObject note;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (note.activeSelf)
        {
            timer += Time.deltaTime;
        } else
        {
            timer = 0;
        }
        if (Input.GetButtonDown("Fire1") && note.activeSelf && timer > 0.1f)
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
