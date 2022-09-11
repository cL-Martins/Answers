using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteSelection : MonoBehaviour
{
    NotesController controller;
    Image image;
    public int id;

    // Start is called before the first frame update
    void Start()
    {
        controller = FindObjectOfType(typeof(NotesController)) as NotesController;
        image = GetComponent<Image>();
        image.sprite = controller.books[id];
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnDisable()
    {
        Destroy(gameObject);
    }
    public void Active()
    {
        controller.OpenNote(id);
    }
}
