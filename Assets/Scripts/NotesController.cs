using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class NotesController : MonoBehaviour
{
    TextMeshProUGUI tmP;
    public GameObject note;
    public Sprite[] notes, books;
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
    public void OpenNote(int choice)
    {
        GameController.mode = Phases.DontControl;
        note.SetActive(true);
        note.GetComponent<Image>().sprite = notes[choice];
    }
}
