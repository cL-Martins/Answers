using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wilberforce;
[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{
    CharacterController controller;
    Vector3 forward, strafe, vertical;
    public float forwardSpeed, strafeSpeed, forwardRunSpeed, staminaQtdLoss, staminaQtdGain, stamina;
    float gravity, staminaMax, timeStamina, timerRaycastRefresh;
    bool running;
    public static float lightIntensity;
    float timeToMaxHeight = 0.5f;
    public float distanceInteraction = 3;
    float externalLight;
    GameObject lastObjSelection;

    public GlowStickPack glowPack;
    Transform cam;


    private void Awake()
    {
        if (PlayerPrefs.HasKey("Volume"))
        {
            GameObject.Find("Music").GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("Volume");
        }
        if (PlayerPrefs.HasKey("Daltonic"))
        {
            Camera.main.GetComponent<Colorblind>().Type = PlayerPrefs.GetInt("Daltonic");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        staminaMax = stamina;
        controller = GetComponent<CharacterController>();
        cam = Camera.main.transform;
        gravity = (-2) / (timeToMaxHeight * timeToMaxHeight);
    }

    // Update is called once per frame
    void Update()
    {
        if (glowPack.TempPrefab != null)
        {
            lightIntensity = glowPack.TempPrefab.GetComponentInChildren<Light>().intensity + externalLight;
        } else
        {
            lightIntensity = externalLight;
        }
        if (GameController.mode.Equals(Phases.Control))
        {
            timerRaycastRefresh += Time.deltaTime;
            Controls();
            if (timerRaycastRefresh > 0.1f)
            {
                RayCastInteraction();
            }
        } else
        {
            timerRaycastRefresh = 0;
        }
    }
    void RayCastInteraction()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, distanceInteraction))
        {
            if (hit.collider.CompareTag("Interact")){
                lastObjSelection = hit.collider.gameObject;
                hit.collider.GetComponent<Outline>().SelectObj();
                if (Input.GetButtonDown("Fire1"))
                {
                    hit.collider.SendMessage("Interaction", SendMessageOptions.DontRequireReceiver);
                }
            }

        } else
        {
            if (lastObjSelection != null)
            {
                lastObjSelection.GetComponent<Outline>().DeselectObj();
            }
        }
    }
    void Controls()
    {
        float forwardInput = Input.GetAxisRaw("Vertical");
        float strafeInput = Input.GetAxisRaw("Horizontal");

        // Sistema de Corrida, pretendo otimizar depois;
        timeStamina += Time.deltaTime;
        if (Input.GetButtonDown("Fire3"))
        {
            running = true;
        }
        if (Input.GetButtonUp("Fire3"))
        {
            running = false;
        }
        if (running)
        {
            forward = forwardInput * forwardRunSpeed * transform.forward;
            if (timeStamina > 1 && stamina > 0)
            {
                stamina -= staminaQtdLoss;
                timeStamina = 0;
            }
            if(stamina <= 0)
            {
                stamina = 0;
                running = false;
            }
        } else
        {
            forward = forwardInput * forwardSpeed * transform.forward;
            if (timeStamina > 1 && stamina < staminaMax)
            {
                stamina += staminaQtdGain;
                timeStamina = 0;
            }
        }
        //Fim do sistema de corrida
        strafe = strafeInput * strafeSpeed * transform.right;

        vertical += gravity * Time.deltaTime * Vector3.up;

        if (controller.isGrounded)
        {
            vertical = Vector3.down;
        }

        if (vertical.y > 0 && (controller.collisionFlags & CollisionFlags.Above) != 0)
        {
            vertical = Vector3.zero;
        }


        Vector3 finalVelocity = forward + strafe + vertical;

        controller.Move(finalVelocity * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GlowStick"))
        {
            externalLight += other.GetComponent<Light>().intensity;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("GlowStick"))
        {
            externalLight -= other.GetComponent<Light>().intensity;
        }
    }

}
