using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KeyBoardPuzzle : MonoBehaviour
{
    public GameObject keyBoardInterface, door;
    public string password;
    TextMeshProUGUI visor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            GetComponent<SoundEffects>().PlaySound(0);
            Finish();   
        }
    }
    void Interaction()
    {
        GetComponent<SoundEffects>().PlaySound(1);
        keyBoardInterface.SetActive(true);
        GameController.mode = Phases.MouseActive;
        visor = GetComponentInChildren<TextMeshProUGUI>();
        visor.text = "";
    }
    public void PressButton(string value)
    {
        visor.text += value;
        GetComponent<SoundEffects>().PlaySound(2);
    }
    public void EnterPassword()
    {
        if (visor.text.Equals(password))
        {
            GetComponent<SoundEffects>().PlaySound(3);
            Finish();
        } else
        {
            GetComponent<SoundEffects>().PlaySound(4);
            visor.text = "";
        }
    }
    void Finish()
    {
        door.SendMessage("OpenKeyBoard", SendMessageOptions.DontRequireReceiver);
        GameController.mode = Phases.Control;
        keyBoardInterface.SetActive(false);
        Destroy(this.keyBoardInterface);
    }
}
