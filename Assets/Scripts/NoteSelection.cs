using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NoteSelection : MonoBehaviour
{
    string message;
    NotesController controller;
    TextMeshProUGUI tmP;

    private Color originalColor;
    public Color highlightedTextColor;
    public string Message { get => message; set => message = value; }

    // Start is called before the first frame update
    void Start()
    {
        controller = FindObjectOfType(typeof(NotesController)) as NotesController;
        tmP = GetComponent<TextMeshProUGUI>();
        originalColor = tmP.color;
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnDisable()
    {
        Destroy(gameObject);
    }
    public void OnMouseDown()
    {
        controller.OpenNote(message);
    }
    private void OnMouseOver()
    {
        tmP.color = Color.blue;//Precisa de ajuste
    }
    private void OnMouseExit()
    {
        tmP.color = originalColor;
    }
}
