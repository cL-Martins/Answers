using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Outline))]
[RequireComponent(typeof(SoundEffects))]
[RequireComponent(typeof(BoxCollider))]
public class KeyBoardPuzzle : MonoBehaviour
{
    public GameObject keyBoardInterface, door;
    public Sprite[] alphabet;
    public Image[] slots;
    public string password;
    int idVisor;
    string passwordEntered;
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
            GameController.mode = Phases.Control;
            keyBoardInterface.SetActive(false);
        }
    }
    void Interaction()
    {
        GetComponent<SoundEffects>().PlaySound(1);
        keyBoardInterface.SetActive(true);
        GameController.mode = Phases.MouseActive;
    }
    public void PressButton(string value)
    {
        if (idVisor < 5)
        {
            GetComponent<SoundEffects>().PlaySound(2);
            slots[idVisor].sprite = alphabet[int.Parse(value)];
            passwordEntered += value;
        }
        idVisor++;
        if(idVisor == 5)
        {
            EnterPassword();
        }
    }
    public void EnterPassword()
    {
        if (passwordEntered.Equals(password))
        {
            GetComponent<SoundEffects>().PlaySound(3);
            Finish();
        } else
        {
            GetComponent<SoundEffects>().PlaySound(4);
            for(int i = 0; i <= 5; i++)
            {
                slots[i].sprite = null;
            }
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
