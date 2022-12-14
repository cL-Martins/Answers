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
        passwordEntered = "";
        idVisor = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            GameController.mode = Phases.Control;
            keyBoardInterface.SetActive(false);
        }
    }
    void Interaction()
    {
        GetComponent<SoundEffects>().PlaySound(0);//Abrir o teclado
        keyBoardInterface.SetActive(true);
        GameController.mode = Phases.MouseActive;
    }
    public void PressButton(string value)
    {
        if (idVisor < 7)
        {
            GetComponent<SoundEffects>().PlaySound(1);//Apertar bot?o
            slots[idVisor].sprite = alphabet[int.Parse(value)];
            passwordEntered += value;
            idVisor++;
        }
        if(idVisor >= 7)
        {
            EnterPassword();
        }
    }
    public void EnterPassword()
    {
        idVisor = 0;
        if (passwordEntered.Equals(password))
        {
            GetComponent<SoundEffects>().PlaySound(2);//Acerta a senha
            Finish();
        } else
        {
            passwordEntered = "";
            GetComponent<SoundEffects>().PlaySound(3);// Erra a senha
            for(int i = 0; i <= 7; i++)
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
