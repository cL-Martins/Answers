using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Levers
{
    Alarm, Gas, Battery, Door
}
[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Outline))]
[RequireComponent(typeof(SoundEffects))]
public class Lever : MonoBehaviour
{
    LeverController leverController;
    Animator anim;
    public Levers type;
    public int idDoor, idBattery;
    int lastIdDoor, lastIdBattery;
    // Start is called before the first frame update
    void Start()
    {
        leverController = GetComponentInParent<LeverController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Interaction()
    {
        GetComponentInParent<SoundEffects>().PlaySound(0);
        anim.SetTrigger("push");
        switch (type)
        {
            case Levers.Alarm:
                leverController.Alarm = 1;
                break;
            case Levers.Battery:
                if (leverController.Alarm == 1)
                {
                    if(idBattery == lastIdBattery)
                    {
                        print(leverController.Battery);
                        leverController.Battery = 0;
                    } else
                    {
                        print(leverController.Battery);
                        leverController.Battery += 1;
                    }
                }
                else
                {
                    print(leverController.Battery);
                    leverController.Battery += 1;
                    lastIdBattery = idBattery;
                }
                
                break;
            case Levers.Door:
                if (leverController.Door == 1)
                {
                    if (lastIdDoor == idDoor)
                    {
                        leverController.Door = 0;
                    }
                    else
                    {
                        leverController.Door += 1;
                    }
                }
                else
                {
                    leverController.Door += 1;
                    lastIdDoor = idDoor;
                }
                break;
            case Levers.Gas:
                leverController.Gas = 1;
                break;
        }
    }
}
