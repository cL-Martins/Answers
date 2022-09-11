using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Outline))]
[RequireComponent(typeof(SoundEffects))]
[RequireComponent(typeof(BoxCollider))]
public class Door : MonoBehaviour
{
    bool open;
    [Tooltip("Coloque o nome da porta caso queiram atribuir uma tranca, do contrário deixem vazio")]
    public string doorName;
    public float openingDegrees = -120;
    public float step = 1;
    float rotationZ;

    public bool Open { get => open; set => open = value; }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
    void Interaction()
    {
        if (doorName.Equals("") || GameController.CheckKey(doorName))
        {
            open = !open;
            StopCoroutine("OpeningClosing");
            StartCoroutine("OpeningClosing");
            if (open)
            {
                GetComponent<SoundEffects>().PlaySound(0);
            } else
            {
                GetComponent<SoundEffects>().PlaySound(1);
            }
        }
        else
        {
            GetComponent<SoundEffects>().PlaySound(2);
        }
    }
    void OpenKeyBoard()
    {
        open = !open;
        doorName = "";
        GetComponent<SoundEffects>().PlaySound(1);

    }
    public IEnumerator OpeningClosing()
    {
        yield return new WaitForEndOfFrame();
        if (open)
        {
            rotationZ -= step;
            transform.localRotation = Quaternion.Euler(0, rotationZ, 0);
            if (rotationZ > openingDegrees)
            {
                StartCoroutine("OpeningClosing");
            }
            else
            {
                transform.localRotation = Quaternion.Euler(0, openingDegrees, 0);
            }
        }
        else
        {
            rotationZ += step;
            transform.localRotation = Quaternion.Euler(0, rotationZ, 0);
            if (rotationZ < 0)
            {
                StartCoroutine("OpeningClosing");
            }
            else
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
        }
    }
}
